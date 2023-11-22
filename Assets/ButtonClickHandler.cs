using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public UnitySocketClient socketClient;

    public void OnButtonClick()
    {
        // Replace "YourMessage" with the actual message you want to send to the Python server
        socketClient.SendData("Poosay");
    }
    
    public void OnButtonClick1()
        {
            // Replace "YourMessage" with the actual message you want to send to the Python server
            socketClient.SendData("Nej Mads");
        }
    public void OnRunRealsenseScriptButtonClick()
    {
        socketClient.SendData("123");
    }
    
    public void Stop()
    {
        socketClient.SendData("Stop");
    }
}