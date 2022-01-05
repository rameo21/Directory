using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportAPI.Infrastructure;

namespace ReportAPI.Controllers
{
    [Route("Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _reportService;
        private readonly IMQService _mqService;

        public ReportController(ILogger<ReportController> logger, IReportService reportService, IMQService mqService)
        {
            _logger = logger;
            _reportService = reportService;
            _mqService = mqService;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var report = await _reportService.GetById(id);

                if (report == null)
                    return NotFound();

                return Ok(report);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Report/GetById");
                return StatusCode(500);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var reports = await _reportService.GetAll();

                if (!reports.Any())
                    return NotFound();

                return Ok(reports);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Report/GetAll");
                return StatusCode(500);
            }
        }

        [HttpGet("ReportRequest")]
        public async Task<IActionResult> ReportRequest(string location)
        {
            try
            {
                if (string.IsNullOrEmpty(location))
                    return BadRequest();

                var report = new EntityLayer.Entity.Report
                {
                    Location = location
                };
                await _reportService.Add(report);
                _mqService.SendReportRequest(report.Id);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }
    }
}
