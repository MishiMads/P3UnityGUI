using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UnitySocketClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] dataBuffer = new byte[1024];
    
    [SerializeField] private Button Øvelse1;
    [SerializeField] private Button Øvelse2;
    [SerializeField] private Button Øvelse3;
    
    
    void Start()
    {
        client = new TcpClient("localhost", 12345);
        stream = client.GetStream();
    }

    void Update()
    {
    
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string message = "Hello from Unity";
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);

            int bytesRead = stream.Read(dataBuffer, 0, dataBuffer.Length);
            string response = Encoding.ASCII.GetString(dataBuffer, 0, bytesRead);
            Debug.Log("Received: " + response);
        }
    }

    void click()
    {
        Debug.Log("Øvelse 1");
    }
    void OnDestroy()
    {
        stream.Close();
        client.Close();
    }
    
    
}
