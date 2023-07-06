
namespace CSV2Class
{
    partial class Converter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonSenzaDati = new System.Windows.Forms.RadioButton();
            this.radioButtonConDati = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.MinimumSize = new System.Drawing.Size(254, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 176);
            this.panel1.TabIndex = 0;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trascina qui il tuo file";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonSenzaDati
            // 
            this.radioButtonSenzaDati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonSenzaDati.AutoSize = true;
            this.radioButtonSenzaDati.Checked = true;
            this.radioButtonSenzaDati.Location = new System.Drawing.Point(22, 194);
            this.radioButtonSenzaDati.Name = "radioButtonSenzaDati";
            this.radioButtonSenzaDati.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSenzaDati.TabIndex = 1;
            this.radioButtonSenzaDati.TabStop = true;
            this.radioButtonSenzaDati.Text = "Senza Dati";
            this.radioButtonSenzaDati.UseVisualStyleBackColor = true;
            this.radioButtonSenzaDati.CheckedChanged += new System.EventHandler(this.radioButtonSenzaDati_CheckedChanged);
            // 
            // radioButtonConDati
            // 
            this.radioButtonConDati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonConDati.AutoSize = true;
            this.radioButtonConDati.Location = new System.Drawing.Point(22, 217);
            this.radioButtonConDati.Name = "radioButtonConDati";
            this.radioButtonConDati.Size = new System.Drawing.Size(66, 17);
            this.radioButtonConDati.TabIndex = 2;
            this.radioButtonConDati.Text = "Con Dati";
            this.radioButtonConDati.UseVisualStyleBackColor = true;
            this.radioButtonConDati.CheckedChanged += new System.EventHandler(this.radioButtonConDati_CheckedChanged);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(281, 265);
            this.Controls.Add(this.radioButtonConDati);
            this.Controls.Add(this.radioButtonSenzaDati);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(297, 304);
            this.Name = "Converter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creatore di Classi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonSenzaDati;
        private System.Windows.Forms.RadioButton radioButtonConDati;
        private System.Windows.Forms.Label label1;
    }
}

