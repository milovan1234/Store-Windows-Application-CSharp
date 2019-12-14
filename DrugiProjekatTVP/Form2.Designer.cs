namespace DrugiProjekatTVP
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblUpitnik = new System.Windows.Forms.Label();
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNe = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUpitnik
            // 
            this.lblUpitnik.AutoSize = true;
            this.lblUpitnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpitnik.Location = new System.Drawing.Point(80, 48);
            this.lblUpitnik.Name = "lblUpitnik";
            this.lblUpitnik.Size = new System.Drawing.Size(23, 16);
            this.lblUpitnik.TabIndex = 0;
            this.lblUpitnik.Text = ".....";
            // 
            // btnDa
            // 
            this.btnDa.BackColor = System.Drawing.SystemColors.Control;
            this.btnDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDa.Location = new System.Drawing.Point(40, 9);
            this.btnDa.Name = "btnDa";
            this.btnDa.Size = new System.Drawing.Size(97, 31);
            this.btnDa.TabIndex = 1;
            this.btnDa.Text = "DA";
            this.btnDa.UseVisualStyleBackColor = false;
            this.btnDa.Click += new System.EventHandler(this.btnDa_Click);
            // 
            // btnNe
            // 
            this.btnNe.BackColor = System.Drawing.SystemColors.Control;
            this.btnNe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNe.Location = new System.Drawing.Point(307, 9);
            this.btnNe.Name = "btnNe";
            this.btnNe.Size = new System.Drawing.Size(97, 31);
            this.btnNe.TabIndex = 2;
            this.btnNe.Text = "NE";
            this.btnNe.UseVisualStyleBackColor = false;
            this.btnNe.Click += new System.EventHandler(this.btnNe_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnNe);
            this.panel1.Controls.Add(this.btnDa);
            this.panel1.Location = new System.Drawing.Point(-3, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 47);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DrugiProjekatTVP.Properties.Resources.Icojam_Blue_Bits_Question_faq;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(34, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 33);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(432, 162);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUpitnik);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpitnik;
        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}