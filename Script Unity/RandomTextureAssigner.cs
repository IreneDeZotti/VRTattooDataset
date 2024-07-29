using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class RandomTextureAssigner : MonoBehaviour
{
    public DecalProjector decalProjector; // Reference to the Decal Projector
    public Texture[] textures; // Array of textures to choose from randomly
    public KeyCode captureKey = KeyCode.R; // The key to press for randomizing the textures

    private void Start()
    {
        RandomizeTextures();
    }

    private void Update()
    {
        // Check if the capture key has been pressed
        if (Input.GetKeyDown(captureKey))
        {
            RandomizeTextures();
        }
    }

    private void RandomizeTextures()
    {
        if (decalProjector == null || textures == null || textures.Length == 0)
        {
            Debug.LogError("Assicurati di assegnare un Decal Projector e almeno una texture!");
            return;
        }

        // Choose a random texture from the array
        Texture randomTexture = textures[Random.Range(0, textures.Length)];

        // Modify the texture of the Decal Projector's material
        decalProjector.material.SetTexture("Base_Map", randomTexture);
    }
}
