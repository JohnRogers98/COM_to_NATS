
using System.IO.Ports;

namespace COM_to_NATS.Domain
{
    internal class ComRepository
    {
        public IEnumerable<String> GetComPortNames()
        {
            return SerialPort.GetPortNames().AsEnumerable();
        }

        public ComPort GetComPortByName(String portName)
        {
            return new ComPort(portName);
        }
    }
}