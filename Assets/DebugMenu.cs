using UnityEngine;

public class DebugMenu
{
    private string gameName;
    private string gpuName;
    private string numberOfCores;
    private string gameResolution;
    private string refreshRate;
    private int lastFrameIndex;
    private float[] frameArray = new float[50];
    private Resolution resolution;

    // Constructor
    public DebugMenu()
    {
        //Get the resolution unity
        resolution = Screen.currentResolution;

        //Get the application and version number
        gameName = Application.productName + "/" + Application.version + "\n";
        //See what graphics card
        gpuName = "GPU: " + SystemInfo.graphicsDeviceName + "\n";

        //Primarily used for Threads
        numberOfCores = "Cores: " + SystemInfo.processorCount + "\n";

        //Resolution values
        gameResolution = "Resolution: " + resolution.width + "x" + resolution.height + "\n";
        refreshRate = "Refresh Rate: " + resolution.refreshRate + "Hz";
    }

    // Update is called once per frame
    public string DebugInfoText()
    {
        //Get fps
        string fps = "FPS: " + Mathf.RoundToInt(FPS()) + "\n";

        //Get the final string values
        string finalString = gameName + gpuName + fps + numberOfCores + gameResolution + refreshRate;

        return finalString;
    }

    /// <summary>
    /// Calculates the Frames Per Second
    /// </summary>
    /// <returns></returns>
    private float FPS()
    {
        frameArray[lastFrameIndex] = Time.unscaledDeltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameArray.Length;
        float total = 0f;
        foreach (float unscaledDeltaTime in frameArray)
        {
            total += unscaledDeltaTime;
        }
        return frameArray.Length / total;
    }
}
