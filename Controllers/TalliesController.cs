using System;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Models;
using caja.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace caja.Controllers
{
    [Route("api/[controller]")]
    public class TalliesController : Controller
    {
        private readonly ICommonRepository _repo;
        private readonly IMapper _mapper;
        public TalliesController(ICommonRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTally([FromBody] TallyForCreationDto tallyForCreationDto)
        {
            if (!await _repo.UserExists(tallyForCreationDto.UserId))
                ModelState.AddModelError("userId", "userId doesn't exist");

            if (!await _repo.TillExists(tallyForCreationDto.TillId))
                ModelState.AddModelError("tallyId", "tallyId doesn't exist");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var tallyToCreate = _mapper.Map<Tally>(tallyForCreationDto);
            _repo.Add(tallyToCreate);

            if (await _repo.SaveAll())
                return Ok("new tally created");

            throw new Exception("failed on creation");
        }

    }
}