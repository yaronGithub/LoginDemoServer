
using LoginDemoServer.Models;
using LoginDemoServer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace LoginDemoServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST api/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.LoginInfo loginDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Get model user class from DB with matching email. 
                Models.User modelsUser = GetUSerFromDB(loginDto.Email);
                
                //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
                if (modelsUser == null || modelsUser.Password != loginDto.Password) 
                {
                    return Unauthorized();
                }

                //Login suceed! now mark login in session memory!
                HttpContext.Session.SetString("loggedInUser", modelsUser.Email);

                return Ok(new DTO.User(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private Models.User GetUSerFromDB(string email)
        {
            return new Models.User() 
            { Email = email, Password = "1234", BirthDate = DateTime.Now.AddYears(-21), Name = "Kuku", PhoneNumber="+972 52 6344450", Status=1 };
        }

        // Get api/check
        [HttpGet("check")]
        public IActionResult Check()
        {
            try
            {
                //Check if user is logged in 
                string userEmail = HttpContext.Session.GetString("loggedInUser");

                if (string.IsNullOrEmpty(userEmail))
                {
                    return Unauthorized("User is not logged in");
                }


                //user is logged in - lets check who is the user
                Models.User modelsUser = GetUSerFromDB(userEmail);

                return Ok(new DTO.User(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
