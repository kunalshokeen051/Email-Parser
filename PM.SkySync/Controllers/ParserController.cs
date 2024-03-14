using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Text;

[ApiController]
[Route("/api")]
public class YourApiController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public YourApiController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    [Route("test")]
    public async Task<IActionResult> ParseEmailContent()
    {
        string openAIKey = "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";

        EmailSchemaRequest request = new()
        {
            EmailContent = "From: MakeMyTrip <noreply@makemytrip.com>\\nDate: 10 September 2023 at 20:52:37 IST\\nTo: ghosalmishti@gmail.com\\nSubject: E-Ticket for Your Flight Booking ID : NF2S2W1HRLCUPK8A0055\\n\\n\\nTicket\\n\\t \\n\\n\\nHi Mishti, thank you for booking with us. We wish you a pleasant journey!\\n\\t\\tBooking Confirmed\\n\\nDelhi - Bangalore\\n\\nRound trip • Sat, 30 September\\nBooking ID: NF2S2W1HRLCUPK8A0055, (Booked on 10 September 2023)\\n\\t \\n\\n\\nBarcode(s) for your journey Delhi-Bangalore on IndiGo \\n\\n\\nMishti Ghosal\\t\\n\\t\\n\\nBarcode(s) for your journey Bangalore-Delhi on AIR INDIA \\n\\n\\nMishti Ghosal\\t\\n\\t\\n\\t\\n\\t\\n\\n\\n\\nWeb Check-in\\n\\t\\tManage Booking\\n\\n\\n\\n\\tBOOKING DETAILS\\t\\n\\n\\nDelhi - Bangalore\\nSat, 30 Sep 2023 • Non stop • 2h 45m duration\\n\\n \\nIndiGo\\n6E-2403\\n\\nPNR\tF28BXH\\n\\n\\n\\tDelhi\\nDEL 07:05 hrs \\nSat, 30 Sep\\nIndira Gandhi International Airport Terminal 2\\n\\t \\n2h 45m\\tBangalore\\n09:50 hrs BLR \\nSat, 30 Sep\\nBengaluru International Airport Terminal 1\\n\\n\\n\\n \\nFLEXI PLUS\\n\\t \\nEconomy\\n\\t \\nRegular Fare\\n\\t \\n15 Kgs (1 piece only)* check-in\\n\\t \\n7 Kgs (1 piece only)* cabin\\n\\n\\n*Baggage allowance shown above is per passenger\\n\\n\\nTRAVELLER\\tSEAT\\tMEAL\\tE-TICKET NO\\nMS. MISHTI GHOSAL Adult\\nF28BXH\\n\\t4D\\tVegan meal\\tF28BXH\\n\\n\\n\\nBangalore - Delhi\\nMon, 02 Oct 2023 • Non stop • 2h 50m duration\\n\\n \\nAIR INDIA\\nAI-503\\n\\nPNR\t6URFE3\\n\\n\\n\\tBangalore\\nBLR 17:15 hrs \\nMon, 02 Oct\\nBengaluru International Airport Terminal 2\\n\\t \\n2h 50m\\tDelhi\\n20:05 hrs DEL \\nMon, 02 Oct\\nIndira Gandhi International Airport Terminal 3\\n\\n\\n \\nFlex\\n\\t \\nEconomy\\n\\t \\nRegular Fare\\n\\t \\n25 Kgs* check-in\\n\\t \\n8 Kgs* cabin\\n\\n\\n*Baggage allowance shown above is per passenger\\n\\n\\nTRAVELLER\\tSEAT\\tMEAL\\tE-TICKET NO\\nMS. MISHTI GHOSAL Adult\\n098-0989053406768\\n\\t26D\\t\\t098-0989053406768\\n\\n\\n\\n\\tPAYMENT INFORMATION\\t\\n\\n\\nTotal Price\\t₹ 14691\\nPaid by ICICI Bank\\t₹ 14691\\n\\nYour invoice will be available after your travel on My Trips\\n\\n\\t You saved ₹ 75 with MMTSUPER coupon\\n\\n\\n\\n \\nDIGI YATRA\\n\\t \\n\\n\\nAvoid Long Queues at the Airport with DigiYatra\\nUse DigiYatra — the Ministry of Civil Aviation’s mobile app to enjoy a hassle-free airport experience, for your upcoming flight. It enables you to activate face scan for check-in at the airport with 2 easy steps:\\t\\nStep 1: Pre-verifying your identity using Aadhaar Card details\\t\\nStep 2: Updating your upcoming flight’s boarding pass\\t\\nKnow More\\n\\n\\n\\n \\n\\n\\tIMPORTANT INFORMATION\\t\\n\\n\\nFor a convenient travel, follow these guidelines\\n\\n•\\tCheck-in Time : Passenger to report 2 hours before departure. Check-in procedure and baggage drop will close 1 hour before departure.\\n•\\tDGCA passenger charter : Please refer to passenger charter by clicking Here\\n\\n•\\tCheck travel guidelines and baggage information below: : Carry no more than 1 check-in baggage and 1 hand baggage per passenger. If violated, airline may levy extra charges.Wearing a mask/face cover is no longer mandatory. However, all travellers are advised to do so as a precautionary measure.\\n•\\tValid ID proof needed : Carry a valid photo identification proof (Driver Licence, Aadhar Card, Pan Card or any other Government recognised photo identification)\\n•\\tPlease do not share your personal banking and security details like passwords, CVV, etc. with any third person or party claiming to represent MakeMyTrip. For any query, please reach out to MakeMyTrip on our official customer care number.\\n\\t\\n\\t\\n\\t\\n\\n\\n\\n\\tCHANGE IN PLANS?\\t\\n\\n\\nDelhi - Bangalore\\nCancellation Charges\\nFor Adult\\n4 days to 365 days before departure\\nBefore 26 Sep 2023, 07:05 hrs\\n\\t₹800 /Traveller\\n\\n3 hours to 4 days before departure\\nBefore 30 Sep 2023, 04:05 hrs\\n\\t₹3800 /Traveller\\n\\n0 hour to 3 hours before departure\\nBefore 30 Sep 2023, 07:05 hrs\\n\\tNon Refundable\\n\\n\\nCancel Flight  \\n\\n\\n\\tDate Change Charges\\nFor Adult\\n4 days to 365 days before departure\\nBefore 26 Sep 2023, 07:05 hrs\\n\\tFree Date Change\\n\\n3 hours to 4 days before departure\\nBefore 30 Sep 2023, 04:05 hrs\\n\\t₹3550 /Traveller\\n\\n0 hour to 3 hours before departure\\nBefore 30 Sep 2023, 07:05 hrs\\n\\tNon Changeable\\n\\n\\nChange Date  \\n\\n\\n\\n\\nBangalore - Delhi\\nCancellation Charges\\nFor Adult\\n2 hours to 365 days before departure\\nBefore 02 Oct 2023, 15:15 hrs\\n\\t₹300 /Traveller\\n\\n0 hour to 2 hours before departure\\nBefore 02 Oct 2023, 17:15 hrs\\n\\tNon Refundable\\n\\n\\nCancel Flight  \\n\\n\\n\\tDate Change Charges\\nFor Adult\\n2 hours to 365 days before departure\\nBefore 02 Oct 2023, 15:15 hrs\\n\\tFree Date Change\\n\\n0 hour to 2 hours before departure\\nBefore 02 Oct 2023, 17:15 hrs\\n\\tNon Changeable\\n\\n\\nChange Date  \\n\\n\\n\\n\\n\\nAll charges above are per traveller and per sector in INR\\n\\n\\tSUBMIT A REFUND REQUEST\\t\\n\\n\\nPlease let us know if you would like us to contact the airline for your refund. Our agents will initiate the process and this might take up to 30 days. Choose the reason for your refund request:\\nI cancelled directly with the airline\\n\\t \\n\\n\\nMy flight was cancelled/delayed\\n\\t \\n\\n\\n\\n\\tCONTACT US\\t\\n\\n\\nMakeMyTrip Support:\\n\\n \\n+91124 4628747 / +91124 5045105 (India Number)\\n\\n\\n\\t \\nIndiGo Support:\\n\\n \\n0124-6173838, 0124-4973838\\n\\n\\n\\t \\nAIR INDIA Support:\\n\\n \\n18602331407\\n\\n\\n\\t\\n\\n\\n\\n \\n\\n\\tFollow us:\\t \\n\\n \\n\\n \\n\\n\\n\\n\\nNote: Please do not reply to this e-mail. This was sent from an automated mail service that cannot accept incoming e-mails.\"\r\n}\r\n",

            JsonSchema = "{\r\n  \"type\": \"object\",\r\n  \"properties\": {\r\n    \"emailContent\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"date\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"from\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"to\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"subject\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"body\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"bookingDetails\": {\r\n      \"type\": \"object\",\r\n      \"properties\": {\r\n        \"bookingID\": {\r\n          \"type\": \"string\"\r\n        },\r\n        \"roundTrip\": {\r\n          \"type\": \"string\"\r\n        },\r\n        \"outboundFlight\": {\r\n          \"type\": \"object\",\r\n          \"properties\": {\r\n            \"date\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"airline\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"flightNumber\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"departure\": {\r\n              \"type\": \"object\",\r\n              \"properties\": {\r\n                \"airport\": {\r\n                  \"type\": \"string\"\r\n                },\r\n                \"time\": {\r\n                  \"type\": \"string\"\r\n                }\r\n              }\r\n            },\r\n            \"arrival\": {\r\n              \"type\": \"object\",\r\n              \"properties\": {\r\n                \"airport\": {\r\n                  \"type\": \"string\"\r\n                },\r\n                \"time\": {\r\n                  \"type\": \"string\"\r\n                }\r\n              }\r\n            }\r\n          }\r\n        },\r\n        \"returnFlight\": {\r\n          \"type\": \"object\",\r\n          \"properties\": {\r\n            \"date\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"airline\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"flightNumber\": {\r\n              \"type\": \"string\"\r\n            },\r\n            \"departure\": {\r\n              \"type\": \"object\",\r\n              \"properties\": {\r\n                \"airport\": {\r\n                  \"type\": \"string\"\r\n                },\r\n                \"time\": {\r\n                  \"type\": \"string\"\r\n                }\r\n              }\r\n            },\r\n            \"arrival\": {\r\n              \"type\": \"object\",\r\n              \"properties\": {\r\n                \"airport\": {\r\n                  \"type\": \"string\"\r\n                },\r\n                \"time\": {\r\n                  \"type\": \"string\"\r\n                }\r\n              }\r\n            }\r\n          }\r\n        }\r\n      }\r\n    },\r\n    \"paymentInformation\": {\r\n      \"type\": \"object\",\r\n      \"properties\": {\r\n        \"totalPrice\": {\r\n          \"type\": \"string\"\r\n        },\r\n        \"paidBy\": {\r\n          \"type\": \"string\"\r\n        },\r\n        \"savedAmount\": {\r\n          \"type\": \"string\"\r\n        }\r\n      }\r\n    },\r\n    \"importantInformation\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"changeInPlans\": {\r\n      \"type\": \"string\"\r\n    },\r\n    \"contactUs\": {\r\n      \"type\": \"string\"\r\n    }\r\n  }\r\n}\r\n"
        };
        
        try
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAIKey}");

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                prompt = request.EmailContent,
                max_tokens = 100,
                temperature = 0.5,
                stop = "}\n\n"
            };

            var jsonRequest = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                return Ok(jsonResponse);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ToString());
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

public class EmailSchemaRequest
{
    public required string EmailContent { get; set; }
    public required string JsonSchema { get; set; }
}

