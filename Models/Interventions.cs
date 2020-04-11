using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class interventions
    {
        public long id { get; set; }
        public string author { get; set; }
        public long? customer_id { get; set; }
        public long? building_id  { get; set; }
        public long? battery_id { get; set; }
        public long? column_id { get; set; }
        public string? elevator_id  { get; set; }
        public long? employee_id { get; set; }
        public DateTime? start_date_interv { get; set; }
        public DateTime? end_date_interv { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }
    }
}
