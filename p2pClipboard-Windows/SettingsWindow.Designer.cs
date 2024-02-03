namespace p2pClipboard_Windows
{
    partial class SettingsWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            openFileDialog1 = new OpenFileDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            useConnectCheckBox = new CheckBox();
            label1 = new Label();
            connectIpTextBox = new TextBox();
            label2 = new Label();
            connectPeerIdTextBox = new TextBox();
            setListenCheckBox = new CheckBox();
            label3 = new Label();
            listenIpTextBox = new TextBox();
            setPrivateKeyCheckBox = new CheckBox();
            label4 = new Label();
            privateKeyPathTextBox = new TextBox();
            useConnectLabel = new Label();
            setListenLabel = new Label();
            setPrivatekeyLabel = new Label();
            disableMdnslabel = new Label();
            disableMdnsCheckBox = new CheckBox();
            applyAndRestartButton = new Button();
            label9 = new Label();
            connectPortTextBox = new TextBox();
            listenPortTextBox = new TextBox();
            label10 = new Label();
            browsePrivateKeyButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(useConnectCheckBox, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(connectIpTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(connectPeerIdTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(setListenCheckBox, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 4);
            tableLayoutPanel1.Controls.Add(listenIpTextBox, 1, 4);
            tableLayoutPanel1.Controls.Add(setPrivateKeyCheckBox, 0, 5);
            tableLayoutPanel1.Controls.Add(label4, 0, 6);
            tableLayoutPanel1.Controls.Add(privateKeyPathTextBox, 1, 6);
            tableLayoutPanel1.Controls.Add(useConnectLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(setListenLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(setPrivatekeyLabel, 1, 5);
            tableLayoutPanel1.Controls.Add(disableMdnslabel, 1, 7);
            tableLayoutPanel1.Controls.Add(disableMdnsCheckBox, 0, 7);
            tableLayoutPanel1.Controls.Add(applyAndRestartButton, 1, 8);
            tableLayoutPanel1.Controls.Add(label9, 2, 1);
            tableLayoutPanel1.Controls.Add(connectPortTextBox, 3, 1);
            tableLayoutPanel1.Controls.Add(listenPortTextBox, 3, 4);
            tableLayoutPanel1.Controls.Add(label10, 2, 4);
            tableLayoutPanel1.Controls.Add(browsePrivateKeyButton, 3, 6);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.Size = new Size(776, 426);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // useConnectCheckBox
            // 
            useConnectCheckBox.Anchor = AnchorStyles.Right;
            useConnectCheckBox.AutoSize = true;
            useConnectCheckBox.ImageAlign = ContentAlignment.MiddleRight;
            useConnectCheckBox.Location = new Point(94, 10);
            useConnectCheckBox.Name = "useConnectCheckBox";
            useConnectCheckBox.Size = new Size(28, 27);
            useConnectCheckBox.TabIndex = 0;
            useConnectCheckBox.UseVisualStyleBackColor = true;
            useConnectCheckBox.CheckedChanged += useConnectCheckBox_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(16, 55);
            label1.Name = "label1";
            label1.Size = new Size(106, 31);
            label1.TabIndex = 1;
            label1.Text = "Address";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // connectIpTextBox
            // 
            connectIpTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            connectIpTextBox.Location = new Point(128, 53);
            connectIpTextBox.Name = "connectIpTextBox";
            connectIpTextBox.PlaceholderText = "IP";
            connectIpTextBox.Size = new Size(494, 38);
            connectIpTextBox.TabIndex = 2;
            connectIpTextBox.TextChanged += connectIpTextBox_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(31, 102);
            label2.Name = "label2";
            label2.Size = new Size(91, 31);
            label2.TabIndex = 3;
            label2.Text = "PeerID";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // connectPeerIdTextBox
            // 
            connectPeerIdTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(connectPeerIdTextBox, 3);
            connectPeerIdTextBox.Location = new Point(128, 100);
            connectPeerIdTextBox.Name = "connectPeerIdTextBox";
            connectPeerIdTextBox.PlaceholderText = "12D3KooWxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            connectPeerIdTextBox.Size = new Size(645, 38);
            connectPeerIdTextBox.TabIndex = 4;
            connectPeerIdTextBox.TextChanged += connectPeerIdTextBox_TextChanged;
            // 
            // setListenCheckBox
            // 
            setListenCheckBox.Anchor = AnchorStyles.Right;
            setListenCheckBox.AutoSize = true;
            setListenCheckBox.ImageAlign = ContentAlignment.MiddleRight;
            setListenCheckBox.Location = new Point(94, 151);
            setListenCheckBox.Name = "setListenCheckBox";
            setListenCheckBox.Size = new Size(28, 27);
            setListenCheckBox.TabIndex = 5;
            setListenCheckBox.UseVisualStyleBackColor = true;
            setListenCheckBox.CheckedChanged += setListenCheckBox_CheckedChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(16, 196);
            label3.Name = "label3";
            label3.Size = new Size(106, 31);
            label3.TabIndex = 6;
            label3.Text = "Address";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // listenIpTextBox
            // 
            listenIpTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listenIpTextBox.Location = new Point(128, 194);
            listenIpTextBox.Name = "listenIpTextBox";
            listenIpTextBox.PlaceholderText = "IP";
            listenIpTextBox.Size = new Size(494, 38);
            listenIpTextBox.TabIndex = 7;
            listenIpTextBox.TextChanged += listenIpTextBox_TextChanged;
            // 
            // setPrivateKeyCheckBox
            // 
            setPrivateKeyCheckBox.Anchor = AnchorStyles.Right;
            setPrivateKeyCheckBox.AutoSize = true;
            setPrivateKeyCheckBox.ImageAlign = ContentAlignment.MiddleRight;
            setPrivateKeyCheckBox.Location = new Point(94, 245);
            setPrivateKeyCheckBox.Name = "setPrivateKeyCheckBox";
            setPrivateKeyCheckBox.Size = new Size(28, 27);
            setPrivateKeyCheckBox.TabIndex = 8;
            setPrivateKeyCheckBox.UseVisualStyleBackColor = true;
            setPrivateKeyCheckBox.CheckedChanged += setPrivateKeyCheckBox_CheckedChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(56, 290);
            label4.Name = "label4";
            label4.Size = new Size(66, 31);
            label4.TabIndex = 9;
            label4.Text = "Path";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // privateKeyPathTextBox
            // 
            privateKeyPathTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(privateKeyPathTextBox, 2);
            privateKeyPathTextBox.Location = new Point(128, 288);
            privateKeyPathTextBox.Name = "privateKeyPathTextBox";
            privateKeyPathTextBox.PlaceholderText = "X:\\path\\to\\key.pem";
            privateKeyPathTextBox.Size = new Size(520, 38);
            privateKeyPathTextBox.TabIndex = 10;
            privateKeyPathTextBox.TextChanged += privateKeyPathTextBox_TextChanged;
            // 
            // useConnectLabel
            // 
            useConnectLabel.Anchor = AnchorStyles.Left;
            useConnectLabel.AutoSize = true;
            useConnectLabel.Location = new Point(128, 8);
            useConnectLabel.Name = "useConnectLabel";
            useConnectLabel.Size = new Size(282, 31);
            useConnectLabel.TabIndex = 11;
            useConnectLabel.Text = "Connect to other node:";
            useConnectLabel.TextAlign = ContentAlignment.MiddleLeft;
            useConnectLabel.Click += useConnectLabel_Click;
            // 
            // setListenLabel
            // 
            setListenLabel.Anchor = AnchorStyles.Left;
            setListenLabel.AutoSize = true;
            setListenLabel.Location = new Point(128, 149);
            setListenLabel.Name = "setListenLabel";
            setListenLabel.Size = new Size(220, 31);
            setListenLabel.TabIndex = 12;
            setListenLabel.Text = "Set listen address:";
            setListenLabel.TextAlign = ContentAlignment.MiddleLeft;
            setListenLabel.Click += setListenLabel_Click;
            // 
            // setPrivatekeyLabel
            // 
            setPrivatekeyLabel.Anchor = AnchorStyles.Left;
            setPrivatekeyLabel.AutoSize = true;
            setPrivatekeyLabel.Location = new Point(128, 243);
            setPrivatekeyLabel.Name = "setPrivatekeyLabel";
            setPrivatekeyLabel.Size = new Size(241, 31);
            setPrivatekeyLabel.TabIndex = 13;
            setPrivatekeyLabel.Text = "Custom private key:";
            setPrivatekeyLabel.TextAlign = ContentAlignment.MiddleLeft;
            setPrivatekeyLabel.Click += setPrivatekeyLabel_Click;
            // 
            // disableMdnslabel
            // 
            disableMdnslabel.Anchor = AnchorStyles.Left;
            disableMdnslabel.AutoSize = true;
            disableMdnslabel.Location = new Point(128, 337);
            disableMdnslabel.Name = "disableMdnslabel";
            disableMdnslabel.Size = new Size(178, 31);
            disableMdnslabel.TabIndex = 14;
            disableMdnslabel.Text = "Disable mDNS";
            disableMdnslabel.TextAlign = ContentAlignment.MiddleLeft;
            disableMdnslabel.Click += disableMdnslabel_Click;
            // 
            // disableMdnsCheckBox
            // 
            disableMdnsCheckBox.Anchor = AnchorStyles.Right;
            disableMdnsCheckBox.AutoSize = true;
            disableMdnsCheckBox.ImageAlign = ContentAlignment.MiddleRight;
            disableMdnsCheckBox.Location = new Point(94, 339);
            disableMdnsCheckBox.Name = "disableMdnsCheckBox";
            disableMdnsCheckBox.Size = new Size(28, 27);
            disableMdnsCheckBox.TabIndex = 15;
            disableMdnsCheckBox.UseVisualStyleBackColor = true;
            disableMdnsCheckBox.CheckedChanged += disableMdnsCheckBox_CheckedChanged;
            // 
            // applyAndRestartButton
            // 
            applyAndRestartButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(applyAndRestartButton, 2);
            applyAndRestartButton.Location = new Point(128, 379);
            applyAndRestartButton.Name = "applyAndRestartButton";
            applyAndRestartButton.Size = new Size(520, 44);
            applyAndRestartButton.TabIndex = 16;
            applyAndRestartButton.Text = "Apply && Restart";
            applyAndRestartButton.UseVisualStyleBackColor = true;
            applyAndRestartButton.Click += applyAndRestartButton_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(628, 47);
            label9.Name = "label9";
            label9.Size = new Size(20, 47);
            label9.TabIndex = 17;
            label9.Text = ":";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // connectPortTextBox
            // 
            connectPortTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            connectPortTextBox.Location = new Point(654, 53);
            connectPortTextBox.Name = "connectPortTextBox";
            connectPortTextBox.PlaceholderText = "Port";
            connectPortTextBox.Size = new Size(119, 38);
            connectPortTextBox.TabIndex = 18;
            connectPortTextBox.TextChanged += connectPortTextBox_TextChanged;
            // 
            // listenPortTextBox
            // 
            listenPortTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listenPortTextBox.Location = new Point(654, 194);
            listenPortTextBox.Name = "listenPortTextBox";
            listenPortTextBox.PlaceholderText = "Port";
            listenPortTextBox.Size = new Size(119, 38);
            listenPortTextBox.TabIndex = 19;
            listenPortTextBox.TextChanged += listenPortTextBox_TextChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(628, 188);
            label10.Name = "label10";
            label10.Size = new Size(20, 47);
            label10.TabIndex = 20;
            label10.Text = ":";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // browsePrivateKeyButton
            // 
            browsePrivateKeyButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            browsePrivateKeyButton.Location = new Point(654, 288);
            browsePrivateKeyButton.Margin = new Padding(3, 6, 3, 2);
            browsePrivateKeyButton.Name = "browsePrivateKeyButton";
            browsePrivateKeyButton.Size = new Size(119, 39);
            browsePrivateKeyButton.TabIndex = 21;
            browsePrivateKeyButton.Text = "Browse";
            browsePrivateKeyButton.UseVisualStyleBackColor = true;
            browsePrivateKeyButton.Click += browsePrivateKeyButton_Click;
            // 
            // SettingsWindow
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SettingsWindow";
            Text = "p2pClipboard Settings";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox useConnectCheckBox;
        private Label label1;
        private TextBox connectIpTextBox;
        private Label label2;
        private TextBox connectPeerIdTextBox;
        private CheckBox setListenCheckBox;
        private Label label3;
        private TextBox listenIpTextBox;
        private CheckBox setPrivateKeyCheckBox;
        private Label label4;
        private TextBox privateKeyPathTextBox;
        private Label useConnectLabel;
        private Label setListenLabel;
        private Label setPrivatekeyLabel;
        private Label disableMdnslabel;
        private CheckBox disableMdnsCheckBox;
        private Button applyAndRestartButton;
        private Label label9;
        private TextBox connectPortTextBox;
        private TextBox listenPortTextBox;
        private Label label10;
        private Button browsePrivateKeyButton;
    }
}
