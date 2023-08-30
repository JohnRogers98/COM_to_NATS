
using NATS.Client;

namespace COM_to_NATS.Infrastructure
{
    internal class NatsClient
    {
        private static ConnectionFactory _connectionFactory = new ConnectionFactory();

        public IConnection GetConnection()
        {
            return _connectionFactory.CreateConnection();
        }

    }
}
