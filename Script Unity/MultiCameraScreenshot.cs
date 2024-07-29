using System;
using System.IO;
using UnityEngine;

public class MultiCameraScreenshot : MonoBehaviour
{
    // Array of cameras to capture screenshots from    
    public Camera[] cameras;

    // Dimensions of the captured screenshots    
    public int captureWidth = 1920;
    public int captureHeight = 1080;

    // Key to trigger the screenshot capture
    public KeyCode screenshotKey = KeyCode.G;

    // Path to save the screenshots
    public string screenshotPath = "Screenshots";


    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            foreach (Camera cam in cameras)
            {
                TakeScreenshot(cam);
            }
        }
    }


    private void TakeScreenshot(Camera cam)
    {
        // Store the currently active render texture
        RenderTexture currentRT = RenderTexture.active;

        // Create a new render texture to render the camera's view
        RenderTexture renderTexture = new RenderTexture(captureWidth, captureHeight, 24);

        // Set the camera's target texture to the newly created render texture
        cam.targetTexture = renderTexture;
        cam.Render();

        // Set the active render texture to the newly created render texture
        RenderTexture.active = renderTexture;

        // Create a new texture to store the screenshot
        Texture2D screenshot = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        // Read pixels from the render texture and apply them to the screenshot texture
        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();

        // Restore the previously active render texture
        RenderTexture.active = currentRT;

        // Reset the camera's target texture
        cam.targetTexture = null;

        // Destroy the temporary render texture
        Destroy(renderTexture);

        // Encode the screenshot texture to PNG format
        byte[] bytes = screenshot.EncodeToPNG();

        // Destroy the screenshot texture
        Destroy(screenshot);

        // Generate a unique filename based on the camera's name and current timestamp
        string cameraName = cam.name;
        string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string fileName = $"{cameraName}_{timeStamp}.png";
        string filePath = Path.Combine(Application.dataPath, screenshotPath, fileName);

        // Create directory if it doesn't exist
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        // Write the encoded bytes to a file
        File.WriteAllBytes(filePath, bytes);

        // Log the path where the screenshot is saved
        Debug.Log($"Screenshot saved: {filePath}");
    }
}
