namespace CopasFora.Forms
{
    partial class frmMDIForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paciênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suecaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vinteEUmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pockerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivosToolStripMenuItem,
            this.testeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivosToolStripMenuItem
            // 
            this.arquivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copasToolStripMenuItem,
            this.paciênciaToolStripMenuItem,
            this.suecaToolStripMenuItem,
            this.vinteEUmToolStripMenuItem,
            this.pockerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivosToolStripMenuItem.Name = "arquivosToolStripMenuItem";
            this.arquivosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.arquivosToolStripMenuItem.Text = "Arquivos";
            // 
            // copasToolStripMenuItem
            // 
            this.copasToolStripMenuItem.Name = "copasToolStripMenuItem";
            this.copasToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.copasToolStripMenuItem.Text = "Copas";
            this.copasToolStripMenuItem.Click += new System.EventHandler(this.copasToolStripMenuItem_Click);
            // 
            // paciênciaToolStripMenuItem
            // 
            this.paciênciaToolStripMenuItem.Name = "paciênciaToolStripMenuItem";
            this.paciênciaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.paciênciaToolStripMenuItem.Text = "Paciência";
            // 
            // suecaToolStripMenuItem
            // 
            this.suecaToolStripMenuItem.Name = "suecaToolStripMenuItem";
            this.suecaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.suecaToolStripMenuItem.Text = "Sueca";
            // 
            // vinteEUmToolStripMenuItem
            // 
            this.vinteEUmToolStripMenuItem.Name = "vinteEUmToolStripMenuItem";
            this.vinteEUmToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.vinteEUmToolStripMenuItem.Text = "Vinte e Um";
            // 
            // pockerToolStripMenuItem
            // 
            this.pockerToolStripMenuItem.Name = "pockerToolStripMenuItem";
            this.pockerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.pockerToolStripMenuItem.Text = "Pocker";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.testeToolStripMenuItem.Text = "Teste";
            this.testeToolStripMenuItem.Click += new System.EventHandler(this.testeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 242);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copas - Formulário Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDIForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paciênciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suecaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vinteEUmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pockerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
    }
}

