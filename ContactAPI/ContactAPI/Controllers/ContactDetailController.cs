using ContactAPI.EntityLayer.Entity;
using ContactAPI.Infrastructure;
using ContactAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("ContactDetail")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly ILogger<ContactDetailController> _logger;
        private readonly IContactService _contactService;
        private readonly IContactDetailService _contactDetailService;

        public ContactDetailController(ILogger<ContactDetailController> logger, IContactService contactService, IContactDetailService contactDetailService)
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
                var contactDetail = await _contactDetailService.GetById(id);
                if (contactDetail == null)
                    return NotFound();
                return Ok(contactDetail);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/GetById");
                return StatusCode(500);
            }
        }
        [HttpGet("GetAllByContactId")]
        public async Task<IActionResult> GetAllByContactId(int contactId)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetAllByContactId(contactId);
                if (contactDetail == null)
                    return NotFound();
                return Ok(contactDetail);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/GetAllByContactId");
                return StatusCode(500);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contactDetails = await _contactDetailService.GetAll();
                if (!contactDetails.Any())
                    return NotFound();

                return Ok(contactDetails);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/GetAll");
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ContactDetailDto contactDetailDto)
        {
            try
            {
                var contactDetail = contactDetailDto.Adapt<ContactDetail>();
                await _contactDetailService.Add(contactDetail);
                return Ok(contactDetail);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/Add");
                return StatusCode(500);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ContactDetailDto contactDetailDto, int id)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetById(id);
                contactDetail = contactDetailDto.Adapt(contactDetail);
                await _contactDetailService.Update(contactDetail);
                return Ok(contactDetail);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/Update");
                return StatusCode(500);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetById(id);
                await _contactDetailService.Delete(contactDetail);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "ContactDetail/Delete");
                return StatusCode(500);
            }
        }

    }
}
