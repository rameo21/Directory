using ReportAPI.EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Infrastructure
{
    public interface IContactService
    {
        public Task<List<ContactDto>> GetAllByLocation(string location);
    }
}
