using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        FastFoodApiDbContext obj = null;
        public UserController(FastFoodApiDbContext _obj)
        {
            obj = _obj;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(string Username, string password)
        {
            try
            {
                var userList = obj.userModels.Where(i => i.Username == Username && i.Password == password).FirstOrDefault();
                if (userList == null)
                {
                    return BadRequest("Invalid credentials");
                }
                var claims = new List<Claim> { new Claim(type: ClaimTypes.Name, value: Username), new Claim(type: ClaimTypes.Name, value: password) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                return Ok("Sign in successfull");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        [HttpGet]
        public List<User> getUser()
        {
            var userList = obj.userModels.ToList();
            return userList;
        }
        [HttpPost]
        public ActionResult insertUser(User user)
        {
            obj.userModels.Add(user);
            obj.SaveChanges();
            return Ok("New user inserted successfully");
        }
        [HttpPut]
        public ActionResult updateUser(UserModel user)
        {
            var userList = obj.userModels.ToList();
            foreach (var i in userList)
            {
                i.Username = user.Username;
                i.Email = user.Email;
                i.Password = user.Password;
                i.Role = user.Role;

            }


            obj.SaveChanges();
            return Ok("User ID; (user.UserId) updated successfully !!");
        }

        [HttpDelete("{id}")]
        public ActionResult deleteUser(int id)
        {

            var userList = obj.userModels.Where(i => i.UserId == id).First();
            obj.userModels.Remove(userList);
            obj.SaveChanges();
            return Ok($"User ID :{id}deleted successfully!!");
        }
    }
}

    }
}
