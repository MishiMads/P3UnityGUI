using System;
using System.Collections;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class UnitySocketClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] receiveBuffer = new byte[1024];
    private List<string> antalReps = new List<string>() { "0", "1", "2", "3", "4", "5" };
    public static string currentReps;
    public static string assessmentScore;

    private void Start()
    {
        ConnectToServer();
    }
    

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();
            StartListening();
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

                if (antalReps.Contains(receivedData))
                {
                    currentReps = receivedData;
                    print("Reps: " + currentReps);
                }
                else
                {
                    assessmentScore = receivedData; 
                    print(assessmentScore);
                }


                // Continue listening for more data
                StartListening();
            }
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
