using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace caja.Controllers
{
  [Route("api/[controller]")]
  public class TillsController : Controller
  {
    private readonly ICommonRepository _repo;
    private readonly IMapper _mapper;
    public TillsController(ICommonRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet("earnings/{id}")]
    public async Task<ActionResult> GetEarnings(int id)
    {
      var earnings = await _repo.GetEarnings(id);

      var earningsToReturn = _mapper.Map<IEnumerable<EarningsDto>>(earnings);

      return Ok(earningsToReturn);
    }

    [HttpGet("expenses/{id}")]
    public async Task<ActionResult> GetExpenses(int id)
    {
      var expenses = await _repo.GetExpenses(id);
      
      var expensesToReturn = _mapper.Map<IEnumerable<ExpensesDto>>(expenses);

      return Ok(expensesToReturn);
    }

    [HttpGet("expenses/{id}/{type}")]
    public async Task<ActionResult> GetExpensesByType(int id, string type)
    {
      var expenses = await _repo.GetExpensesByType(id, type);

      var expensesToReturn = _mapper.Map<IEnumerable<ExpensesDto>>(expenses);

      return Ok(expensesToReturn);
    }

    [HttpPut("earnings/")]
    public async Task<ActionResult> UpdateEarning([FromBody] EarningForUpdateDto earningForUpdateDto)
    {
      var earningFromRepo = await _repo
        .GetEarning(earningForUpdateDto.TallyId, earningForUpdateDto.EarningId);

      // var earningToReturn = _mapper.Map(earningForUpdateDto, earningFromRepo);

      earningFromRepo.Amount = earningForUpdateDto.Amount;

      if (await _repo.SaveAll())
      {
          return Ok();
      }

      throw new Exception("failed on updating the earning");
    }

    [HttpPut("expense")]
    public async Task<ActionResult> UpdateExpense([FromBody] ExpenseForUpdateDto expenseForUpdateDto)
    {
      var expenseFromRepo = await _repo
        .GetExpense(expenseForUpdateDto.TallyId, expenseForUpdateDto.ExpenseId);

      // var earningToReturn = _mapper.Map(earningForUpdateDto, earningFromRepo);

      var expenseToReturn = _mapper.Map(expenseForUpdateDto, expenseFromRepo);

      if (await _repo.SaveAll())
      {
          return Ok();
      }

      throw new Exception("failed on updating the expense");
    }



  }
}