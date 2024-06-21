# CS-Travel_Agency
Program Overview This C# program is a console-based application for a travel agency. It allows users to view, add, and change travel itineraries. 

Key Features
Menu-Driven Interface:

The application provides a simple menu interface for users to interact with, including options to view all itineraries, add new itineraries, change existing itineraries, and exit the program.
Itinerary Management:

View Itineraries: Users can view all existing itineraries with passenger names, departure cities, arrival cities, and costs.
Add New Itinerary: Users can add a new itinerary by providing the passenger name, departure city, and arrival city. The program calculates the cost and adds the itinerary to the list.
Change Existing Itinerary: Users can change the details of an existing itinerary, including the departure city and arrival city. A change fee is applied to the cost.
Input Validation and Error Handling:

The program ensures valid user inputs and handles errors gracefully, providing appropriate feedback to users when errors occur.
Techniques Used
Object-Oriented Programming (OOP):

The Itinerary class encapsulates all properties and methods related to an itinerary. It uses encapsulation to protect the integrity of itinerary data.
Static Properties:

The ChangeFee and TicketFee are static properties in the Itinerary class, representing constants applicable to all itineraries.
Exception Handling:

The program employs try-catch blocks to handle exceptions during itinerary creation and modification, ensuring robust error handling and user feedback.
Validation Logic:

The Itinerary class contains validation logic in the property setters to ensure valid data (e.g., departure and arrival cities cannot be the same, and names cannot be empty).
List Management:

The program uses a List<Itinerary> to manage multiple itineraries, demonstrating collection handling in C#.
Brief Review of the Project
Project Strengths
User-Friendly Interface: The console menu makes the application easy to use, guiding users through their options in a clear manner.
Robust Error Handling: The program effectively manages and reports errors, ensuring a smooth user experience even when incorrect data is entered.
Well-Structured Code: The separation of concerns between the main program logic and the Itinerary class makes the code maintainable and easy to understand.
Comprehensive Validation: The extensive validation ensures data integrity and prevents logical errors in itinerary management.
