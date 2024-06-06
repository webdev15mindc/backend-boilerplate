using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Net;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly PgDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, PgDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest authRequest)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_configuration["ApiConfig:BaseUrl"] + "/api/v1/auth/authenticate/"),
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(new { api_key = authRequest.api_key, api_secret = authRequest.api_secret }), Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return Unauthorized(new { message = "Invalid API key or secret" });
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return new ContentResult
            {
                Content = responseContent,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
