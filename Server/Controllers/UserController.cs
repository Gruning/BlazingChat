using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazingChat.Shared;
using BlazingChat.Server.Models;

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
            List<User> users = _context.Users.ToList()
            List<Contact> contacts =  new List<Contact>()
            return _context.Users.ToList();
            foreach (var user in users)
                contacts.Add(new Contact(user.FirstName, user.LastName))
            return contacts
        }
    }
}
