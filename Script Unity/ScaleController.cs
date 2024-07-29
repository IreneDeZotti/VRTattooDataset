using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public float scaleAmount = 0.1f; // The amount of scale to apply with each press of the "+" / "-" keys
    public float minScale = 0.1f; // The minimum scale that the GameObject can reach
    public float maxScale = 5f; //The maximum scale that the GameObject can reach

    void Update()
    {
        // Enlarge the GameObject when pressing the "+" key.
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Vector3 newScale = transform.localScale + new Vector3(scaleAmount, scaleAmount, scaleAmount);
            // Ensure not to exceed the maximum scale.
            transform.localScale = Vector3.Min(newScale, new Vector3(maxScale, maxScale, maxScale));
        }

        // Shrink the GameObject when pressing the "-" key.
        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Vector3 newScale = transform.localScale - new Vector3(scaleAmount, scaleAmount, scaleAmount);
            // Ensure not to exceed the maximum scale.
            transform.localScale = Vector3.Max(newScale, new Vector3(minScale, minScale, minScale));
        }
    }
}