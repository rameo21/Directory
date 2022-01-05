using ReportAPI.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.EntityLayer.Dto
{
    public class ContactDetailDto
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public InformationType InformationType { get; set; }
        public string Content { get; set; }

        public Status Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
