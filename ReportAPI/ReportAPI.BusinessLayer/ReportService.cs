using Microsoft.EntityFrameworkCore;
using ReportAPI.DataLayer;
using ReportAPI.EntityLayer.Entity;
using ReportAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.BusinessLayer
{
    public class ReportService : IReportService
    {
        public async Task<Report> Add(Report report)
        {
            using (var db = new ReportDbContext())
            {
                report.CreateDate = DateTime.Now;
                report.RequestDate = DateTime.Now;
                db.Entry(report).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
            }
            return report;
        }
        public async Task<Report> Update(Report report)
        {
            using (var db = new ReportDbContext())
            {
                report.UpdateDate = DateTime.Now;
                db.Entry(report).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return report;
        }
        public async Task<Report> Delete(Report report)
        {
            using (var db = new ReportDbContext())
            {
                report.DeleteDate = DateTime.Now;
                report.Status = EntityLayer.Enum.Status.Deleted;
                db.Entry(report).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return report;
        }

        public async Task<List<Report>> GetAll()
        {
            var reports = new List<Report>();
            using (var db = new ReportDbContext())
            {
                reports = await db.Report.ToListAsync();
            }
            return reports;
        }

        public async Task<Report> GetById(int id)
        {
            var report = new Report();
            using (var db = new ReportDbContext())
            {
                report = await db.Report.FirstOrDefaultAsync(w => w.Id == id);
            }
            return report;
        }


    }
}
