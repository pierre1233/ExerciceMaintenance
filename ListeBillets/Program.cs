using System;
using CentralTrainDB;

namespace ListeBillets
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Entrez votre login");
            var login = Console.ReadLine();

            var reservations = Reservation.ForUser(login);
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}
