using ContactAPI.BusinessLayer;
using ContactAPI.EntityLayer.Entity;
using ContactAPI.EntityLayer.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.ContactAPI.BusinessLayer
{
    public class ContactServiceTest
    {
        public ContactServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        [Fact]
        public async Task Add()
        {
            ContactService contactService = new ContactService();
            var contact = new Contact()
            {
                Name = "Ramazan",
                Surname = "KAYAR",
                Company = "Setup34"
            };
            await contactService.Add(contact);
            Assert.True(contact.Id != 0);
        }
        [Fact]
        public async Task GetById()
        {
            ContactService contactService = new ContactService();
            var contact = new Contact()
            {
                Name = "Ramazan",
                Surname = "KAYAR",
                Company = "Setup34"
            };
            await contactService.Add(contact);
            var currentContact = await contactService.GetById(contact.Id);
            Assert.True(contact.Id == currentContact.Id);
        }
        [Fact]
        public async Task GetAll()
        {
            var contactService = new ContactService();
            var models = await contactService.GetAll();
            Assert.True(models.Any());
        }

        [Fact]
        public async Task Update()
        {
            string Name = "Ünal";
            ContactService contactService = new ContactService();
            var contact = new Contact()
            {
                Name = "Ramazan",
                Surname = "KAYAR",
                Company = "Setup34"
            };
            await contactService.Add(contact);
            contact.Name = Name;
            await contactService.Update(contact);
            var currentContact = await contactService.GetById(contact.Id);
            Assert.True(currentContact.Name == Name);
        }
        [Fact]
        public async Task Delete()
        {
            ContactService contactService = new ContactService();
            var contact = new Contact()
            {
                Name = "Ramazan",
                Surname = "KAYAR",
                Company = "Setup34"
            };
            await contactService.Add(contact);
            var currentContact = await contactService.Delete(contact);
            Assert.True(currentContact.Status == Status.Deleted);
        }
        [Fact]
        public async Task GetAllByLocation()
        {
            var contact = new Contact
            {
                Name = "Ramazan",
                Surname = "KAYAR",
                Company = "Setup34",
            };
            var testLocation = "istanbul";

            var contactService = new ContactService();
            var contactDetailService = new ContactDetailService();
            await contactService.Add(contact);
            await contactDetailService.Add(new ContactDetail
            {
                InformationType = InformationType.Address,
                ContactId = contact.Id,
                Content = testLocation
            });
            var model = await contactService.GetAllByLocation(testLocation);

            Assert.True(model != null);
            Assert.True(model!.Any());
        }
    }
}