namespace client
{
    partial class fmain
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
            tbIPAddress = new TextBox();
            btnConnect = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // tbIPAddress
            // 
            tbIPAddress.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbIPAddress.Location = new Point(325, 192);
            tbIPAddress.Multiline = true;
            tbIPAddress.Name = "tbIPAddress";
            tbIPAddress.Size = new Size(348, 39);
            tbIPAddress.TabIndex = 0;
            tbIPAddress.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.Location = new Point(446, 258);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(86, 56);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += bConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(446, 164);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 2;
            label1.Text = "IP Adress";
            // 
            // fmain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 540);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Controls.Add(tbIPAddress);
            Name = "fmain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbIPAddress;
        private Button btnConnect;
        private Label label1;
    }
}
