
namespace Teknik_Sevis
{
    partial class frmArizaListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArizaListe));
            this.gridArizaListe = new System.Windows.Forms.DataGridView();
            this.btnAnasayfa = new System.Windows.Forms.Button();
            this.chcTamamlanmisAriza = new System.Windows.Forms.CheckBox();
            this.chcTamamlanmamıs = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridArizaListe)).BeginInit();
            this.SuspendLayout();
            // 
            // gridArizaListe
            // 
            this.gridArizaListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridArizaListe.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridArizaListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArizaListe.Location = new System.Drawing.Point(12, 12);
            this.gridArizaListe.Name = "gridArizaListe";
            this.gridArizaListe.RowHeadersWidth = 51;
            this.gridArizaListe.RowTemplate.Height = 24;
            this.gridArizaListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridArizaListe.Size = new System.Drawing.Size(776, 342);
            this.gridArizaListe.TabIndex = 0;
            // 
            // btnAnasayfa
            // 
            this.btnAnasayfa.BackColor = System.Drawing.Color.White;
            this.btnAnasayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnasayfa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnasayfa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnasayfa.ForeColor = System.Drawing.Color.Black;
            this.btnAnasayfa.Location = new System.Drawing.Point(621, 401);
            this.btnAnasayfa.Name = "btnAnasayfa";
            this.btnAnasayfa.Size = new System.Drawing.Size(167, 37);
            this.btnAnasayfa.TabIndex = 18;
            this.btnAnasayfa.Text = "Anasayfa";
            this.btnAnasayfa.UseVisualStyleBackColor = false;
            this.btnAnasayfa.Click += new System.EventHandler(this.btnAnasayfa_Click);
            // 
            // chcTamamlanmisAriza
            // 
            this.chcTamamlanmisAriza.AutoSize = true;
            this.chcTamamlanmisAriza.BackColor = System.Drawing.Color.Transparent;
            this.chcTamamlanmisAriza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chcTamamlanmisAriza.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chcTamamlanmisAriza.ForeColor = System.Drawing.Color.White;
            this.chcTamamlanmisAriza.Location = new System.Drawing.Point(26, 381);
            this.chcTamamlanmisAriza.Name = "chcTamamlanmisAriza";
            this.chcTamamlanmisAriza.Size = new System.Drawing.Size(264, 33);
            this.chcTamamlanmisAriza.TabIndex = 19;
            this.chcTamamlanmisAriza.Text = "Tamamlanmış Arızalar.";
            this.chcTamamlanmisAriza.UseVisualStyleBackColor = false;
            this.chcTamamlanmisAriza.CheckedChanged += new System.EventHandler(this.chcTamamlanmisAriza_CheckedChanged);
            // 
            // chcTamamlanmamıs
            // 
            this.chcTamamlanmamıs.AutoSize = true;
            this.chcTamamlanmamıs.BackColor = System.Drawing.Color.Transparent;
            this.chcTamamlanmamıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chcTamamlanmamıs.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.chcTamamlanmamıs.ForeColor = System.Drawing.Color.White;
            this.chcTamamlanmamıs.Location = new System.Drawing.Point(320, 381);
            this.chcTamamlanmamıs.Name = "chcTamamlanmamıs";
            this.chcTamamlanmamıs.Size = new System.Drawing.Size(295, 33);
            this.chcTamamlanmamıs.TabIndex = 20;
            this.chcTamamlanmamıs.Text = "Tamamlanmamış Arızalar.";
            this.chcTamamlanmamıs.UseVisualStyleBackColor = false;
            this.chcTamamlanmamıs.CheckedChanged += new System.EventHandler(this.chcTamamlanmamıs_CheckedChanged);
            // 
            // frmArizaListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chcTamamlanmamıs);
            this.Controls.Add(this.chcTamamlanmisAriza);
            this.Controls.Add(this.btnAnasayfa);
            this.Controls.Add(this.gridArizaListe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArizaListe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmArizaListe";
            this.Load += new System.EventHandler(this.frmArizaListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridArizaListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridArizaListe;
        private System.Windows.Forms.Button btnAnasayfa;
        private System.Windows.Forms.CheckBox chcTamamlanmisAriza;
        private System.Windows.Forms.CheckBox chcTamamlanmamıs;
    }
}