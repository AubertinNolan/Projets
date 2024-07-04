using System;
using System.Windows.Forms;

namespace TPArticlesFournisseurs
{
    static class Program
    {
        // Point d'entrée principal de l'application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGestionArticle());
        }
    }
}
