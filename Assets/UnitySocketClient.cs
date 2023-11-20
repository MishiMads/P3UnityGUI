using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UnitySocketClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] receiveBuffer = new byte[1024];

    private void Start()
    {
        ConnectToServer();
        StartListening();
    }

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();
            Debug.Log("Connected to server");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }

    private void StartListening()
    {
        try
        {
            stream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, OnReceiveData, null);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }

    private void OnReceiveData(IAsyncResult ar)
    {
        try
        {
            int bytesRead = stream.EndRead(ar);
            if (bytesRead > 0)
            {
                string receivedData = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);
                Debug.Log($"Received data from server: {receivedData}");

                // Add your code to process the received data here
            }

            // Start listening for more data after processing
            StartListening();
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }

    public void SendData(string data)
    {
        try
        {
            byte[] message = Encoding.UTF8.GetBytes(data);
            stream.Write(message, 0, message.Length);
            Debug.Log($"Sent data to server: {data}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }

    private void OnDestroy()
    {
        if (client != null)
        {
            client.Close();
        }
    }
}