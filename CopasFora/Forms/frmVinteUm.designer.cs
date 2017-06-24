namespace CopasFora.Forms
{
    partial class frmVinteUm
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
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lvCartas = new System.Windows.Forms.ListView();
            this.cartas = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPontos = new System.Windows.Forms.Label();
            this.lblMao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPassar = new System.Windows.Forms.Button();
            this.lblPontosComput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvCartasComput = new System.Windows.Forms.ListView();
            this.cartas_comput = new System.Windows.Forms.ColumnHeader();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pnlCartas = new System.Windows.Forms.Panel();
            this.lblPicName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(635, 302);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(125, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(635, 396);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(125, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lvCartas
            // 
            this.lvCartas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cartas});
            this.lvCartas.FullRowSelect = true;
            this.lvCartas.GridLines = true;
            this.lvCartas.Location = new System.Drawing.Point(415, 44);
            this.lvCartas.Name = "lvCartas";
            this.lvCartas.Size = new System.Drawing.Size(143, 194);
            this.lvCartas.TabIndex = 2;
            this.lvCartas.UseCompatibleStateImageBehavior = false;
            this.lvCartas.View = System.Windows.Forms.View.Details;
            // 
            // cartas
            // 
            this.cartas.Text = "SUAS CARTAS";
            this.cartas.Width = 137;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(394, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seus pontos:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPontos
            // 
            this.lblTotalPontos.Location = new System.Drawing.Point(500, 241);
            this.lblTotalPontos.Name = "lblTotalPontos";
            this.lblTotalPontos.Size = new System.Drawing.Size(58, 20);
            this.lblTotalPontos.TabIndex = 4;
            this.lblTotalPontos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMao
            // 
            this.lblMao.Location = new System.Drawing.Point(551, 9);
            this.lblMao.Name = "lblMao";
            this.lblMao.Size = new System.Drawing.Size(126, 20);
            this.lblMao.TabIndex = 6;
            this.lblMao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(445, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mão:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPassar
            // 
            this.btnPassar.Location = new System.Drawing.Point(635, 331);
            this.btnPassar.Name = "btnPassar";
            this.btnPassar.Size = new System.Drawing.Size(125, 23);
            this.btnPassar.TabIndex = 7;
            this.btnPassar.Text = "Passa a Vez";
            this.btnPassar.UseVisualStyleBackColor = true;
            this.btnPassar.Click += new System.EventHandler(this.btnPassar_Click);
            // 
            // lblPontosComput
            // 
            this.lblPontosComput.Location = new System.Drawing.Point(657, 241);
            this.lblPontosComput.Name = "lblPontosComput";
            this.lblPontosComput.Size = new System.Drawing.Size(56, 20);
            this.lblPontosComput.TabIndex = 9;
            this.lblPontosComput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(551, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pontos Comput:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvCartasComput
            // 
            this.lvCartasComput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cartas_comput});
            this.lvCartasComput.FullRowSelect = true;
            this.lvCartasComput.GridLines = true;
            this.lvCartasComput.Location = new System.Drawing.Point(570, 44);
            this.lvCartasComput.Name = "lvCartasComput";
            this.lvCartasComput.Size = new System.Drawing.Size(143, 194);
            this.lvCartasComput.TabIndex = 10;
            this.lvCartasComput.UseCompatibleStateImageBehavior = false;
            this.lvCartasComput.View = System.Windows.Forms.View.Details;
            // 
            // cartas_comput
            // 
            this.cartas_comput.Text = "CARTAS / COMPUT";
            this.cartas_comput.Width = 137;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(635, 367);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(125, 23);
            this.btnNewGame.TabIndex = 11;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // pnlCartas
            // 
            this.pnlCartas.Location = new System.Drawing.Point(12, 44);
            this.pnlCartas.Name = "pnlCartas";
            this.pnlCartas.Size = new System.Drawing.Size(378, 194);
            this.pnlCartas.TabIndex = 21;
            // 
            // lblPicName
            // 
            this.lblPicName.Location = new System.Drawing.Point(195, 273);
            this.lblPicName.Name = "lblPicName";
            this.lblPicName.Size = new System.Drawing.Size(175, 29);
            this.lblPicName.TabIndex = 22;
            this.lblPicName.Text = "label2";
            // 
            // frmVinteUm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 430);
            this.Controls.Add(this.lblPicName);
            this.Controls.Add(this.pnlCartas);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lvCartasComput);
            this.Controls.Add(this.lblPontosComput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPassar);
            this.Controls.Add(this.lblMao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalPontos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCartas);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnContinuar);
            this.Name = "frmVinteUm";
            this.Text = "Jogo de Vinte e Um - Jogar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ListView lvCartas;
        private System.Windows.Forms.ColumnHeader cartas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPontos;
        private System.Windows.Forms.Label lblMao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPassar;
        private System.Windows.Forms.Label lblPontosComput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvCartasComput;
        private System.Windows.Forms.ColumnHeader cartas_comput;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel pnlCartas;
        private System.Windows.Forms.Label lblPicName;
    }
}