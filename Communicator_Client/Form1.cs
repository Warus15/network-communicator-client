using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communicator_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            prepareColorThemes();
        }

        private bool activeConnection = false;
        private TcpClient client = null;
        private BinaryReader reading = null;
        private BinaryWriter writing = null;
        private string nick = "";
        private string key = "";
        private const string disconnectingMessage = "CONNECTION_CANCELLED";

        //
        private string content = string.Empty;
        private string style = string.Empty;
        //

        private void connectionButton_Click(object sender, EventArgs e)
        {
            if (!activeConnection)
            {
                if(nickTextBox.Text == "")
                {
                    configurationListBox.Items.Add("Enter nickname!");
                    return;
                }
                if (keyTextBox.Text == "")
                {
                    configurationListBox.Items.Add("Enter server key!");
                    return;
                }

                buttonBlock(true);
                nick = nickTextBox.Text;
                key = keyTextBox.Text;
                bwConnection.RunWorkerAsync();
                    
            } else
            {
                disconnect();
            }
        }

        private void bwConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            string host = addressTextBox.Text;
            int port = System.Convert.ToInt16(portNumeric.Value);

            try
            {
                client = new TcpClient(host, port);
                this.Invoke(new MethodInvoker(delegate { buttonBlock(false); }));

                activeConnection = true;
                connectionButton.Invoke(new MethodInvoker(delegate {connectionButton.Text = "Disconnect";}));
                this.Invoke(new MethodInvoker(delegate { updateUI(); }));

                configurationListBox.Invoke(new MethodInvoker(delegate
                {
                    configurationListBox.Items.Add("=======================");
                    configurationListBox.Items.Add("Aktualna konfiguracja:");
                    configurationListBox.Items.Add("");
                    configurationListBox.Items.Add($"Nick: {nick}");
                    configurationListBox.Items.Add($"Data: {DateTime.Now}");
                    configurationListBox.Items.Add($"Host: {host}");
                    configurationListBox.Items.Add($"Port: {port}");        
                    configurationListBox.Items.Add("=======================");
                    configurationListBox.Items.Add("");
                }));

                NetworkStream stream = client.GetStream();
                reading = new BinaryReader(stream);
                writing = new BinaryWriter(stream);

                writing.Write(key);
                writing.Write(nick);

                messageTextBox.Invoke(new MethodInvoker(delegate { messageTextBox.Enabled = true; }));
                sendButton.Invoke(new MethodInvoker(delegate {sendButton.Enabled = true; }));

                bwReceiving.RunWorkerAsync();
            }

            catch (Exception ex) {
                this.Invoke(new MethodInvoker(delegate { buttonBlock(false); }));

                configurationListBox.Invoke(new MethodInvoker(delegate
                {
                    configurationListBox.Items.Add("Nie udało się nawiązać połączenia.");
                    configurationListBox.Items.Add("");
                }));
                //MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (activeConnection)
                disconnect();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try {
                if(messageTextBox.Text != string.Empty)
                {
                    string message = messageTextBox.Text;
                    writing.Write(message);
                    messageTextBox.Text = "";
                }
            }
            catch {
                configurationListBox.Items.Add("Connection was interrupted.");
                MessageBox.Show("Connection was interrupted, disconnecting.", "Sending error");
                connectionButton.PerformClick();
            }
        }

        private void bwReceiving_DoWork(object sender, DoWorkEventArgs e)
        {
            string messageRecived = "";

            try
            {
                while ((messageRecived = reading.ReadString()) != "SERVER_STOPPED")
                {
                    

                    if (messageRecived == "ERR_INVALID_PASSWORD")
                    {
                        content += "<b><i>Wprowadzono błędne hasło!</i></b><br />";
                        this.Invoke(new MethodInvoker(delegate { handleBrowser(); }));
                        configurationListBox.Invoke(new MethodInvoker(delegate { configurationListBox.Items.Add("INVALID PASSWORD"); }));
                        this.Invoke(new MethodInvoker(delegate { disconnect(); }));
                        return;
                    }
                    if (messageRecived == "ERR_NAME_TAKEN")
                    {
                        content += "<b><i>Użytkownik o takiej nazwie już istnieje</i></b><br />";
                        this.Invoke(new MethodInvoker(delegate { handleBrowser(); }));
                        configurationListBox.Invoke(new MethodInvoker(delegate { configurationListBox.Items.Add("NICKNAME ALREADY EXISTS"); }));
                        this.Invoke(new MethodInvoker(delegate { disconnect(); }));
                        return;
                    }

                    content += messageRecived;
                    this.Invoke(new MethodInvoker(delegate { handleBrowser(); }));
                }

                messagesWebBrowser.Invoke(new MethodInvoker(delegate { messagesWebBrowser.DocumentText += $"SERVER_STOPPED<br />"; }));
                configurationListBox.Invoke(new MethodInvoker(delegate { configurationListBox.Items.Add("SERVER_STOPPED"); }));
                this.Invoke(new MethodInvoker(delegate { disconnect(); }));
            }
            catch{}
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            int selectionStart = messageTextBox.SelectionStart;
            int selectionEnd = messageTextBox.SelectionStart + messageTextBox.SelectionLength + 3;

            messageTextBox.Text = messageTextBox.Text.Insert(selectionStart, "<b>");
            messageTextBox.Text = messageTextBox.Text.Insert(selectionEnd, "</b>");

            messageTextBox.Focus();
            messageTextBox.SelectionStart = selectionStart + 3;
            messageTextBox.SelectionLength = 0;
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            int selectionStart = messageTextBox.SelectionStart;
            int selectionEnd = messageTextBox.SelectionStart + messageTextBox.SelectionLength + 3;

            messageTextBox.Text = messageTextBox.Text.Insert(selectionStart, "<i>");
            messageTextBox.Text = messageTextBox.Text.Insert(selectionEnd, "</i>");

            messageTextBox.Focus();
            messageTextBox.SelectionStart = selectionStart + 3;
            messageTextBox.SelectionLength = 0;
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            int selectionStart = messageTextBox.SelectionStart;
            int selectionEnd = messageTextBox.SelectionStart + messageTextBox.SelectionLength + 3;

            messageTextBox.Text = messageTextBox.Text.Insert(selectionStart, "<u>");
            messageTextBox.Text = messageTextBox.Text.Insert(selectionEnd, "</u>");

            messageTextBox.Focus();
            messageTextBox.SelectionStart = selectionStart + 3;
            messageTextBox.SelectionLength = 0;
        }

        private void strikeoutButton_Click(object sender, EventArgs e)
        {
            int selectionStart = messageTextBox.SelectionStart;
            int selectionEnd = messageTextBox.SelectionStart + messageTextBox.SelectionLength + 3;

            messageTextBox.Text = messageTextBox.Text.Insert(selectionStart, "<s>");
            messageTextBox.Text = messageTextBox.Text.Insert(selectionEnd, "</s>");

            messageTextBox.Focus();
            messageTextBox.SelectionStart = selectionStart + 3;
            messageTextBox.SelectionLength = 0;
        }

        private void clearChatButton_Click(object sender, EventArgs e)
        {
            content = string.Empty;
            handleBrowser();
        }

        private void updateUI()
        {
            if (activeConnection) {
                addressTextBox.Enabled = false;
                portNumeric.Enabled = false;
                nickTextBox.Enabled = false;
                keyTextBox.Enabled = false;

                messageTextBox.Enabled = true;
                messageTextBox.Text = "";
                sendButton.Enabled = true;
                clearChatButton.Enabled = true;
                boldButton.Enabled = true;
                italicButton.Enabled = true;
                underlineButton.Enabled = true;
                strikeoutButton.Enabled = true;
                saveToFileButton.Enabled = true;
            } else {
                messageTextBox.Enabled = false;
                messageTextBox.Text = "";
                sendButton.Enabled = false;
                clearChatButton.Enabled = false;
                boldButton.Enabled = false;
                italicButton.Enabled = false;
                underlineButton.Enabled = false;
                strikeoutButton.Enabled = false;
                saveToFileButton.Enabled = false;

                addressTextBox.Enabled = true;
                portNumeric.Enabled = true;
                nickTextBox.Enabled = true;
                keyTextBox.Enabled = true;
            }
        }

        private void prepareColorThemes()
        {
            style = "body{background: rgb(33,33,33); color: white; font-family: \"Segoe UI\";max-width: 100vw; word-break: break-all;}";
            handleBrowser();

            string[] THEMES = { "Dark", "Light", "Sweet Candy", "Definitely Not FB" , "Plum", "Matrix", "High Contrast"};

            foreach(string theme in THEMES)
                colorThemeComboBox.Items.Add(theme);

            colorThemeComboBox.SelectedIndex = 0;
        }

        private void setColors(string theme)
        {
            Color appBackground = Color.FromArgb(255, 18, 18, 18);
            Color background = Color.FromArgb(255, 33, 33, 33);
            Color font = Color.White;
            string webBackground = "rgb(33,33,33);";
            string webFont = "white;";
            bool border = false;

            switch (theme)
            {
                case "Dark":
                    appBackground = Color.FromArgb(255, 18, 18, 18);
                    background = Color.FromArgb(255, 33, 33, 33);
                    font = Color.White;
                    webBackground = "rgb(33,33,33)";
                    webFont = "white";
                    border = false;
                    break;

                case "Light":
                    appBackground = Color.FromArgb(255, 245, 245, 245);
                    background = Color.FromArgb(255, 255, 255, 255);
                    font = Color.Black;
                    webBackground = "rgb(255,255,255)";
                    webFont = "black";
                    border = true;
                    break;

                case "Sweet Candy":
                    appBackground = Color.FromArgb(255, 255, 190, 213);
                    background = Color.FromArgb(255, 255, 219, 233);
                    font = Color.FromArgb(255, 193, 24, 113);//Color.Black;
                    webBackground = "rgb(255, 219, 233)";
                    webFont = "rgb(193,24,113)";
                    border = false;
                    break;

                case "Definitely Not FB":
                    appBackground = Color.FromArgb(255, 78, 107, 162);
                    background = Color.FromArgb(255, 49, 72, 121);
                    font = Color.White;
                    webBackground = "rgb(49,72,121)";
                    webFont = "white";
                    border = false;
                    break;

                case "Plum":
                    appBackground = Color.FromArgb(255, 67, 2, 79);
                    background = Color.FromArgb(255, 87, 0, 100);
                    font = Color.White;
                    webBackground = "rgb(87,0,100)";
                    webFont = "white";
                    border = false;
                    break;

                case "Matrix":
                    appBackground = Color.FromArgb(255, 5, 5, 5);
                    background = Color.FromArgb(255, 20, 20, 20);
                    font = Color.FromArgb(255, 57, 255, 20);
                    webBackground = "rgb(20,20,20)";
                    webFont = "rgb(57,255,20)";
                    border = false;
                    break;

                case "High Contrast":
                    appBackground = Color.FromArgb(255, 0, 0, 0);
                    background = Color.FromArgb(255, 5, 5, 5);
                    font = Color.White;
                    webBackground = "rgb(5,5,5)";
                    webFont = "white";
                    border = true;
                    break;
            }

            this.BackColor = appBackground;
            this.ForeColor = font;

            configurationListBox.BackColor = background;
            configurationListBox.ForeColor = font; 

            messageTextBox.BackColor = background;
            messageTextBox.ForeColor = font;

            //WEB
            style = "body{background: " + webBackground + "; color: " + webFont + "; font-family: \"Segoe UI\"; max-width: 100vw; word-break: break-all;}";
            handleBrowser();
            //

            connectionButton.BackColor = background;
            connectionButton.ForeColor = font;

            addressTextBox.BackColor = background;
            addressTextBox.ForeColor = font;

            portNumeric.BackColor = background;
            portNumeric.ForeColor = font;

            nickTextBox.BackColor = background;
            nickTextBox.ForeColor = font;

            keyTextBox.BackColor = background;
            keyTextBox.ForeColor = font;

            sendButton.BackColor = background;
            sendButton.ForeColor = font;

            clearChatButton.BackColor = background;
            clearChatButton.ForeColor = font;

            boldButton.BackColor = background;
            boldButton.ForeColor = font;

            italicButton.BackColor = background;
            italicButton.ForeColor = font;

            underlineButton.BackColor = background;
            underlineButton.ForeColor = font;

            strikeoutButton.BackColor = background;
            strikeoutButton.ForeColor = font;

            saveToFileButton.BackColor = background;
            saveToFileButton.ForeColor = font;

            if (border)
            {
                configurationListBox.BorderStyle = BorderStyle.Fixed3D;
                messageTextBox.BorderStyle = BorderStyle.Fixed3D;
                addressTextBox.BorderStyle = BorderStyle.Fixed3D;
                portNumeric.BorderStyle = BorderStyle.Fixed3D;
                nickTextBox.BorderStyle = BorderStyle.Fixed3D;
                keyTextBox.BorderStyle = BorderStyle.Fixed3D;

                connectionButton.FlatStyle = FlatStyle.System;
                connectionButton.FlatAppearance.BorderSize = 1;

                sendButton.FlatStyle = FlatStyle.System;
                sendButton.FlatAppearance.BorderSize = 1;

                clearChatButton.FlatStyle = FlatStyle.System;
                clearChatButton.FlatAppearance.BorderSize = 1;

                boldButton.FlatStyle = FlatStyle.System;
                boldButton.FlatAppearance.BorderSize = 1;

                italicButton.FlatStyle = FlatStyle.System;
                italicButton.FlatAppearance.BorderSize = 1;

                underlineButton.FlatStyle = FlatStyle.System;
                underlineButton.FlatAppearance.BorderSize = 1;

                strikeoutButton.FlatStyle = FlatStyle.System;
                strikeoutButton.FlatAppearance.BorderSize = 1;

                saveToFileButton.FlatStyle = FlatStyle.System;
                saveToFileButton.FlatAppearance.BorderSize = 1;
            }
            else
            {
                configurationListBox.BorderStyle = BorderStyle.None;
                messageTextBox.BorderStyle = BorderStyle.None;
                addressTextBox.BorderStyle = BorderStyle.None;
                portNumeric.BorderStyle = BorderStyle.None;
                nickTextBox.BorderStyle = BorderStyle.None;
                keyTextBox.BorderStyle = BorderStyle.None;

                connectionButton.FlatStyle = FlatStyle.Flat;
                connectionButton.FlatAppearance.BorderSize = 0;

                sendButton.FlatStyle = FlatStyle.Flat;
                sendButton.FlatAppearance.BorderSize = 0;

                clearChatButton.FlatStyle = FlatStyle.Flat;
                clearChatButton.FlatAppearance.BorderSize = 0;

                boldButton.FlatStyle = FlatStyle.Flat;
                boldButton.FlatAppearance.BorderSize = 0;

                italicButton.FlatStyle = FlatStyle.Flat;
                italicButton.FlatAppearance.BorderSize = 0;

                underlineButton.FlatStyle = FlatStyle.Flat;
                underlineButton.FlatAppearance.BorderSize = 0;

                strikeoutButton.FlatStyle = FlatStyle.Flat;
                strikeoutButton.FlatAppearance.BorderSize = 0;

                saveToFileButton.FlatStyle = FlatStyle.Flat;
                saveToFileButton.FlatAppearance.BorderSize = 0;
            }
        }

        private void buttonBlock(bool block) {
            if (block)
            {
                addressTextBox.Enabled = false;
                portNumeric.Enabled = false;
                nickTextBox.Enabled = false;
                keyTextBox.Enabled = false;
                connectionButton.Enabled = false;
            }
            else
            {
                addressTextBox.Enabled = true;
                portNumeric.Enabled = true;
                nickTextBox.Enabled = true;
                keyTextBox.Enabled = true;
                connectionButton.Enabled = true;
            }
        }

        private void disconnect() {
            try {
                writing.Write(disconnectingMessage);
                Debug.WriteLine(messagesWebBrowser.DocumentText);
            } catch { }

            client.Close();
            reading.Close();
            bwReceiving.CancelAsync();
            bwConnection.CancelAsync();

            configurationListBox.Invoke(new MethodInvoker(delegate {
                configurationListBox.Items.Add("Disconnected");
                configurationListBox.Items.Add("");
            }));

            connectionButton.Text = "Connect";
            activeConnection = false;

            updateUI();
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                sendButton.PerformClick();
                e.SuppressKeyPress = true;

                messageTextBox.Focus();
            }
        }

        private void colorThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setColors(colorThemeComboBox.GetItemText(colorThemeComboBox.SelectedItem));
            this.ActiveControl = null;
        }

        /*private void addMessage(string message)
        {
            int endIndex = messagesWebBrowser.DocumentText.IndexOf("</body>");

            string tempDocStart = messagesWebBrowser.DocumentText.Substring(0, endIndex);
            string tempDocEnd = messagesWebBrowser.DocumentText.Substring(endIndex, messagesWebBrowser.DocumentText.Length - endIndex);

            messagesWebBrowser.DocumentText = "";
            string docText = $"{tempDocStart}{message}{tempDocEnd}";
            messagesWebBrowser.DocumentText = docText;

            messagesWebBrowser.Document.Window.ScrollTo(0, messagesWebBrowser.Document.Body.ScrollRectangle.Height);
            configurationListBox.Items.Add(messagesWebBrowser.Document.Body.ScrollRectangle.Height);
        }*/

        private void handleBrowser()
        {
            if(messagesWebBrowser.Document == null)
            {
                messagesWebBrowser.Navigate("about:blank");
                messagesWebBrowser.Document.OpenNew(true).Write(content);
            } else
            {
                messagesWebBrowser.Document.OpenNew(false).Write($"<html><head><style>{style}</style></head><body>{content}</body></html>");
            }
            if (messagesWebBrowser.Document.Body != null)
                messagesWebBrowser.Document.Window.ScrollTo(0, messagesWebBrowser.Document.Body.ScrollRectangle.Height);

            this.ActiveControl = messageTextBox;
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog chatSaveDialog = new SaveFileDialog();
            chatSaveDialog.FileName = $"chatlog-{DateTime.Now.Ticks}";
            chatSaveDialog.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";

            if(chatSaveDialog.ShowDialog() == DialogResult.OK) {
                string log = $"Chat saved on: {DateTime.Now}{Environment.NewLine}";
                log += Regex.Replace(Regex.Replace(content, "</div>", Environment.NewLine), "<.*?>", string.Empty);

                if (chatSaveDialog.FileName != string.Empty)
                    File.WriteAllText(chatSaveDialog.FileName, log);
            }
        }
    }
}
