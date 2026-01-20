using client.forms;
using client.src.entities;
using client.src.req_handler;
using client.src.socket;

namespace client
{
    public partial class fmain : Form
    {

        public fmain()
        {
            InitializeComponent();
            req_manager.setRequestHandler(new request_handler());
        }

        private async void bConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = tbIPAddress.Text.Trim();
            int port = 8080;
            try
            {
                 await req_manager.getRequestHandler()._network_Layer.ConnectAsync(ipAddress, port);
                 Form chatform = new chat();
                chatform.ShowDialog();

               // MessageBox.Show("Connected to server!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}");
            }
        }


    }
}
