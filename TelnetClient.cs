using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WPF
{
    class TelnetClient : ITelnetClient
    {
        NetworkStream stream;
        TcpClient client;
        public void connect(string ip, int port)
        {
            client = new TcpClient(ip, port); // ip should be "localhost" and port 5400

            // Get a client stream for reading and writing.
            stream = client.GetStream();
        }

        public void disconnect()
        {
            // Close everything.
            stream.Close();
            client.Close();
        }

        public string read()
        {
            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            Byte[] data = new Byte[256];
            // String to store the response ASCII representation.
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            // TODO: Remove
            System.Diagnostics.Debug.WriteLine("Received: {0}", responseData);

            return responseData;
        }

        public void write(string command)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            // TODO: Remove
            System.Diagnostics.Debug.WriteLine("Sent: {0}", command);
        }
    }
}
