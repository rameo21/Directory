using ContactAPI.EntityLayer.Enums;

namespace ContactAPI.Models
{
    public class ContactDetailDto
    {
        public int ContactId { get; set; }
        public InformationType InformationType { get; set; }
        public string Content { get; set; }
    }
}
