using ContactAPI.DataLayer;
using ContactAPI.EntityLayer.Entity;
using ContactAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.BusinessLayer
{

    public class ContactService : IContactService
    {
        public async Task<Contact> Add(Contact contact)
        {
            using (var db = new DirectoryDbContext())
            {
                contact.CreateDate = DateTime.Now;
                db.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
            }
            return contact;
        }
        public async Task<Contact> Update(Contact contact)
        {
            using (var db = new DirectoryDbContext())
            {
                contact.UpdateDate = DateTime.Now;
                db.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return contact;
        }
        public async Task<Contact> Delete(Contact contact)
        {
            using (var db = new DirectoryDbContext())
            {
                contact.DeleteDate = DateTime.Now;
                contact.Status = EntityLayer.Enums.Status.Deleted;
                db.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return contact;
        }

        public async Task<List<Contact>> GetAll()
        {
            var contacts = new List<Contact>();
            using (var db = new DirectoryDbContext())
            {
                contacts = await db.Contact.ToListAsync();
            }
            return contacts;
        }

        public async Task<Contact> GetById(int id)
        {
            var contact = new Contact();
            using (var db = new DirectoryDbContext())
            {
                contact = await db.Contact.FirstOrDefaultAsync(w => w.Id == id);
            }
            return contact!;
        }
        public virtual async Task<List<Contact>> GetAllByLocation(string location)
        {
            using (var db = new DirectoryDbContext())
            {
                return await db.Contact
                               .AsNoTracking()
                               .AsSplitQuery()
                               .Where(w => w.Status != EntityLayer.Enums.Status.Deleted &&
                                            w.ContactDetails.Any(a => a.Status != EntityLayer.Enums.Status.Deleted && a.InformationType == EntityLayer.Enums.InformationType.Address && a.Content.Contains(location)))
                               .Include(w => w.ContactDetails.Where(w => w.Status != EntityLayer.Enums.Status.Deleted))
                               .ToListAsync();
            }
        }
    }
}
