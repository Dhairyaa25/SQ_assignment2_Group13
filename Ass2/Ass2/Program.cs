using System;
using System.Collections.Generic;

class Program
{
    static List<Reservation> reservations = new List<Reservation>();

    static void Main()
    {
        // Example usage:
        Reservation reservation = new Reservation(/* Initialize with appropriate values */);
        reservations.Add(reservation);

        Console.WriteLine("Thank you! The reservation was successful.");
    }

    // Other methods (ListAllReservations, ClearAllReservations) go here
}

class Reservation
{
    // Define properties and methods specific to your Reservation class
    // ...

    public void PrintReservation()
    {
        // Implement the logic to print reservation details
    }
}
