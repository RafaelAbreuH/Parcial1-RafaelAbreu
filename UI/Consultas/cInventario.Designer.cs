namespace ProyectoParcial.UI.Consultas
{
    partial class cInventario
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
            this.SyncedTotaltextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Syncbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SyncedTotaltextBox
            // 
            this.SyncedTotaltextBox.Location = new System.Drawing.Point(6, 42);
            this.SyncedTotaltextBox.Name = "SyncedTotaltextBox";
            this.SyncedTotaltextBox.ReadOnly = true;
            this.SyncedTotaltextBox.Size = new System.Drawing.Size(171, 22);
            this.SyncedTotaltextBox.TabIndex = 0;
            this.SyncedTotaltextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Syncbutton);
            this.groupBox1.Controls.Add(this.SyncedTotaltextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valor total en Inventario";
            // 
            // Syncbutton
            // 
            this.Syncbutton.Image = global::ProyectoParcial.Properties.Resources.sinchronize_32;
            this.Syncbutton.Location = new System.Drawing.Point(183, 32);
            this.Syncbutton.Name = "Syncbutton";
            this.Syncbutton.Size = new System.Drawing.Size(57, 43);
            this.Syncbutton.TabIndex = 1;
            this.Syncbutton.UseVisualStyleBackColor = true;
            this.Syncbutton.Click += new System.EventHandler(this.Syncbutton_Click);
            // 
            // cInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 140);
            this.Controls.Add(this.groupBox1);
            this.Name = "cInventario";
            this.Text = "Consulta Inventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox SyncedTotaltextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Syncbutton;
    }
}