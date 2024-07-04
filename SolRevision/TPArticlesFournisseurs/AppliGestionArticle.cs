using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPArticlesFournisseurs
{
    public static class AppliGestionArticle // classe static :  tous les attributs et toutes lesméthodes
                                               // sont obligatoirement static donc dépendent
                                               // de la classe et non de l'objet
    {

        private static List<Article> listeArticles = new List<Article>(); // Depend de la classe et non 
                                                                            //de l'objet

        // Créer un jeu d'essai.
        // Donc initialise la collection listeArticles avec différents objets Article qui contiendront chacun 1 ou plusieurs fournisseurs
        public static void initJeuEssai()
        {
            
            Article a1, a2, a0;
            Fournisseur f1, f2, f3, f4, f5;
            a1 = new Article("a1", 10);
            a2 = new Article("a2", 20);
            a0 = new Article("a0", 30);
            listeArticles.Add(a1);
            listeArticles.Add(a2);
            listeArticles.Add(a0);

            f1 = new Fournisseur("f1","v1");
            f2 = new Fournisseur("f2","v2");
            f3 = new Fournisseur("f3", "v3");

            f4 = new Fournisseur("f4", "v4", 20);
            f5 = new Fournisseur("f4", "v4", 5);

            a1.AjouterFournisseur(f1);

            a2.AjouterFournisseur(f1);
            a2.AjouterFournisseur(f2);

            a0.AjouterFournisseur(f4);
            a1.AjouterFournisseur(f5);





        }

        // <param name="a"> article qui est approvisionné</param>
        // <param name="f"> inutile</param>
        // <param name="qte"> quantité de l'article qui est approvisonné</param>
        public static bool Approvisionner(Article a, Fournisseur f, int qte)
        {
            if(f.GetQuantite() >= 0)
            {
                a.Approvisionner(qte); // Article r'ajouter en quantité
                f.Livrer(qte); // Fournisseur soustrait en quantité
                return true;
            }
            else
            {
                return false;
            }
                       

        }
        public static bool Vendre(Article a, int qte)
        {
            return a.Vendre(qte);
        }

        public static List<Article> GetArticles()
        {
            // renvoie la liste des articles de cette classe donc de l'application
            return AppliGestionArticle.listeArticles;
        }
        public static List<Fournisseur> GetFournisseursSArticle(Article a)
        {
            List<Fournisseur> listef = new List<Fournisseur>();
            listef.AddRange(a.GetFournisseurs());

            return listef;
        }
        public static void AjouterArticle(Article a)
        {
            listeArticles.Add(a);
        }
    }
}
