namespace TPArticlesFournisseurs
{
    partial class FormGestionArticle
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBArticles = new System.Windows.Forms.ListBox();
            this.listBFournisseurs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQteVendre = new System.Windows.Forms.TextBox();
            this.btVendre = new System.Windows.Forms.Button();
            this.txtQteApprovisonner = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btApprovisonner = new System.Windows.Forms.Button();
            this.btAfficherArticles = new System.Windows.Forms.Button();
            this.BtAjouterFournisseur = new System.Windows.Forms.Button();
            this.txtNomFournisseur = new System.Windows.Forms.TextBox();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNomArticle = new System.Windows.Forms.TextBox();
            this.tbPrixArticle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btAjouterArticle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBArticles
            // 
            this.listBArticles.FormattingEnabled = true;
            this.listBArticles.Location = new System.Drawing.Point(39, 12);
            this.listBArticles.Name = "listBArticles";
            this.listBArticles.Size = new System.Drawing.Size(233, 173);
            this.listBArticles.TabIndex = 0;
            this.listBArticles.SelectedIndexChanged += new System.EventHandler(this.listBArticles_SelectedIndexChanged);
            // 
            // listBFournisseurs
            // 
            this.listBFournisseurs.FormattingEnabled = true;
            this.listBFournisseurs.Location = new System.Drawing.Point(436, 12);
            this.listBFournisseurs.Name = "listBFournisseurs";
            this.listBFournisseurs.Size = new System.Drawing.Size(216, 173);
            this.listBFournisseurs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantité";
            // 
            // txtQteVendre
            // 
            this.txtQteVendre.Location = new System.Drawing.Point(200, 322);
            this.txtQteVendre.Name = "txtQteVendre";
            this.txtQteVendre.Size = new System.Drawing.Size(98, 20);
            this.txtQteVendre.TabIndex = 3;
            // 
            // btVendre
            // 
            this.btVendre.Location = new System.Drawing.Point(199, 348);
            this.btVendre.Name = "btVendre";
            this.btVendre.Size = new System.Drawing.Size(99, 23);
            this.btVendre.TabIndex = 4;
            this.btVendre.Text = "Vendre";
            this.btVendre.UseVisualStyleBackColor = true;
            this.btVendre.Click += new System.EventHandler(this.btVendre_Click);
            // 
            // txtQteApprovisonner
            // 
            this.txtQteApprovisonner.Location = new System.Drawing.Point(357, 322);
            this.txtQteApprovisonner.Name = "txtQteApprovisonner";
            this.txtQteApprovisonner.Size = new System.Drawing.Size(100, 20);
            this.txtQteApprovisonner.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantité";
            // 
            // btApprovisonner
            // 
            this.btApprovisonner.Location = new System.Drawing.Point(357, 348);
            this.btApprovisonner.Name = "btApprovisonner";
            this.btApprovisonner.Size = new System.Drawing.Size(100, 23);
            this.btApprovisonner.TabIndex = 7;
            this.btApprovisonner.Text = "Approvisionner";
            this.btApprovisonner.UseVisualStyleBackColor = true;
            this.btApprovisonner.Click += new System.EventHandler(this.btApprovisionner_Click);
            // 
            // btAfficherArticles
            // 
            this.btAfficherArticles.Location = new System.Drawing.Point(284, 12);
            this.btAfficherArticles.Name = "btAfficherArticles";
            this.btAfficherArticles.Size = new System.Drawing.Size(146, 23);
            this.btAfficherArticles.TabIndex = 8;
            this.btAfficherArticles.Text = "Afficher tous les articles";
            this.btAfficherArticles.UseVisualStyleBackColor = true;
            this.btAfficherArticles.Click += new System.EventHandler(this.btAfficherArticles_Click);
            // 
            // BtAjouterFournisseur
            // 
            this.BtAjouterFournisseur.Location = new System.Drawing.Point(483, 243);
            this.BtAjouterFournisseur.Name = "BtAjouterFournisseur";
            this.BtAjouterFournisseur.Size = new System.Drawing.Size(169, 23);
            this.BtAjouterFournisseur.TabIndex = 9;
            this.BtAjouterFournisseur.Text = "Ajouter fournisseur";
            this.BtAjouterFournisseur.UseVisualStyleBackColor = true;
            this.BtAjouterFournisseur.Click += new System.EventHandler(this.BtAjouterFournisseur_Click);
            // 
            // txtNomFournisseur
            // 
            this.txtNomFournisseur.Location = new System.Drawing.Point(483, 191);
            this.txtNomFournisseur.Name = "txtNomFournisseur";
            this.txtNomFournisseur.Size = new System.Drawing.Size(169, 20);
            this.txtNomFournisseur.TabIndex = 10;
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(483, 217);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(169, 20);
            this.txtVille.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nom Fournisseur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ville";
            // 
            // tbNomArticle
            // 
            this.tbNomArticle.Location = new System.Drawing.Point(103, 194);
            this.tbNomArticle.Name = "tbNomArticle";
            this.tbNomArticle.Size = new System.Drawing.Size(169, 20);
            this.tbNomArticle.TabIndex = 14;
            // 
            // tbPrixArticle
            // 
            this.tbPrixArticle.Location = new System.Drawing.Point(103, 217);
            this.tbPrixArticle.Name = "tbPrixArticle";
            this.tbPrixArticle.Size = new System.Drawing.Size(169, 20);
            this.tbPrixArticle.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nom Article";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Prix de vente";
            // 
            // btAjouterArticle
            // 
            this.btAjouterArticle.Location = new System.Drawing.Point(103, 243);
            this.btAjouterArticle.Name = "btAjouterArticle";
            this.btAjouterArticle.Size = new System.Drawing.Size(169, 23);
            this.btAjouterArticle.TabIndex = 18;
            this.btAjouterArticle.Text = "Ajouter article";
            this.btAjouterArticle.UseVisualStyleBackColor = true;
            this.btAjouterArticle.Click += new System.EventHandler(this.btAjouterArticle_Click);
            // 
            // FormGestionArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 385);
            this.Controls.Add(this.btAjouterArticle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPrixArticle);
            this.Controls.Add(this.tbNomArticle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVille);
            this.Controls.Add(this.txtNomFournisseur);
            this.Controls.Add(this.BtAjouterFournisseur);
            this.Controls.Add(this.btAfficherArticles);
            this.Controls.Add(this.btApprovisonner);
            this.Controls.Add(this.txtQteApprovisonner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btVendre);
            this.Controls.Add(this.txtQteVendre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBFournisseurs);
            this.Controls.Add(this.listBArticles);
            this.Name = "FormGestionArticle";
            this.Text = "Form Vente et approvisonnement ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBArticles;
        private System.Windows.Forms.ListBox listBFournisseurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQteVendre;
        private System.Windows.Forms.Button btVendre;
        private System.Windows.Forms.TextBox txtQteApprovisonner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btApprovisonner;
        private System.Windows.Forms.Button btAfficherArticles;
        private System.Windows.Forms.Button BtAjouterFournisseur;
        private System.Windows.Forms.TextBox txtNomFournisseur;
        private System.Windows.Forms.TextBox txtVille;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNomArticle;
        private System.Windows.Forms.TextBox tbPrixArticle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAjouterArticle;
    }
}

