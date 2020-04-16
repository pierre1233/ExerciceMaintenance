using System;
using CentralTrainDB;

namespace GestionRéservations
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Bienvenue sur le système de réservation de billet.");

            Console.WriteLine("Identifiée vous.");

            var identifier = Console.ReadLine();
            var user = UserProvider.GetUser(identifier);

            Console.WriteLine("Saisissez le numéro de train à réservé");
            var noTrain = int.Parse(Console.ReadLine());

            var nbBillets = demanderNombreBillets();

            var train = Train.FetchById(noTrain);
            if (!train.HasSeatsAvailable())
            {
                Console.WriteLine("Train complet");
                return;
            }

            var reservations = train.BookSeats(user, nbBillets);
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Réservation {reservation} confirmée");
            }
        }

        private static int demanderNombreBillets()
        {
            int nbBillets = 0;

            do
            {
                Console.WriteLine("Combien de billets ?");
                nbBillets = short.Parse(Console.ReadLine());
            } while (nbBillets > 4);

            return nbBillets;
        }
    }
}