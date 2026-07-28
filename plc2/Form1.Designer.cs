namespace plc2
{
    partial class Form1
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
            this.butt_connect = new System.Windows.Forms.Button();
            this.butt_open = new System.Windows.Forms.Button();
            this.butt_close = new System.Windows.Forms.Button();
            this.txtSpeedRef = new System.Windows.Forms.TextBox();
            this.txtSpeedAct = new System.Windows.Forms.TextBox();
            this.butt_SetSpeed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butt_connect
            // 
            this.butt_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_connect.Location = new System.Drawing.Point(12, 12);
            this.butt_connect.Name = "butt_connect";
            this.butt_connect.Size = new System.Drawing.Size(389, 97);
            this.butt_connect.TabIndex = 0;
            this.butt_connect.Text = "BAĞLA";
            this.butt_connect.UseVisualStyleBackColor = true;
            this.butt_connect.Click += new System.EventHandler(this.butt_connect_Click);
            // 
            // butt_open
            // 
            this.butt_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_open.Location = new System.Drawing.Point(12, 115);
            this.butt_open.Name = "butt_open";
            this.butt_open.Size = new System.Drawing.Size(187, 97);
            this.butt_open.TabIndex = 1;
            this.butt_open.Text = "AÇ";
            this.butt_open.UseVisualStyleBackColor = true;
            this.butt_open.Click += new System.EventHandler(this.butt_open_Click);
            // 
            // butt_close
            // 
            this.butt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_close.Location = new System.Drawing.Point(214, 115);
            this.butt_close.Name = "butt_close";
            this.butt_close.Size = new System.Drawing.Size(187, 97);
            this.butt_close.TabIndex = 2;
            this.butt_close.Text = "KAPAT";
            this.butt_close.UseVisualStyleBackColor = true;
            this.butt_close.Click += new System.EventHandler(this.butt_close_Click);
            // 
            // txtSpeedRef
            // 
            this.txtSpeedRef.Location = new System.Drawing.Point(13, 218);
            this.txtSpeedRef.Multiline = true;
            this.txtSpeedRef.Name = "txtSpeedRef";
            this.txtSpeedRef.ReadOnly = true;
            this.txtSpeedRef.Size = new System.Drawing.Size(186, 31);
            this.txtSpeedRef.TabIndex = 3;
            this.txtSpeedRef.TextChanged += new System.EventHandler(this.txtSpeedAct_TextChanged);
            // 
            // txtSpeedAct
            // 
            this.txtSpeedAct.Location = new System.Drawing.Point(212, 261);
            this.txtSpeedAct.Multiline = true;
            this.txtSpeedAct.Name = "txtSpeedAct";
            this.txtSpeedAct.Size = new System.Drawing.Size(187, 32);
            this.txtSpeedAct.TabIndex = 4;
            this.txtSpeedAct.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // butt_SetSpeed
            // 
            this.butt_SetSpeed.Location = new System.Drawing.Point(12, 256);
            this.butt_SetSpeed.Name = "butt_SetSpeed";
            this.butt_SetSpeed.Size = new System.Drawing.Size(187, 40);
            this.butt_SetSpeed.TabIndex = 5;
            this.butt_SetSpeed.Text = "Hızı Güncelle";
            this.butt_SetSpeed.UseVisualStyleBackColor = true;
            this.butt_SetSpeed.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(220, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Güncel Motor Hızı [RPM]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 307);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butt_SetSpeed);
            this.Controls.Add(this.txtSpeedAct);
            this.Controls.Add(this.txtSpeedRef);
            this.Controls.Add(this.butt_close);
            this.Controls.Add(this.butt_open);
            this.Controls.Add(this.butt_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC Kontrol Uygulaması 2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butt_connect;
        private System.Windows.Forms.Button butt_open;
        private System.Windows.Forms.Button butt_close;
        private System.Windows.Forms.TextBox txtSpeedRef;
        private System.Windows.Forms.TextBox txtSpeedAct;
        private System.Windows.Forms.Button butt_SetSpeed;
        private System.Windows.Forms.Label label1;
    }
}

