namespace CopasFora.Forms
{
    partial class Teste
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnMostraJogador = new System.Windows.Forms.Button();
            this.txtJogador = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Mostra Carta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMostraJogador
            // 
            this.btnMostraJogador.Location = new System.Drawing.Point(169, 209);
            this.btnMostraJogador.Name = "btnMostraJogador";
            this.btnMostraJogador.Size = new System.Drawing.Size(93, 23);
            this.btnMostraJogador.TabIndex = 2;
            this.btnMostraJogador.Text = "Mostra Jogador";
            this.btnMostraJogador.UseVisualStyleBackColor = true;
            this.btnMostraJogador.Click += new System.EventHandler(this.btnMostraJogador_Click);
            // 
            // txtJogador
            // 
            this.txtJogador.Location = new System.Drawing.Point(12, 212);
            this.txtJogador.Name = "txtJogador";
            this.txtJogador.Size = new System.Drawing.Size(151, 20);
            this.txtJogador.TabIndex = 3;
            // 
            // Teste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.txtJogador);
            this.Controls.Add(this.btnMostraJogador);
            this.Controls.Add(this.button1);
            this.Name = "Teste";
            this.Text = "Teste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMostraJogador;
        private System.Windows.Forms.TextBox txtJogador;
    }
}