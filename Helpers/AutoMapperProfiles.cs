using AutoMapper;
using caja.Dtos;
using caja.Models;

namespace caja.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Earning, EarningsDto>();
            CreateMap<Expense, ExpensesDto>();
            CreateMap<EarningForUpdateDto, Earning>();
            CreateMap<ExpenseForUpdateDto, Expense>();
        }
    }
}