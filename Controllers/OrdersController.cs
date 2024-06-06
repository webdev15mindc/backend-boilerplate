using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly PgDbContext _context;
        private readonly IConfiguration _configuration;

        public OrdersController(ILogger<AuthController> logger, PgDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_configuration["ApiConfig:BaseUrl"] + "/api/v1/orders/"),
                Headers =
                {
                    { HttpRequestHeader.ContentType.ToString(), "application/json" },
                },
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(orderRequest), Encoding.UTF8, "application/json")
            };

            var bearerToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(bearerToken))
            {
                request.Headers.Add(HttpRequestHeader.Authorization.ToString(), bearerToken);
            }

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return Unauthorized(new { message = "Invalid request" });
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
