using ContactAPI.BusinessLayer;
using ContactAPI.EntityLayer.Entity;
using ContactAPI.EntityLayer.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.ContactAPI.BusinessLayer
{
    public class ContactDetailServiceTest
    {
        public ContactDetailServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        [Fact]
        public async Task Add()
        {
            ContactDetailService contactDetailService = new ContactDetailService();
            var contactDetail = new ContactDetail()
            {
                ContactId = 1,
                InformationType = InformationType.Address,
                Content = "istanbul"
            };
            await contactDetailService.Add(contactDetail);
            Assert.True(contactDetail.Id != 0);
        }
        [Fact]
        public async Task GetById()
        {
            ContactDetailService contactDetailService = new ContactDetailService();
            var contactDetail = new ContactDetail()
            {
                ContactId = 1,
                InformationType = InformationType.Address,
                Content = "istanbul"
            };
            await contactDetailService.Add(contactDetail);
            var currentContactDetail = await contactDetailService.GetById(contactDetail.Id);
            Assert.True(contactDetail.Id == currentContactDetail.Id);
        }
        [Fact]
        public async Task GetAll()
        {
            var contactDetailService = new ContactDetailService();
            var models = await contactDetailService.GetAll();
            Assert.True(models.Any());
        }
        [Fact]
        public async Task GetAllByContactId()
        {
            var model = new ContactDetail
            {
                InformationType = InformationType.Address,
                ContactId = 1,
                Content = "istanbul"
            };

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            var dbModel = await contactDetailService.GetAllByContactId(model.ContactId);

            Assert.True(dbModel.Any());
        }
        [Fact]
        public async Task Update()
        {
            ContactDetailService contactDetailService = new ContactDetailService();
            string Content = "Ýzmir";
            var contactDetail = new ContactDetail()
            {
                ContactId = 1,
                InformationType = InformationType.Address,
                Content = "istanbul"
            };
            await contactDetailService.Add(contactDetail);
            var currentContactDetail = await contactDetailService.GetById(contactDetail.Id);
            currentContactDetail.Content = Content;
            await contactDetailService.Update(currentContactDetail);
            Assert.True(currentContactDetail.Content == Content);
        }
        [Fact]
        public async Task Delete()
        {
            ContactDetailService contactDetailService = new ContactDetailService();
            var contactDetail = new ContactDetail()
            {
                ContactId = 1,
                InformationType = InformationType.Address,
                Content = "istanbul"
            };
            await contactDetailService.Add(contactDetail);
            var currentContactDetail = await contactDetailService.Delete(contactDetail);
            Assert.True(currentContactDetail.Status == Status.Deleted);
        }

    }
}