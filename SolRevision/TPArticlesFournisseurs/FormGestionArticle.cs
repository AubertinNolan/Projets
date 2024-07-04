using System;
using System.Windows.Forms;

namespace TPArticlesFournisseurs
{
    public partial class FormGestionArticle : Form
    {
        public FormGestionArticle()
        {
            InitializeComponent();
            AppliGestionArticle.initJeuEssai();
        }

        private void btAfficherArticles_Click(object sender, EventArgs e)
        {
            // Affichage de tous les articles de l'application et donc ceux récupérés de la
            // classe AppliGestionArticle

            //en commentaire car AddRange ci-dessous permet d'éviter la boucle
            foreach (Article a in AppliGestionArticle.GetArticles())
            {
                listBArticles.Items.Add(a);
            }
            ActualiserListeArticle();
        }

        private void ActualiserListeArticle()
        {
            listBArticles.Items.Clear();
            listBArticles.Items.AddRange(AppliGestionArticle.GetArticles().ToArray());
        }

        private void ActualiserListeFournisseur(Article a)
        {
            listBFournisseurs.Items.Clear();
            listBFournisseurs.Items.AddRange(AppliGestionArticle.GetFournisseursSArticle(a).ToArray());
        }

        /// <summary>
        /// Teste si un article et un fournisseur sont bien sélectionnés
        /// dans les listeBox listBArticles et listBFournisseurs. Teste si une quantité > 0
        /// a bien été saisie et approvisionne (en appelant la méthode Approvisonner de la classe
        /// AppliGestionArticle ) l'article sélectionné dans la listox listBArticles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btApprovisionner_Click(object sender, EventArgs e)
        {
            bool convertOK;
            Article a = (Article)listBArticles.SelectedItem;
            Fournisseur f = (Fournisseur)listBFournisseurs.SelectedItem;
            int qte;
            convertOK = int.TryParse(txtQteApprovisonner.Text, out qte);

            if (a == null)
            {
                MessageBox.Show(" Aucun article sélectionné ");
            }
            else if (f == null)
            {
                MessageBox.Show(" Aucun fournisseur sélectionné ");
            }
            else if (!convertOK)
            {
                MessageBox.Show(" La quantité saisie doit être un entier ");
            }
            else if (qte <= 0)
            {
                MessageBox.Show(" La quantité à approvisionner doit être supérieure à 0 ");
            }

            else
            {    
                if(AppliGestionArticle.Approvisionner(a, f, qte))
                {
                    MessageBox.Show(" Le fournisseur a bien livré le nombre d'articles saisi ");
                    ActualiserListeArticle();
                    ActualiserListeFournisseur(a);
                }
                else
                {
                    MessageBox.Show(" Le fournisseur n'a pas la quantite saisie en stock ");
                }

            }

        }
        /// <summary>
        /// Affiche les fournisseurs de l'article sélectionné dans la listeBox ListBFournisseurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBFournisseurs.Items.Clear();
            Article a = (Article) listBArticles.SelectedItem;
            listBFournisseurs.Items.AddRange(AppliGestionArticle.GetFournisseursSArticle(a).ToArray());
        }
        /// <summary>
        /// Vend l'article sélectionné dans la listBArticles avec une quantité saisie >0
        /// dans txtQteVendre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btVendre_Click(object sender, EventArgs e)
        {
            Article a = (Article)listBArticles.SelectedItem;
            int qte;
            //qte = int.Parse(txtQteVendre.Text);
            bool approvisionner, convertOK;
            convertOK = int.TryParse(txtQteVendre.Text, out qte);

            if (!convertOK)
            {
                MessageBox.Show(" La quantite saisie doit être un entier ");
            }
            else if (a == null)
            {
                MessageBox.Show(" Aucun article sélectionné ");
            }
            else if (qte <= 0)
            {
                MessageBox.Show(" La quantité de l'article est à 0 ");
            }
            
            else
            {
                // Tout est ok donc ->
                approvisionner = AppliGestionArticle.Vendre(a, qte);

                if (approvisionner)
                {
                    MessageBox.Show(" L'article a bien été vendu. ");
                    ActualiserListeArticle();
                }
                else
                {
                    MessageBox.Show(" L'article n'est pas suffisamment approvisionné ");
                }
            }
        }

        private void BtAjouterFournisseur_Click(object sender, EventArgs e)
        {
            Article a = (Article)listBArticles.SelectedItem;
            
            if (a == null)
            {
                MessageBox.Show(" Aucun article sélectionné ");
            }
            else if (String.IsNullOrEmpty(txtNomFournisseur.Text) || String.IsNullOrEmpty(txtVille.Text)) 
            {
                MessageBox.Show(" Veuillez remplir le nom et la ville du fournisseur ");
            }
            else
            {
                Fournisseur f = new Fournisseur(txtNomFournisseur.Text, txtVille.Text);
                a.AjouterFournisseur(f);
                ActualiserListeFournisseur(a);
            }
        }

        private void btAjouterArticle_Click(object sender, EventArgs e)
        {
            int Prix;
            bool convertOK;
            convertOK = int.TryParse(tbPrixArticle.Text, out Prix);

            if (!convertOK)
            {
                MessageBox.Show(" La quantite saisie doit être un entier ");
            }
            else if (Prix < 0)
            {
                MessageBox.Show(" La quantite saisie doit être supérieure ou égale à 0 ");
            }
            else if (String.IsNullOrEmpty(tbNomArticle.Text))
            {
                MessageBox.Show(" Veuillez remplir le nom de l'article ");
            }
            else
            {
                Article a = new Article(tbNomArticle.Text, Prix);
                AppliGestionArticle.AjouterArticle(a);
                ActualiserListeArticle();
            }            
        }
    }
}
