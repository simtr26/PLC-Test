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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butt_connect
            // 
            this.butt_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_connect.Location = new System.Drawing.Point(16, 15);
            this.butt_connect.Margin = new System.Windows.Forms.Padding(4);
            this.butt_connect.Name = "butt_connect";
            this.butt_connect.Size = new System.Drawing.Size(519, 119);
            this.butt_connect.TabIndex = 0;
            this.butt_connect.Text = "BAĞLA";
            this.butt_connect.UseVisualStyleBackColor = true;
            this.butt_connect.Click += new System.EventHandler(this.butt_connect_Click);
            // 
            // butt_open
            // 
            this.butt_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_open.Location = new System.Drawing.Point(16, 142);
            this.butt_open.Margin = new System.Windows.Forms.Padding(4);
            this.butt_open.Name = "butt_open";
            this.butt_open.Size = new System.Drawing.Size(249, 119);
            this.butt_open.TabIndex = 1;
            this.butt_open.Text = "AÇ";
            this.butt_open.UseVisualStyleBackColor = true;
            this.butt_open.Click += new System.EventHandler(this.butt_open_Click);
            // 
            // butt_close
            // 
            this.butt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_close.Location = new System.Drawing.Point(285, 142);
            this.butt_close.Margin = new System.Windows.Forms.Padding(4);
            this.butt_close.Name = "butt_close";
            this.butt_close.Size = new System.Drawing.Size(249, 119);
            this.butt_close.TabIndex = 2;
            this.butt_close.Text = "KAPAT";
            this.butt_close.UseVisualStyleBackColor = true;
            this.butt_close.Click += new System.EventHandler(this.butt_close_Click);
            // 
            // txtSpeedRef
            // 
            this.txtSpeedRef.Location = new System.Drawing.Point(285, 314);
            this.txtSpeedRef.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpeedRef.Multiline = true;
            this.txtSpeedRef.Name = "txtSpeedRef";
            this.txtSpeedRef.ReadOnly = true;
            this.txtSpeedRef.Size = new System.Drawing.Size(248, 47);
            this.txtSpeedRef.TabIndex = 3;
            this.txtSpeedRef.TextChanged += new System.EventHandler(this.txtSpeedAct_TextChanged);
            // 
            // txtSpeedAct
            // 
            this.txtSpeedAct.Location = new System.Drawing.Point(16, 277);
            this.txtSpeedAct.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpeedAct.Name = "txtSpeedAct";
            this.txtSpeedAct.Size = new System.Drawing.Size(248, 22);
            this.txtSpeedAct.TabIndex = 4;
            this.txtSpeedAct.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // butt_SetSpeed
            // 
            this.butt_SetSpeed.Location = new System.Drawing.Point(16, 314);
            this.butt_SetSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.butt_SetSpeed.Name = "butt_SetSpeed";
            this.butt_SetSpeed.Size = new System.Drawing.Size(249, 49);
            this.butt_SetSpeed.TabIndex = 5;
            this.butt_SetSpeed.Text = "Hızı Güncelle";
            this.butt_SetSpeed.UseVisualStyleBackColor = true;
            this.butt_SetSpeed.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(300, 277);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Güncel Motor Hızı [RPM]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(16, 452);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 119);
            this.button1.TabIndex = 7;
            this.button1.Text = "MOTOR YÖNÜ GERİ AL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(49, 396);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Güncel Motor Yönü:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(251, 396);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "....";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(311, 452);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 119);
            this.button2.TabIndex = 10;
            this.button2.Text = "MOTOR YÖNÜ İLERİ AL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 584);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butt_SetSpeed);
            this.Controls.Add(this.txtSpeedAct);
            this.Controls.Add(this.txtSpeedRef);
            this.Controls.Add(this.butt_close);
            this.Controls.Add(this.butt_open);
            this.Controls.Add(this.butt_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

