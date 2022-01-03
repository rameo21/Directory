using ContactAPI.EntityLayer.Enums;

namespace ContactAPI.Models
{
    public class ContactDetailDto
    {
        public InformationType InformationType { get; set; }

        public string Content { get; set; }
    }
}
