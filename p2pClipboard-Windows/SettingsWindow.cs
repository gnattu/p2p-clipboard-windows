namespace p2pClipboard_Windows
{
    public partial class SettingsWindow : Form
    {
        private TrayApplicationContext _applicationContext;
        public SettingsWindow(TrayApplicationContext applicationContext)
        {
            InitializeComponent();
            _applicationContext = applicationContext;
            connectIpTextBox.Text = _applicationContext.connectIp;
            connectPortTextBox.Text = _applicationContext.connectPort;
            connectPeerIdTextBox.Text = _applicationContext.connectPeerId;
            listenIpTextBox.Text = _applicationContext.listenIp;
            listenPortTextBox.Text = _applicationContext.listenPort;
            privateKeyPathTextBox.Text = _applicationContext.privateKeyPath;
            pskTextBox.Text = _applicationContext.psk;
            useConnectCheckBox.Checked
                = connectIpTextBox.Enabled
                = connectPortTextBox.Enabled
                = connectPeerIdTextBox.Enabled
                = _applicationContext.useConnect;
            setListenCheckBox.Checked
                = listenIpTextBox.Enabled
                = listenPortTextBox.Enabled
                = _applicationContext.setListen;
            setPrivateKeyCheckBox.Checked
                = privateKeyPathTextBox.Enabled
                = browsePrivateKeyButton.Enabled
                = _applicationContext.setPrivateKey;
            disableMdnsCheckBox.Checked
                = _applicationContext.disableMdns;
            setPskCheckBox.Checked
                = pskTextBox.Enabled
                = _applicationContext.setPsk;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine(openFileDialog1.FileName);
            privateKeyPathTextBox.Text = _applicationContext.privateKeyPath = openFileDialog1.FileName;
        }

        private void browsePrivateKeyButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PEM Private Key (*.pem) | *.pem";
            openFileDialog1.ShowDialog();
        }

        private void connectIpTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.connectIp = connectIpTextBox.Text;
        }

        private void connectPortTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.connectPort = connectPortTextBox.Text;
        }

        private void listenIpTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.listenIp = listenIpTextBox.Text;
        }

        private void listenPortTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.listenPort = listenPortTextBox.Text;
        }

        private void privateKeyPathTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.privateKeyPath = privateKeyPathTextBox.Text;
        }

        private void applyAndRestartButton_Click(object sender, EventArgs e)
        {
            Task.Run(_applicationContext.SaveConfigAndRestart);
            this.Close();
        }

        private void connectPeerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.connectPeerId = connectPeerIdTextBox.Text;
        }

        private void useConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _applicationContext.useConnect
                = connectIpTextBox.Enabled
                = connectPortTextBox.Enabled
                = connectPeerIdTextBox.Enabled
                = useConnectCheckBox.Checked;
        }

        private void setListenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _applicationContext.setListen
               = listenPortTextBox.Enabled
               = listenIpTextBox.Enabled
               = setListenCheckBox.Checked;
        }

        private void setPrivateKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _applicationContext.setPrivateKey
                 = privateKeyPathTextBox.Enabled
                 = browsePrivateKeyButton.Enabled
                 = setPrivateKeyCheckBox.Checked;
        }

        private void useConnectLabel_Click(object sender, EventArgs e)
        {
            useConnectCheckBox.Checked = !useConnectCheckBox.Checked;
        }

        private void setListenLabel_Click(object sender, EventArgs e)
        {
            setListenCheckBox.Checked = !setListenCheckBox.Checked;
        }

        private void setPrivatekeyLabel_Click(object sender, EventArgs e)
        {
            setPrivateKeyCheckBox.Checked = !setPrivateKeyCheckBox.Checked;
        }

        private void disableMdnsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _applicationContext.disableMdns = disableMdnsCheckBox.Checked;
        }

        private void disableMdnslabel_Click(object sender, EventArgs e)
        {
            disableMdnsCheckBox.Checked = !disableMdnsCheckBox.Checked;
        }

        private void pskTextBox_TextChanged(object sender, EventArgs e)
        {
            _applicationContext.psk = pskTextBox.Text;
        }

        private void setPskLabel_Click(object sender, EventArgs e)
        {
            setPskCheckBox.Checked = !setPskCheckBox.Checked;
        }

        private void setPskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _applicationContext.setPsk 
                = pskTextBox.Enabled
                = setPskCheckBox.Checked;
        }
    }
}
