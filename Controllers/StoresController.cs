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
  public class StoresController : Controller
  {
    private readonly ICommonRepository _repo;
    private readonly IMapper _mapper;
    public StoresController(ICommonRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetStores()
    {
      var stores = await _repo.GetStores();

      var storesToReturn = _mapper.Map<IEnumerable<StoresDto>>(stores);

      return Ok(storesToReturn);
    }
  }
}