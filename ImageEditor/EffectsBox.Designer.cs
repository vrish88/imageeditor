namespace ImageEditor
{
    partial class EffectsBox
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
            this.affectedImage = new System.Windows.Forms.PictureBox();
            this.apply = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.affectedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // affectedImage
            // 
            this.affectedImage.Location = new System.Drawing.Point(22, 18);
            this.affectedImage.Name = "affectedImage";
            this.affectedImage.Size = new System.Drawing.Size(305, 260);
            this.affectedImage.TabIndex = 0;
            this.affectedImage.TabStop = false;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(348, 18);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 1;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(348, 47);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // EffectsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 299);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.affectedImage);
            this.Name = "EffectsBox";
            this.Text = "EffectsBox";
            ((System.ComponentModel.ISupportInitialize)(this.affectedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox affectedImage;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button cancel;
    }
}