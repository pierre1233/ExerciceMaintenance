using System;

namespace Lanceur
{
    public static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Bienvenue sur le Minitel de la compagnie de chemin de fer de Poldévie !");

            var restart = true;
            while (restart)
            {
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1 - S'inscrire");
                Console.WriteLine("2 - Réserver un billet");
                Console.WriteLine("3 - Liste des billets");
                Console.WriteLine("0 - Quitter");

                switch (short.Parse(Console.ReadLine()))
                {
                    case 0:
                        restart = false;
                        break;
                    case 1:
                        EnregistrementVoyageur.Program.Main();
                        break;
                    case 2:
                        GestionRéservations.Program.Main();
                        break;
                    case 3:
                        ListeBillets.Program.Main();
                        break;
                    default:
                        Console.WriteLine("Erreur de sésie.");
                        break;
                }
            }
        }
    }
}
