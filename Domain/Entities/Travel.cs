using System;

namespace Domain.Entities
{
    public class Travel
    {
        public int TravelId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}