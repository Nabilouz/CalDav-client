// See https://aka.ms/new-console-template for more information
using Ical.Net;
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

public class EventModel 
{
        public string Id { get; set; }
        public string Summary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Sequence { get; set; }
}