using System;

namespace TPArticlesFournisseurs
{
    public class Fournisseur
    {
        private int num;
        private string nom;
        private string ville;
        private int qte;

        private static int nbF = 0;

        public Fournisseur (string nom, string ville)
        {
            this.nom = nom;
            this.ville = ville;
            this.qte = 0;
            Fournisseur.nbF += 1;
            this.num = nbF;
        }

        public Fournisseur (string nom, string ville, int qte)
        {
            this.nom = nom;
            this.ville = ville;
            this.qte = qte;
            Fournisseur.nbF += 1;
            this.num = nbF;
        }

        public void Livrer(int qte)
        {
            this.qte -= qte;
        }

        public int GetQuantite()
        {
            return qte;
        }

        public override string ToString()
        {
            return "Fournisseur [" + nom + "] Quantite [" + qte + "] Ville [ " + ville + "] Numéro [" + num + "]";
        }
    }
}