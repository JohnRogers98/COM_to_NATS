// See https://aka.ms/new-console-template for more information
using COM_to_NATS.Domain;
using COM_to_NATS.Infrastructure;
using System.Text;

Console.WriteLine("Hello, World!");

ComRepository comRepository = new ComRepository();

var port_1 = comRepository.GetComPortByName("COM1");
var port_2 = comRepository.GetComPortByName("COM2");

port_1.OpenConnection();
port_2.OpenConnection();

//sending a message through port 2, port 1 is connected to port 2
port_2.WriteBytes(Encoding.UTF8.GetBytes("hello world"));

//reading incoming message from port 1
var bufferForReading = new byte[port_1.BytesToRead()];
for(int i = 0; i < bufferForReading.Length; i++)
{
    var readedByte = port_1.ReadByte();

    if (readedByte == null)
        break;

    bufferForReading[i] = (byte)readedByte;
}

//nats
var natsClient = new NatsClient();
var natsConnection = natsClient.GetConnection();

natsConnection.SubscribeAsync("Andrey", (sender, args) =>
{
    Console.WriteLine("Message is incoming...");
    Console.WriteLine("Subject -- " + args.Message.Subject);

    Console.WriteLine(args.Message);
});

natsConnection.Publish("Andrey", bufferForReading);

natsConnection.Drain();
natsConnection.Close();