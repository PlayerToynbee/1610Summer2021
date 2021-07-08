using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private readonly float bottomLimit = -5;
    private readonly float leftLimit = -30;

    // Update is called once per frame
    private void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
            Destroy(gameObject);
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit) Destroy(gameObject);
    }
}