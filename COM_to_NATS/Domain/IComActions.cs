
using System.IO.Ports;

namespace COM_to_NATS.Domain
{
    internal interface IComActions
    {
        void OpenConnection();
        int BytesToRead();
        byte? ReadByte();
        byte[] ReadBytes();
        void WriteBytes(byte[] data);
    }
}
