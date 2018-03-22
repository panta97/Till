using System.Collections.Generic;
using System.Threading.Tasks;
using caja.Dtos;
using caja.Models;

namespace caja.Repositories
{
    public interface ICommonRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Store>> GetStores();
         Task<IEnumerable<Earning>> GetEarnings(int tallyId);
         Task<IEnumerable<Expense>> GetExpenses(int tallyId);
         Task<IEnumerable<Expense>> GetExpensesByType(int tallyId, string type);
         Task<IEnumerable<Till>> GetTillsByStore(int storeId);
         Task<Earning> GetEarning(int tallyId, int earningId);
         Task<Expense> GetExpense(int tallyId, int expenseId);
         Task<Tally> GetTally(int tallyId);
         Task<bool> UserExists (int id);
         Task<bool> TillExists (int id);
         Task<bool> TallyExists (int id);

         
  }
}