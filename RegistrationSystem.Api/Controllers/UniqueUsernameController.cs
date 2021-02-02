using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationSystem.Api.Services;

namespace RegistrationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniqueUsernameController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome de the username portion of a registration system web API";
        }

        [HttpGet("uniqueUsername")]
        public IActionResult uniqueUsername(string text)
        {
            //Create Regex to test Text validation
            Regex lettersOnly = new Regex("^[a-z,]+$");

            //Text parameter should be not empty and lowercase
            if (string.IsNullOrEmpty(text) || !lettersOnly.IsMatch(text))
            {
                //Return status code with message
                return BadRequest("user names are always non empty string that contains only lowercase English letters in the ASCII range [a-z]");
            }

            UniqueUsernameService UniqueUsernameService = new UniqueUsernameService();
            
            List<string> result = UniqueUsernameService.getUniqueUsername(text);

            //Return status code with result
            return Ok(JsonConvert.SerializeObject(result));
        }

    }
}
