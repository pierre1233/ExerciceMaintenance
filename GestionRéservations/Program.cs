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

        public void AjouterTrain()
        {
            Console.WriteLine("Identifiez-vous pour pouvoir ajouter un train");

            var login = Console.ReadLine();
            if (login.Contains("RES_"))
            {
                var user = UserProvider.GetUser(login);

                Console.WriteLine("Veuillez écrire l'identifiant du train: ");
                int trainId = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Veuillez écrire la capacité d'accueil du train: ");
                int capacity = Int32.Parse(Console.ReadLine());

                var train = Train.Add(trainId, capacity);
                Console.WriteLine("Le train n°" + train.TrainId + " a été ajouté");
            }
            else {
                Console.WriteLine("Vous n'avez pas les droits d'accès à cette fonctionnalité");
            }

        }
    }
}
