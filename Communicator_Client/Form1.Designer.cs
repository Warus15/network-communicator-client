namespace Communicator_Client
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.configurationListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portNumeric = new System.Windows.Forms.NumericUpDown();
            this.connectionButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.bwConnection = new System.ComponentModel.BackgroundWorker();
            this.bwReceiving = new System.ComponentModel.BackgroundWorker();
            this.messagesWebBrowser = new System.Windows.Forms.WebBrowser();
            this.boldButton = new System.Windows.Forms.Button();
            this.italicButton = new System.Windows.Forms.Button();
            this.clearChatButton = new System.Windows.Forms.Button();
            this.underlineButton = new System.Windows.Forms.Button();
            this.strikeoutButton = new System.Windows.Forms.Button();
            this.nickTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.colorThemeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveToFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Console:";
            // 
            // configurationListBox
            // 
            this.configurationListBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.configurationListBox.FormattingEnabled = true;
            this.configurationListBox.ItemHeight = 17;
            this.configurationListBox.Location = new System.Drawing.Point(12, 31);
            this.configurationListBox.Name = "configurationListBox";
            this.configurationListBox.Size = new System.Drawing.Size(488, 72);
            this.configurationListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addressTextBox.Location = new System.Drawing.Point(76, 109);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(113, 27);
            this.addressTextBox.TabIndex = 3;
            this.addressTextBox.Text = "25.134.224.249";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // portNumeric
            // 
            this.portNumeric.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.portNumeric.Location = new System.Drawing.Point(76, 142);
            this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portNumeric.Name = "portNumeric";
            this.portNumeric.Size = new System.Drawing.Size(113, 27);
            this.portNumeric.TabIndex = 5;
            this.portNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // connectionButton
            // 
            this.connectionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectionButton.Location = new System.Drawing.Point(385, 109);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(115, 52);
            this.connectionButton.TabIndex = 6;
            this.connectionButton.Text = "Connect";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.messageTextBox.Location = new System.Drawing.Point(12, 557);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(490, 85);
            this.messageTextBox.TabIndex = 8;
            this.messageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sendButton.Location = new System.Drawing.Point(375, 648);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(127, 55);
            this.sendButton.TabIndex = 9;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bwConnection
            // 
            this.bwConnection.WorkerSupportsCancellation = true;
            this.bwConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnection_DoWork);
            // 
            // bwReceiving
            // 
            this.bwReceiving.WorkerSupportsCancellation = true;
            this.bwReceiving.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReceiving_DoWork);
            // 
            // messagesWebBrowser
            // 
            this.messagesWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.messagesWebBrowser.Location = new System.Drawing.Point(12, 175);
            this.messagesWebBrowser.MinimumSize = new System.Drawing.Size(18, 21);
            this.messagesWebBrowser.Name = "messagesWebBrowser";
            this.messagesWebBrowser.Size = new System.Drawing.Size(490, 376);
            this.messagesWebBrowser.TabIndex = 10;
            // 
            // boldButton
            // 
            this.boldButton.Enabled = false;
            this.boldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.boldButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.boldButton.Location = new System.Drawing.Point(15, 648);
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(85, 25);
            this.boldButton.TabIndex = 11;
            this.boldButton.Text = "Bold";
            this.boldButton.UseVisualStyleBackColor = true;
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // italicButton
            // 
            this.italicButton.Enabled = false;
            this.italicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.italicButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.italicButton.Location = new System.Drawing.Point(15, 679);
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(85, 24);
            this.italicButton.TabIndex = 12;
            this.italicButton.Text = "Italic";
            this.italicButton.UseVisualStyleBackColor = true;
            this.italicButton.Click += new System.EventHandler(this.italicButton_Click);
            // 
            // clearChatButton
            // 
            this.clearChatButton.Enabled = false;
            this.clearChatButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearChatButton.Location = new System.Drawing.Point(239, 648);
            this.clearChatButton.Name = "clearChatButton";
            this.clearChatButton.Size = new System.Drawing.Size(83, 25);
            this.clearChatButton.TabIndex = 15;
            this.clearChatButton.Text = "Clear Chat";
            this.clearChatButton.UseVisualStyleBackColor = true;
            this.clearChatButton.Click += new System.EventHandler(this.clearChatButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.Enabled = false;
            this.underlineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.underlineButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.underlineButton.Location = new System.Drawing.Point(106, 648);
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(85, 25);
            this.underlineButton.TabIndex = 16;
            this.underlineButton.Text = "Underline";
            this.underlineButton.UseVisualStyleBackColor = true;
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // strikeoutButton
            // 
            this.strikeoutButton.Enabled = false;
            this.strikeoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.strikeoutButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.strikeoutButton.Location = new System.Drawing.Point(106, 679);
            this.strikeoutButton.Name = "strikeoutButton";
            this.strikeoutButton.Size = new System.Drawing.Size(85, 24);
            this.strikeoutButton.TabIndex = 17;
            this.strikeoutButton.Text = "Strikeout";
            this.strikeoutButton.UseVisualStyleBackColor = true;
            this.strikeoutButton.Click += new System.EventHandler(this.strikeoutButton_Click);
            // 
            // nickTextBox
            // 
            this.nickTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nickTextBox.Location = new System.Drawing.Point(276, 109);
            this.nickTextBox.Name = "nickTextBox";
            this.nickTextBox.Size = new System.Drawing.Size(93, 27);
            this.nickTextBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nickname:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Server Key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.keyTextBox.Location = new System.Drawing.Point(276, 142);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PasswordChar = '*';
            this.keyTextBox.Size = new System.Drawing.Size(93, 27);
            this.keyTextBox.TabIndex = 21;
            // 
            // colorThemeComboBox
            // 
            this.colorThemeComboBox.FormattingEnabled = true;
            this.colorThemeComboBox.Location = new System.Drawing.Point(379, 6);
            this.colorThemeComboBox.Name = "colorThemeComboBox";
            this.colorThemeComboBox.Size = new System.Drawing.Size(121, 25);
            this.colorThemeComboBox.TabIndex = 22;
            this.colorThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.colorThemeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Color Theme:";
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Enabled = false;
            this.saveToFileButton.Location = new System.Drawing.Point(239, 679);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(83, 25);
            this.saveToFileButton.TabIndex = 24;
            this.saveToFileButton.Text = "Export";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(515, 716);
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.colorThemeComboBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nickTextBox);
            this.Controls.Add(this.strikeoutButton);
            this.Controls.Add(this.underlineButton);
            this.Controls.Add(this.clearChatButton);
            this.Controls.Add(this.italicButton);
            this.Controls.Add(this.boldButton);
            this.Controls.Add(this.messagesWebBrowser);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.portNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.configurationListBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Communicator Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox configurationListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.ComponentModel.BackgroundWorker bwConnection;
        private System.ComponentModel.BackgroundWorker bwReceiving;
        private System.Windows.Forms.WebBrowser messagesWebBrowser;
        private System.Windows.Forms.Button boldButton;
        private System.Windows.Forms.Button italicButton;
        private System.Windows.Forms.Button clearChatButton;
        private System.Windows.Forms.Button underlineButton;
        private System.Windows.Forms.Button strikeoutButton;
        private System.Windows.Forms.TextBox nickTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.ComboBox colorThemeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveToFileButton;
    }
}

