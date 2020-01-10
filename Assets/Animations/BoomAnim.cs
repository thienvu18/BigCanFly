using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAnim : MonoBehaviour
{
    private float timer = 0;
    private int direction = -1;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer >= 2.0)
        {
            direction *= -1;
            timer = 0;
        }

        float dx = Time.deltaTime * 9 * direction;
        this.transform.position = new Vector3(this.transform.position.x + dx, this.transform.position.y, this.transform.position.z);
        Debug.Log($"BoomPos: {this.transform.position}");
    }
}
