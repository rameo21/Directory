using ReportAPI.BusinessLayer;
using ReportAPI.EntityLayer.Entity;
using ReportAPI.EntityLayer.Enum;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.ReportAPI.BusinessLayer
{
    public class ReportServiceTest
    {
        public ReportServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        [Fact]
        public async Task Add()
        {
            var report = new Report
            {
                ReportStatus = ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                Location = "istanbul"
            };

            var reportService = new ReportService();
            await reportService.Add(report);
            Assert.True(report.Id != 0);
        }
        [Fact]
        public async Task GetById()
        {
            var report = new Report
            {
                ReportStatus = ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                Location = "istanbul"
            };

            var reportService = new ReportService();
            await reportService.Add(report);
            var currentReport = await reportService.GetById(report.Id);
            Assert.True(report.Id == currentReport.Id);
        }
        [Fact]
        public async Task GetAll()
        {
            var reportService = new ReportService();
            var reports = await reportService.GetAll();
            Assert.True(reports.Any());
        }
        [Fact]
        public async Task Update()
        {
            string location = "izmir";
            var report = new Report
            {
                ReportStatus = ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                Location = "istanbul"
            };

            var reportService = new ReportService();
            await reportService.Add(report);
            report.Location = location;
            await reportService.Update(report);
            var currentReport = await reportService.GetById(report.Id);
            Assert.True(currentReport.Location == location);
        }
        [Fact]
        public async Task Delete()
        {
            var report = new Report
            {
                ReportStatus = ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                Location = "istanbul"
            };

            var reportService = new ReportService();
            await reportService.Add(report);
            await reportService.Delete(report);
            Assert.True(report.Status != Status.Deleted);
        }
    }
}