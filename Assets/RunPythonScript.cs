using UnityEngine;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

public class RunPythonScript : MonoBehaviour
{
    private string pythonScriptPath = @"C:\Medialogi\P3\Realsense MultipelColor.py"; // Use the @ symbol to create a verbatim string

    public void OnButtonClick()
    {
        RunPython();
    }

    private void RunPython()
    {
        if (File.Exists(pythonScriptPath))
        {
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "python",  // Use "python3" if necessary
                Arguments = pythonScriptPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Debug.Log(result);
                }
            }
        }
        else
        {
            Debug.LogError($"Python script not found at path: {pythonScriptPath}");
        }
    }
}