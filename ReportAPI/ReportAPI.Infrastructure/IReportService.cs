using ReportAPI.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Infrastructure
{
    public interface IReportService
    {
        public Task<Report> Add(Report report);
        public Task<Report> Update(Report report);
        public Task<Report> Delete(Report report);
        public Task<Report> GetById(int id);
        public Task<List<Report>> GetAll();
    }
}
