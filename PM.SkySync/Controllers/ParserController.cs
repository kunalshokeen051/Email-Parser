using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace PM.SkySync.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ParserController : Controller
    {
        [HttpGet]
        [Route("test")]
        public IActionResult Index()
        {
            string emailContent = @"Subject: Flight Booking Confirmation - Delhi to Sydney for Kunal Shokeen

Dear Kunal Shokeen,

We are pleased to confirm your flight booking from Delhi to Sydney. Below are the details of your itinerary:

Passenger Name: Kunal Shokeen
Booking Reference Number: XYZ123456
Departure City: Delhi
Destination City: Sydney
Flight Date: March 25, 2024
Flight Time: 10:00 AM (local time)
Airline: Sky Airlines
Flight Number: SKY123
Seat Number: 15A
Class: Economy
Baggage Allowance: 1 piece of checked baggage (up to 23 kg) and 1 carry-on bag (up to 7 kg)

Please review the provided information carefully. Your e-ticket, along with any additional travel documentation, will be sent to the email address associated with your booking shortly.

For any inquiries or assistance regarding your booking, feel free to contact our customer service team at +91-XXXXXXXXXX.

Thank you for choosing Sky Airlines for your travel needs. We look forward to welcoming you on board and wish you a pleasant journey to Sydney.

Warm regards,

[Your Name]
[Your Position]
[Your Contact Information]
[Your Company Name]";
            string jsonSchema = @"
{
  ""emailSubject"": ""Flight Booking Confirmation - [DepartureCity] to [DestinationCity] for [PassengerName]"",
  ""passengerName"": ""[PassengerName]"",
  ""bookingReferenceNumber"": ""[BookingReferenceNumber]"",
  ""departureCity"": ""[DepartureCity]"",
  ""destinationCity"": ""[DestinationCity]"",
  ""flightDate"": ""[FlightDate]"",
  ""flightTime"": ""[FlightTime]"",
  ""airline"": ""[Airline]"",
  ""flightNumber"": ""[FlightNumber]"",
  ""seatNumber"": ""[SeatNumber]"",
  ""class"": ""[Class]"",
  ""baggageAllowance"": ""[BaggageAllowance]"",
  ""contactInformation"": ""[ContactInformation]""
}";
            string apiKey = "AIzaSyBLrhr3fOiX5tF33hvF3Rml-Wi_b6jI19Q";
            string Query = $"from {emailContent} parse and extract data into this format {jsonSchema}";

            string result = GenerateContent(apiKey,Query).Result;
            Console.WriteLine(result);

            return Json(new {result});
        }

        static async Task<string> GenerateContent(string apiKey, string text)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={apiKey}";

                var content = new StringContent(
                    @"{""contents"":[{""parts"":[{""text"":""" + text + @"""}]}]}",
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
    }
}
