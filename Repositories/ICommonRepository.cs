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
         Task<IEnumerable<Earning>> GetEarnings(int tallyId);
         Task<IEnumerable<Expense>> GetExpenses(int tallyId);
         Task<IEnumerable<Expense>> GetExpensesByType(int tallyId, string type);
         Task<Earning> GetEarning(int tallyId, int earningId);
         Task<Expense> GetExpense(int tallyId, int expenseId);
         
  }
}