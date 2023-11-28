using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(IOptions<ProducerConfig> configuration)  : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          var  config = new ProducerConfig
            {
                BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "YO2FIYS63GM3PV4T",
                SaslPassword = "sW6ApPX7iUILrXzmFQv8CXueHElraQdlQNLYFJB+3LKDfkrLuyWNrj2Z0d1v3ht9",
                MessageTimeoutMs = 3000000,
                BatchNumMessages = 10000,
            };
            var message = new Message<string, string>
            {
                Key = "Sample",
                Value = "Sample test Value",
            };
            var pr = new ProducerBuilder<string, string>(config).Build();
            var result = await pr.ProduceAsync("topic_DemoAcademic", message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string msg)
        {

            var message = new Message<string, string>
            {
                Key = "Sample",
                Value = msg
            };

            var pr = new ProducerBuilder<string, string>(configuration.Value).Build();
            var result = await pr.ProduceAsync("topic_DemoAcademic", message);
            return Ok(result.Message);
        }
    }
}
