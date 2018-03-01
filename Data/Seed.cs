using System;
using System.Collections.Generic;
using System.Linq;
using caja.Models;
using Newtonsoft.Json;

namespace caja.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
      _context = context;
    }

    public void SeedUsers()
    {
        // _context.Users.RemoveRange(_context.Users);
        // _context.SaveChanges();

        var userData = System.IO.File.ReadAllText("Data/UserDataSeed.json");
        var users = JsonConvert.DeserializeObject<List<User>>(userData);

        var tillData = System.IO.File.ReadAllText("Data/TillDataSeed.json");
        var tills = JsonConvert.DeserializeObject<List<Till>>(tillData);

        var tallyData = System.IO.File.ReadAllText("Data/TallyDataSeed.json");
        var tallies = JsonConvert.DeserializeObject<List<Tally>>(tallyData);

        var EarningData = System.IO.File.ReadAllText("Data/EarningDataSeed.json");
        var earnings = JsonConvert.DeserializeObject<List<Earning>>(EarningData);
        

        var ExpenseData = System.IO.File.ReadAllText("Data/ExpenseDataSeed.json");
        var expenses = JsonConvert.DeserializeObject<List<Expense>>(ExpenseData);


        foreach (var user in users)
        {
            // Console.WriteLine(user.Username);
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("password", out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username = user.Username.ToLower();

            _context.Users.Add(user);
        }

        foreach (var till in tills)
        {
            _context.Tills.Add(till);
        }

        // Many to many seeding didnt work v:

        foreach (var earning in earnings)
        {
            _context.Earnings.Add(earning);
            _context.SaveChanges();

        }

        foreach (var expense in expenses)
        {
            _context.Expenses.Add(expense);
        }

        foreach (var tally in tallies)
        {
            _context.Tallies.Add(tally);
        }
        _context.SaveChanges();

    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())// notice that he is imorting the class right away from here
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}