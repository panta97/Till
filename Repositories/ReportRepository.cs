using System.Linq;
using System.Threading.Tasks;
using caja.Data;
using caja.Details;
using Microsoft.EntityFrameworkCore;

namespace caja.Repositories
{
  public class ReportRepository : IReportRepository
  {
        private readonly DataContext _context;
        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TallyDetail> GetTallyDetail(int tallyId)
        {
            var tallyDetail = new TallyDetail();

            var tillId = await _context.Tallies
                .Where(t => t.Id == tallyId)
                .Select(t => t.TillId)
                .FirstOrDefaultAsync();

            tallyDetail.TillNumber = await _context.Tills
                .Where(t => t.Id == tillId)
                .Select(t => t.Number)
                .FirstOrDefaultAsync();
            
            var storeId = await _context.Tills
                .Where(t => t.Id == tillId)
                .Select(t => t.StoreId)
                .FirstOrDefaultAsync();
            
            tallyDetail.Store = await _context.Stores
                .Where(s => s.Id == storeId)
                .Select(s => s.Name)
                .FirstOrDefaultAsync();

            return tallyDetail;
        }
  }
}
