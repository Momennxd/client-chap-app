namespace client.forms
{
    partial class chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbMessages = new ListBox();
            label1 = new Label();
            btnConnect = new Button();
            tbGroupID = new TextBox();
            btnSend = new Button();
            tbMessage = new TextBox();
            SuspendLayout();
            // 
            // lbMessages
            // 
            lbMessages.BorderStyle = BorderStyle.None;
            lbMessages.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMessages.FormattingEnabled = true;
            lbMessages.ItemHeight = 25;
            lbMessages.Location = new Point(113, 165);
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(976, 325);
            lbMessages.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(368, 42);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 5;
            label1.Text = "Group";
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.Location = new Point(735, 68);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(86, 39);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // tbGroupID
            // 
            tbGroupID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbGroupID.Location = new Point(368, 70);
            tbGroupID.Multiline = true;
            tbGroupID.Name = "tbGroupID";
            tbGroupID.Size = new Size(348, 37);
            tbGroupID.TabIndex = 3;
            tbGroupID.Text = "1";
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(650, 496);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(102, 80);
            btnSend.TabIndex = 7;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // tbMessage
            // 
            tbMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMessage.Location = new Point(113, 496);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(498, 80);
            tbMessage.TabIndex = 6;
            // 
            // chat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 672);
            Controls.Add(btnSend);
            Controls.Add(tbMessage);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Controls.Add(tbGroupID);
            Controls.Add(lbMessages);
            Name = "chat";
            Text = "Groups";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbMessages;
        private Label label1;
        private Button btnConnect;
        private TextBox tbGroupID;
        private Button btnSend;
        private TextBox tbMessage;
    }
}