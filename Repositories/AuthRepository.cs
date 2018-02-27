using System;
using System.Threading.Tasks;
using caja.Data;
using caja.Models;
using Microsoft.EntityFrameworkCore;

namespace caja.Repositories
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    public AuthRepository(DataContext context)
    {
      this._context = context;

    }
    public async Task<User> Login(string username, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
      // it uses firstOrDefaultAsyncs because in the case that it didn't find the user
      // it will return a null
      // on the other hand the firstAsync will raise and exception if it didn't find the user
      // and (exceptions are expensive so we will user first or default async)

      if (user == null) // the user doesn't exist
        return null;

      // we also need to verify the password

      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        return null;

      // notice that we are return null either if the username doesn't exits or if the password doesn't match;	

			// auth successful
			return user;

    }

		// this will work kind of the other way around as the CreatePasswordHash method
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))// notice that he is imorting the class right away from here
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
						if(computedHash[i] != passwordHash[i]) return false; // as soon as it gest flase then inmediatly we know the dind't match the hashPassword
				}
				return true; // if every element of the array matches then we know that is the right password (authSucceded)
      }
    }

		// first we pass the key (passwordSalt) to the HMACSHA512 method

		// the computedHash password will the as the database password (passwordHash)

		// because our password are arrays of bytes we need to compare them in a loop one by one

    public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();

      return user;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())// notice that he is imorting the class right away from here
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

		// this last one is very simple if there is already a user that username then we return true
    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(x => x.Username == username))
				return true;

			return false;
    }
  }
}