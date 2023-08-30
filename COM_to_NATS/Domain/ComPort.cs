
using System.IO.Ports;

namespace COM_to_NATS.Domain
{
    internal class ComPort : IComActions
    {
        public String Name { get; set; }

        private readonly SerialPort _port;

        public ComPort(String name)
        {
            Name = name;
            _port = new SerialPort(name);
        }

        public void OpenConnection()
        {
            _port.Open();
        }

        public int BytesToRead()
        {
            return _port.BytesToRead;
        }

        public byte[] ReadBytes()
        {
            var bufferToReturn = new byte[_port.ReadBufferSize];
            _port.Read(bufferToReturn, 0, _port.ReadBufferSize);
            return bufferToReturn;
        }

        public byte? ReadByte()
        {
            if (_port.BytesToRead == 0)
            {
                return null;
            }
            return (byte)_port.ReadByte();
        }

        public void WriteBytes(byte[] data)
        {
            _port.Write(data, 0, data.Length);
        }
    }
}
