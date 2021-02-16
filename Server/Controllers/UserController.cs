using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazingChat.Shared;
using BlazingChat.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingChat.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly BlazingChatContext _context;

        public UserController(ILogger<UserController> logger, BlazingChatContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public List<Contact> Get()
        {
            List<User> users = _context.Users.ToList();
            List<Contact> contacts =  new List<Contact>();
            var cont = 1;
            foreach (var user in users){
                //Convert.ToInt64(user.UserId)
                contacts.Add(new Contact(cont,user.FirstName, user.LastName));
                cont ++;
            }
            return contacts;
        }
        [HttpPut("updateprofile/{userId}")]
        public async Task<User> UpdateProfile(int userId,[FromBody] User user){
            User userToUpdate = await _context.Users.Where(u=>u.UserId == userId).FirstOrDefaultAsync();
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;

            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }

        [HttpGet("getprofile/{userId}")]
        public async Task<User>GetProfile(int userId){
            return await _context.Users.Where(u=>u.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
