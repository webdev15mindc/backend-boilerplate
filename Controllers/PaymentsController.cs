using System;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IConfiguration _configuration;


        public PaymentsController(ILogger<PaymentsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("SimpleAuthorizationInternet")]
        public IActionResult SimpleAuthorizationInternet([FromBody] CreatePaymentRequest requestObj)
        {
            try
            {
                var configDictionary = new Dictionary<string, string>
                {
                    { "runEnvironment", "apitest.cybersource.com" },
                    { "authenticationType", "http_signature" },
                    { "merchantID", "" },
                    { "merchantKeyId", "" },
                    { "merchantsecretKey", "" },
                };
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);

                return Ok(result);
            }
            catch (ApiException err)
            {
                _logger.LogError($"Error Code: {err.ErrorCode}, Error Message: {err.Message}");
                return BadRequest(new { message = err.Message });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception on calling the API : {e.Message}");
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
