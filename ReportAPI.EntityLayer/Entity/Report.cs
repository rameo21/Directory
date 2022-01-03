using ReportAPI.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.EntityLayer.Entity
{
    public class Report
    {
        public int Id { get; set; }


        public string Location { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string? Value { get; set; }

        public Status Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
