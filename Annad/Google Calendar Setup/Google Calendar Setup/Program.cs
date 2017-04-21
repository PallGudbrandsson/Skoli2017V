using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarQuickstart
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        static string date = null; // expected format: DD/MM/YYYY
        static string[] dates;
        static string[] shifts;
        static string shiftFormat = "c,c.b,b,a,a";
        // expected format: C,C.B,B,A,A
        // , is used to seperate dates
        // . is used if the shifts are on the same day
        // in this example
        // A = 08:00 - 16:00
        // B = 16:00 - 00:00
        // C = 00:00 - 08:00


        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            /*
              var event = CalendarApp.getDefaultCalendar().createEvent('Apollo 11 Landing',
                new Date('July 20, 1969 20:00:00 UTC'),
                new Date('July 20, 1969 21:00:00 UTC'),
                {location: 'The Moon'});
             */
            do
            {
                try
                {
                    // enter the names of the different shifts in this format:
                    // A 8:00 - 16:00
                    // B 16:00 - 00:00
                    // C 00:00 - 8:00
                    Console.WriteLine("Insert series start date");
                    Console.WriteLine("In the format DD/MM/YYY");
                    Console.WriteLine("To exit type 0");
                    date = Console.ReadLine();

                    if (date == "0")
                    {
                        break;
                    }
                    dates = date.Split('/');
                    DateTime start = new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[0]));

                    //  static string shiftFormat = "c,c.b,b,a,a";
                    
                    shifts = shiftFormat.Split(',');

                    foreach (var shift in shifts)
                    {
                        if (shift.Contains('.'))
                        {

                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception)
                {
                    break;
                }
                
            } while (true);
           /* // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }*/
            Console.Read();
        }
    }
}