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
    public class ContactDetailService : IContactDetailService
    {
        public async Task<ContactDetail> Add(ContactDetail contactDetail)
        {
            using (var db = new DirectoryDbContext())
            {
                contactDetail.CreateDate = DateTime.Now;
                db.Entry(contactDetail).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
            }
            return contactDetail;
        }

        public async Task<ContactDetail> Delete(ContactDetail contactDetail)
        {
            using (var db = new DirectoryDbContext())
            {
                contactDetail.DeleteDate = DateTime.Now;
                contactDetail.Status = EntityLayer.Enums.Status.Deleted;
                db.Entry(contactDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return contactDetail;
        }

        public async Task<List<ContactDetail>> GetAll()
        {
            var contactDetails = new List<ContactDetail>();
            using (var db = new DirectoryDbContext())
            {
                contactDetails = await db.ContactDetail.ToListAsync();
            }
            return contactDetails;
        }

        public async Task<List<ContactDetail>> GetAllByContactId(int contactId)
        {
            var contactDetails = new List<ContactDetail>();
            using (var db = new DirectoryDbContext())
            {
                contactDetails = await db.ContactDetail.Where(w => w.ContactId == contactId).ToListAsync();
            }
            return contactDetails;
        }

        public async Task<ContactDetail> GetById(int id)
        {
            var contactDetail = new ContactDetail();
            using (var db = new DirectoryDbContext())
            {
                contactDetail = await db.ContactDetail.FirstOrDefaultAsync(w => w.Id == id);
            }
            return contactDetail;
        }

        public async Task<ContactDetail> Update(ContactDetail contactDetail)
        {
            using (var db = new DirectoryDbContext())
            {
                contactDetail.UpdateDate = DateTime.Now;
                db.Entry(contactDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return contactDetail;
        }
    }
}
