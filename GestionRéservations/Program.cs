using System;
using CentralTrainDB;

namespace GestionRéservations
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Bienvenus sur le système de réservation de billet.");

            Console.WriteLine("Identifiée vous.");

            var identifier = Console.ReadLine();
            var user = UserProvider.GetUser(identifier);

            Console.WriteLine("Saisissez le numéro de train à réservé");
            var noTrain = int.Parse(Console.ReadLine());

            Console.WriteLine("Combien de billets ?");
            var nbBillets = short.Parse(Console.ReadLine());

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
    }
}
