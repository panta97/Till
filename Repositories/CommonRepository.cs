using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caja.Data;
using caja.Dtos;
using caja.Models;
using Microsoft.EntityFrameworkCore;

namespace caja.Repositories
{
  public class CommonRepository : ICommonRepository
  {
    private readonly DataContext _context;
    public CommonRepository(DataContext context)
    {
      _context = context;

    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<IEnumerable<Earning>> GetEarnings(int tallyId)
    {
      var earnings = await _context.TallyEarnings
        // .Include(e => e.Tally)
        // .Include(e => e.Earning)
        .Where(e => e.TallyId == tallyId)
        .Select(e => e.Earning)
        .ToListAsync();

      return earnings;
    }
    public async Task<IEnumerable<Expense>> GetExpenses(int tallyId)
    {
      var expenses = await _context.TallyExpenses
        // .Include(e => e.Tally)
        // .Include(e => e.Expense)
        .Where(e => e.TallyId == tallyId)
        .Select(e => e.Expense)
        .ToListAsync();

      return expenses;
    }

    public async Task<IEnumerable<Expense>> GetExpensesByType(int tallyId, string type)
    {
      var expenses = await _context.TallyExpenses
        .Where(e => e.TallyId == tallyId)
        .Select(e => e.Expense)
        .Where(e => e.Type == type)
        .ToListAsync();

      return expenses;
    }

    public async Task<Earning> GetEarning(int tallyId, int earningId)
    {
      var earning = await _context.TallyEarnings
        .Where(e => e.TallyId == tallyId && e.EarningId == earningId)
        .Select(e => e.Earning)
        .FirstOrDefaultAsync();

      return earning;
    }

    public async Task<Expense> GetExpense(int tallyId, int expenseId)
    {
      var expense = await _context.TallyExpenses
        .Where(e => e.TallyId == tallyId && e.ExpenseId == expenseId)
        .Select(e => e.Expense)
        .FirstOrDefaultAsync();

      return expense;
    }


    public async Task<bool> SaveAll()
    {
        return await _context.SaveChangesAsync() > 0;
    }
  }
}