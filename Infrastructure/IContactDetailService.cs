using ContactAPI.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.Infrastructure
{
    public interface IContactDetailService
    {
        public Task<ContactDetail> Add(ContactDetail contact);
        public Task<ContactDetail> Update(ContactDetail contact);
        public Task<ContactDetail> Delete(ContactDetail contact);
        public Task<ContactDetail> GetById(int id);
        public Task<List<ContactDetail>> GetByContactId(int contactId);
        public Task<List<ContactDetail>> GetAll();
    }
}
