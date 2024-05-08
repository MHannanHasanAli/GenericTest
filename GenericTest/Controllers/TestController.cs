using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GenericTest.Controllers
{
    [Route("{API_Name}")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveData(string API_Name)
        {
            if (!string.IsNullOrEmpty(API_Name))
            {
                string fileName = "db.json";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                if (System.IO.File.Exists(filePath))
                {
                    string jsonContent = System.IO.File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(jsonContent);

                    if (jsonObject.ContainsKey(API_Name))
                    {
                        return Ok(jsonObject[API_Name].ToString());
                    }
                    else
                    {
                        return NotFound("API not found");
                    }
                }
                else
                {
                    return NotFound("JSON file not found");
                }
            }

            return BadRequest("Invalid API name");
        }
    }
}
