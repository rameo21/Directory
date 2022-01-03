using ContactAPI.EntityLayer.Entity;
using ContactAPI.Infrastructure;
using ContactAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;
        private readonly IContactDetailService _contactDetailService;
        public ContactController(ILogger<ContactController> logger, IContactService contactService, IContactDetailService contactDetailService)
        {
            _logger = logger;
            _contactService = contactService;
            _contactDetailService = contactDetailService;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var contact = await _contactService.GetById(id);

                if (contact == null)
                    return NotFound();

                contact.ContactDetails = await _contactDetailService.GetByContactId(contact.Id);

                return Ok(contact);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Contact/GetById");
                return StatusCode(500);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contacts = await _contactService.GetAll();
                if (!contacts.Any())
                    return NotFound();

                return Ok(contacts);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Contact/GetAll");
                return StatusCode(500);
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ContactDto contactDto)
        {
            try
            {
                var contact = contactDto.Adapt<Contact>();
                await _contactService.Add(contact);
                return Ok(contact);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Contact/Add");
                return StatusCode(500);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ContactDto contactDto, int id)
        {
            try
            {
                var contact = await _contactService.GetById(id);
                contact = contactDto.Adapt(contact);
                await _contactService.Update(contact);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Contact/Update");
                return StatusCode(500);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contact = await _contactService.GetById(id);
                await _contactService.Delete(contact);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Contact/Delete");
                return StatusCode(500);
            }
        }
    }
}
