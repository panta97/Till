using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Models;
using caja.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace caja.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly ICommonRepository _repo;
        private readonly IMapper _mapper;
        public ExpensesController(ICommonRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpenseByType([FromBody] ExpenseForCreationDto expenseForCreationDto)
        {
            if (!(expenseForCreationDto.Type == "sistema" || expenseForCreationDto.Type == "diario"))
            {
                ModelState.AddModelError("expenseType", "expense type must be iether sistema or diario");
                return BadRequest(ModelState);
            }

            var expenseToCreate = _mapper.Map<Expense>(expenseForCreationDto);
            _repo.Add(expenseToCreate);

            if (await _repo.SaveAll())
                return Ok("created for now");
            // return CreatedAtRoute("GetExpenseByType", new {id = message.Id}, messageToReturn);


            throw new Exception("failed on creation");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExpenses(int id)
        {
            var expenses = await _repo.GetExpenses(id);

            var expensesToReturn = _mapper.Map<IEnumerable<ExpensesDto>>(expenses);

            return Ok(expensesToReturn);
        }

        [HttpGet("{id}/{type}")]
        public async Task<ActionResult> GetExpensesByType(int id, string type)
        {
            var expenses = await _repo.GetExpensesByType(id, type);

            var expensesToReturn = _mapper.Map<IEnumerable<ExpensesDto>>(expenses);

            return Ok(expensesToReturn);
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