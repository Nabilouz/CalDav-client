// See https://aka.ms/new-console-template for more information
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using System.Net.Http;

//Console.WriteLine("Hello, World!");


const string UriServer = "http://localhost:5232/test/d2c0d129-3f0c-dc0d-8ef9-13c95f0db47b/";
HttpClient client = new HttpClient();
Calendar testcal = new Calendar();
var response = client.GetStringAsync(UriServer).Result;

var calCollection = Calendar.Load(response);

EventModel eventM = new();

eventM.Id = calCollection.Events[0].Uid;
eventM.Summary = calCollection.Events[0].Summary;
eventM.StartDate = calCollection.Events[0].DtStart.Value;
eventM.EndDate = calCollection.Events[0].DtEnd.Value;
eventM.Sequence = calCollection.Events[0].Sequence;

System.Console.WriteLine(eventM.ToString());

//EventModel eventTest = new();
CalendarEvent eventTest = new();

//eventTest.Id = Guid.NewGuid().ToString();
eventTest.Summary = "testEvent";
eventTest.DtStart = new CalDateTime(DateTime.UtcNow);
eventTest.DtEnd = new CalDateTime(DateTime.UtcNow.AddHours(1));
eventTest.Sequence = 2;

calCollection.Events.Add(eventTest);

//Add post request



public class EventModel 
{
        public string? Id { get; set; }
        public string? Summary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Sequence { get; set; }
}