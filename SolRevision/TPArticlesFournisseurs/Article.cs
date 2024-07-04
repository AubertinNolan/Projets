using System;
using System.Collections.Generic;

namespace TPArticlesFournisseurs
{
    public class Article
    {
        private int num;
        private string nom;
        private int qte;
        private int prixVente;

        private List<Fournisseur> lesFournisseurs;

        private static int nbArticle = 0;

        public Article (string nom, int prixVente)
        {
            Article.nbArticle += 1;
            this.nom = nom;
            qte = 0;
            this.prixVente = prixVente;
            lesFournisseurs = new List<Fournisseur>();
            this.num = nbArticle;
            
        }
        public void AjouterFournisseur(Fournisseur f)
        {
            lesFournisseurs.Add(f);
        }
        public bool Vendre(int qte)
        {
           if(qte <= this.qte)
           {
                this.qte -= qte;
                //this.qte = this.qte - qte; // autre manière de faire une soustraction
                return true;
                
           }
            else
            {
                return false;
            }
        }
        public List<Fournisseur> GetFournisseurs()
        {
            return lesFournisseurs; // les fournisseurs de l'objet
            
        }

        public void Approvisionner(int qte)
        {
            this.qte += qte;
        }
        public override string ToString()
        {
            return "Num [" + num + "] Nom [" + nom + "] Quantité [" + qte + "] Prix [" + prixVente + "]";
        }
    }
}