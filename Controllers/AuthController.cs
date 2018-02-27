using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using caja.Dtos;
using caja.Models;
using caja.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace caja.Controllers
{
  [Route("api/[controller]")]
  public class AuthController : Controller
  {
    private readonly IAuthRepository _repo;
    public AuthController(IAuthRepository repo)
    {
      this._repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
    {
      userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

      if (await _repo.UserExists(userForRegisterDto.Username))
        ModelState.AddModelError("Username", "Username already exists");

      // validate request
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var userToCreate = new User
      {
        Username = userForRegisterDto.Username
      };
      // notice that we don't set the password here because it'll be set
      // with the repository register class

      var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
      return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
    {
      var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

      if (userFromRepo == null)
        return Unauthorized();

      // this chunk will generate the token
      var key = Encoding.ASCII.GetBytes("super secret key");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),// this will set the userid
                new Claim(ClaimTypes.Name, userFromRepo.Username)// here the username
          }),

        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)// here you pass the secret key which is th last part of the token (Signature)
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);

      var tokenString = tokenHandler.WriteToken(token);
      return Ok( new {tokenString});

    }
  }
}