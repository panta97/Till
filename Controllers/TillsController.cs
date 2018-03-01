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
  }
}