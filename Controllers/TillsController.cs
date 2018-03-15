using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace caja.Controllers
{
  [Authorize]
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

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTillByStore(int id)
    {
      var tills = await _repo.GetTillsByStore(id);

      var tillsToReturn = _mapper.Map<IEnumerable<TillsDto>>(tills);

      return Ok(tillsToReturn);
    }

  }
}