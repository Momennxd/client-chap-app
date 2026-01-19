
using client.socket;

namespace client
{
    public partial class fmain : Form
    {

        private server_handler _serverHandler = new server_handler();


        public fmain()
        {
            InitializeComponent();
        }

        private async void bConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = tbIPAddress.Text.Trim();
            int port = 8080;
            try
            {
                await _serverHandler.ConnectAsync(ipAddress, port);

                MessageBox.Show("Connected to server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}");
            }
        }


    }
}
