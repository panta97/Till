using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Models;
using caja.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace caja.Controllers
{
  [Route("api/[controller]")]
  public class EarningsController : Controller
  {
    private readonly ICommonRepository _repo;
    private readonly IMapper _mapper;
    public EarningsController(ICommonRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> CreateEarningTemplate(int id)
    {
      var earningTemplate = System.IO.File.ReadAllText("Data/EarningTemplate.json");
      var earnings = JsonConvert.DeserializeObject<List<Earning>>(earningTemplate);

      foreach (var earning in earnings)
      {
        earning.TallyId = id;
        _repo.Add(earning);
      }

      if (await _repo.SaveAll())
      {
        return Ok();
      }

      throw new Exception("failed on creating earning template");

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEarnings(int id)
    {
      var earnings = await _repo.GetEarnings(id);

      var earningsToReturn = _mapper.Map<IEnumerable<EarningsDto>>(earnings);

      return Ok(earningsToReturn);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEarning([FromBody] EarningForUpdateDto earningForUpdateDto)
    {
      var earningFromRepo = await _repo
        .GetEarning(earningForUpdateDto.TallyId, earningForUpdateDto.EarningId);

      // var earningToReturn = _mapper.Map(earningForUpdateDto, earningFromRepo);

      if (earningForUpdateDto.Amount == earningFromRepo.Amount)
      {
          return Ok("amount has the same value");
      }

      earningFromRepo.Amount = earningForUpdateDto.Amount;

      if (await _repo.SaveAll())
      {
        return Ok("successfully updated");
      }

      throw new Exception("failed on updating the earning");
    }
  }
}