using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Adress = "123 Main St", Email = "john@example.com", Password = "password123" },
            new User { Id = 2, Name = "Jane Doe", Adress = "456 Oak St", Email = "jane@example.com", Password = "password456" }
        };

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            user.Id = users.Count + 1;
            users.Add(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            User existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Adress = updatedUser.Adress;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
