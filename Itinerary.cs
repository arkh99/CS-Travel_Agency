namespace TravelAgency;

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
          throw new Exception("Departure city can not be empty!");
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
						throw new Exception("Arriving city can not be empty!");
					}

          if (value.ToUpper() == departureCity.ToUpper()) 
					{
						throw new Exception("Arriving city can not be the same as departure city!");
					}

          arrivalCity = value.Trim();
      }
  }

  public double Cost { get; private set; }

  public Itinerary(string passengerName, string departureCity, string arrivalCity)
  {
      PassengerName = string.IsNullOrWhiteSpace(passengerName) ? throw new Exception("Passenger name can not be empty!") : passengerName;
      DepartureCity = departureCity;
      ArrivalCity = arrivalCity;

      Cost = TicketFee;
  }

  public void ChangeItinerary(string newDepartureCity, string newArrivalCity)
  {
      if (newDepartureCity.Trim().ToUpper() == DepartureCity.ToUpper()
          && newArrivalCity.Trim().ToUpper() == ArrivalCity.ToUpper())
      {
          throw new Exception("New itinerary is the same as old itinerary, no change made!");
      }

      //save current itinerary in case something goes wrong.
      string oldDepartureCity = DepartureCity;
      string oldArrivalCity = ArrivalCity;

      try
      {
          DepartureCity = newDepartureCity;
          ArrivalCity = newArrivalCity;

          Cost += ChangeFee;
      }
      catch (Exception)
      {
          //Unable to save the new itineary, restore the current itinerary.
          DepartureCity = oldDepartureCity;
          ArrivalCity = oldArrivalCity;

          throw;
      }
  }
}
