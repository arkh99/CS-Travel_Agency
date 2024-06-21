using System;

namespace TravelAgency
{
    public class Itinerary
    {
        public static double ChangeFee { get; } = 50.0;
        public static double TicketFee { get; } = 500.0;

        public string PassengerName { get; }

        private string departureCity = string.Empty;
        public string DepartureCity
        {
            get { return departureCity; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Departure city cannot be empty!");
                }

                departureCity = value.Trim();
            }
        }

        private string arrivalCity = string.Empty;
        public string ArrivalCity
        {
            get { return arrivalCity; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Arrival city cannot be empty!");
                }

                if (string.Equals(value.Trim(), DepartureCity, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Arrival city cannot be the same as departure city!", nameof(value));
                }

                arrivalCity = value.Trim();
            }
        }

        public double Cost { get; private set; }

        public Itinerary(string passengerName, string departureCity, string arrivalCity)
        {
            PassengerName = string.IsNullOrWhiteSpace(passengerName) ? throw new ArgumentNullException(nameof(passengerName), "Passenger name cannot be empty!") : passengerName;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;

            Cost = TicketFee;
        }

        public void ChangeItinerary(string newDepartureCity, string newArrivalCity)
        {
            if (string.Equals(newDepartureCity.Trim(), DepartureCity, StringComparison.OrdinalIgnoreCase)
                && string.Equals(newArrivalCity.Trim(), ArrivalCity, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("New itinerary is the same as the old itinerary. No change made.");
            }

            string oldDepartureCity = DepartureCity;
            string oldArrivalCity = ArrivalCity;

            try
            {
                DepartureCity = newDepartureCity;
                ArrivalCity = newArrivalCity;

                Cost += ChangeFee;

                Console.WriteLine($"Itinerary changed successfully. Change fee applied: {ChangeFee:C}. Total cost: {Cost:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing itinerary: {ex.Message}");
                DepartureCity = oldDepartureCity;
                ArrivalCity = oldArrivalCity;
            }
        }
    }
}
