using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public UnitySocketClient socketClient;
    
    public void OnRunRealsenseScriptButtonClick()
    {
        socketClient.SendData("123");
    }
    
    public void Stop()
    {
        socketClient.SendData("Stop");
    }
}