using Confluent.Kafka;


var config = new ConsumerConfig
{
    BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092",
    ClientId = "MyConsumer",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.Plain,
    SaslUsername = "YO2FIYS63GM3PV4T",
    SaslPassword = "sW6ApPX7iUILrXzmFQv8CXueHElraQdlQNLYFJB+3LKDfkrLuyWNrj2Z0d1v3ht9",
    GroupId = "MyGroupId",
};


using (var consumer = new ConsumerBuilder<string, string>(config).Build()){
    consumer.Subscribe("topic_DemoAcademic");
    while (true) {
       var result = consumer.Consume();
        Console.WriteLine(result.Message.Value);
    }
}
