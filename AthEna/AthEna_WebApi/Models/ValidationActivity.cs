﻿using System;
using System.Collections.Generic;

namespace AthEna_WebApi.Models
{
    public partial class ValidationActivity
    {
        public int Id { get; set; }
        public Guid VactivityId { get; set; }
        public DateTime ValidatedOn { get; set; }
        public int? ValidatedAt { get; set; }
        public Guid? StationId { get; set; }
        public Guid? BusId { get; set; }
        public Guid? RouteId { get; set; }
        public Guid CardId { get; set; }

        public Vehicles Bus { get; set; }
        public Cards Card { get; set; }
        public Routes Route { get; set; }
        public MetroStations Station { get; set; }
    }
}
