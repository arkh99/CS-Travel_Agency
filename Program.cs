using System;
using System.Collections.Generic;
using TravelAgency;

internal class Program
{
    private static List<Itinerary> itineraries = new List<Itinerary>();

    private static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to Algonquin College Student Travel Agency!");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Travel Agency Menu");
            Console.WriteLine("1. View all itineraries");
            Console.WriteLine("2. Add a new itinerary");
            Console.WriteLine("3. Change an existing itinerary");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter a choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewItineraries();
                        break;
                    case 2:
                        AddNewItinerary();
                        break;
                    case 3:
                        ChangeExistingItinerary();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using Algonquin College Student Travel Agency!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 4.");
            }
        }
    }

    static void ViewItineraries()
    {
        if (itineraries.Count == 0)
        {
            Console.WriteLine("No itineraries exist in the system.");
        }
        else
        {
            for (int i = 0; i < itineraries.Count; i++)
            {
                var itinerary = itineraries[i];
                Console.WriteLine($"{i + 1}. Passenger: {itinerary.PassengerName}, From: {itinerary.DepartureCity}, To: {itinerary.ArrivalCity}, Cost: {itinerary.Cost:C}");
            }
        }
    }

    static void AddNewItinerary()
    {
        try
        {
            string passengerName = GetResponse("Enter passenger name: ");
            string departureCity = GetResponse("Enter departure city: ");
            string arrivalCity = GetResponse("Enter arrival city: ");

            var newItinerary = new Itinerary(passengerName, departureCity, arrivalCity);
            itineraries.Add(newItinerary);
            Console.WriteLine($"Itinerary added successfully. Cost: {newItinerary.Cost:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ChangeExistingItinerary()
    {
        if (itineraries.Count == 0)
        {
            Console.WriteLine("No itineraries available to change.");
            return;
        }

        try
        {
            for (int i = 0; i < itineraries.Count; i++)
            {
                var itinerary = itineraries[i];
                Console.WriteLine($"{i + 1}. {itinerary.PassengerName} - {itinerary.DepartureCity} to {itinerary.ArrivalCity}");
            }

            Console.Write($"Select the itinerary number to change (1-{itineraries.Count}): ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= itineraries.Count)
            {
                var itinerary = itineraries[index - 1];
                Console.WriteLine($"Changing itinerary for {itinerary.PassengerName}");
                string newDepartureCity = GetResponse("Enter new departure city: ");
                string newArrivalCity = GetResponse("Enter new arrival city: ");

                itinerary.ChangeItinerary(newDepartureCity, newArrivalCity);
            }
            else
            {
                Console.WriteLine("Invalid itinerary number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string GetResponse(string request)
    {
        string response = null;

        while (string.IsNullOrWhiteSpace(response))
        {
            Console.Write(request);
            response = Console.ReadLine();
        }

        return response;
    }
}
