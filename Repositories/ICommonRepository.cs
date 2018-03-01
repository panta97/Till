using System.Collections.Generic;
using System.Threading.Tasks;
using caja.Models;

namespace caja.Repositories
{
    public interface ICommonRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Earning>> GetEarnings(int tallyId);
         Task<IEnumerable<Expense>> GetExpenses(int tallyId);
  }
}