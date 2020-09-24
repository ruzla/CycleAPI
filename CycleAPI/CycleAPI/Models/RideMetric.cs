using System;
using System.Collections.Generic;

#nullable disable

namespace CycleAPI.Models
{
    public partial class RideMetric
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public decimal Distance { get; set; }
        public int Elevation { get; set; }
    }
}
