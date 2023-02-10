namespace AppPlayKaraoke_WithVideo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelNumber = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtKaraoke1 = new System.Windows.Forms.RichTextBox();
            this.txtKaraoke2 = new System.Windows.Forms.RichTextBox();
            this.media = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.media)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 49.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumber.ForeColor = System.Drawing.Color.Lime;
            this.labelNumber.Location = new System.Drawing.Point(57, 597);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(88, 95);
            this.labelNumber.TabIndex = 2;
            this.labelNumber.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtKaraoke1
            // 
            this.txtKaraoke1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtKaraoke1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKaraoke1.Font = new System.Drawing.Font("Times New Roman", 64.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKaraoke1.ForeColor = System.Drawing.SystemColors.Info;
            this.txtKaraoke1.Location = new System.Drawing.Point(56, 677);
            this.txtKaraoke1.Name = "txtKaraoke1";
            this.txtKaraoke1.Size = new System.Drawing.Size(1890, 145);
            this.txtKaraoke1.TabIndex = 3;
            this.txtKaraoke1.Text = "Gửi cho đọt mướp";
            // 
            // txtKaraoke2
            // 
            this.txtKaraoke2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtKaraoke2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKaraoke2.Font = new System.Drawing.Font("Times New Roman", 64.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKaraoke2.ForeColor = System.Drawing.SystemColors.Info;
            this.txtKaraoke2.Location = new System.Drawing.Point(1003, 781);
            this.txtKaraoke2.Name = "txtKaraoke2";
            this.txtKaraoke2.Size = new System.Drawing.Size(1890, 161);
            this.txtKaraoke2.TabIndex = 4;
            this.txtKaraoke2.Text = "luống cà và bụi bông";
            // 
            // media
            // 
            this.media.Enabled = true;
            this.media.Location = new System.Drawing.Point(81, 5);
            this.media.Name = "media";
            this.media.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("media.OcxState")));
            this.media.Size = new System.Drawing.Size(1357, 610);
            this.media.TabIndex = 0;
            this.media.Enter += new System.EventHandler(this.media_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1469, 947);
            this.Controls.Add(this.txtKaraoke2);
            this.Controls.Add(this.txtKaraoke1);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.media);
            this.Name = "Form1";
            this.Text = "App Play Karaoke - With Video";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.media)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer media;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox txtKaraoke1;
        private System.Windows.Forms.RichTextBox txtKaraoke2;
    }
}

