using ContactAPI.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.Infrastructure
{
    public interface IContactService
    {
        public Task<Contact> Add(Contact contact);
        public Task<Contact> Update(Contact contact);
        public Task<Contact> Delete(Contact contact);
        public Task<Contact> GetById(int id);
        public Task<List<Contact>> GetAll();
    }
}
