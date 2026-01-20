using client.src.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.forms
{
    public partial class chat : Form
    {

        int groupID = -1;
        public chat()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (tbGroupID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid Group ID.");
                return;
            }

            this.groupID = int.Parse(tbGroupID.Text.Trim());
            await req_manager.getRequestHandler().ConnectToGroupAsync(groupID);

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var msg = new message(groupID, client_manager.GetID(), tbMessage.Text.Trim());

            await req_manager.getRequestHandler().SendMessageAsync(msg);

            tbMessage.Clear();

            lbMessages.Items.Add($"You: {msg.content}");
        }
    }
}
