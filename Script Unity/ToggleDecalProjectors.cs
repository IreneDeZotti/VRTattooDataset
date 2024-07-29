using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDecalProjectors : MonoBehaviour
{
    // Array of GameObjects containing Decal Projectors
    public GameObject[] Objects;
    
    // Key to toggle the Decal Projectors on/off
    public KeyCode Key = KeyCode.K;

    // Flag to keep track of whether Decal Projectors are active
    private bool areDecalProjectorsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Activate or deactivate Decal Projectors based on initial flag
        foreach (GameObject obj in Objects)
        {
            obj.SetActive(areDecalProjectorsActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the toggle key is pressed
        if (Input.GetKeyDown(Key))
        {
            // Invert the flag to toggle Decal Projectors
            areDecalProjectorsActive = !areDecalProjectorsActive;

            // Activate or deactivate Decal Projectors based on the updated flag
            foreach (GameObject obj in Objects)
            {
                obj.SetActive(areDecalProjectorsActive);
            }
        }
    }
}
