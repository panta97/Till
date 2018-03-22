using System;
using System.Threading.Tasks;
using AutoMapper;
using caja.Dtos;
using caja.Models;
using caja.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace caja.Controllers
{
    [Authorize]
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

        [HttpGet("{id}", Name = "GetTally")]
        public async Task<ActionResult> GetTally(int id)
        {
            if (!await _repo.TallyExists(id))
                ModelState.AddModelError("tallyId", "tally id doesn't exists");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var tallyFromRepo = await _repo.GetTally(id);

            var tallyToReturn = _mapper.Map<TalliesDto>(tallyFromRepo);

            return Ok(tallyToReturn);
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

            var tallyToReturn = _mapper.Map<TalliesDto>(tallyToCreate);

            if (await _repo.SaveAll())
                return CreatedAtRoute("GetTally", new {id = tallyToCreate.Id}, tallyToReturn);
                // return Ok("new tally created"); this will throw an error in the SPA rxjs subscribe method

            throw new Exception("failed on creation");
        }

    }
}