using System.Threading.Tasks;
using caja.Details;

namespace caja.Repositories
{
    public interface IReportRepository
    {
        Task<TallyDetail> GetTallyDetail(int tallyId);
    }
}