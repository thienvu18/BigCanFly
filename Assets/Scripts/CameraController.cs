using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playPosition;
    public float offsetSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        playPosition = new Vector3(0, transform.position.y, transform.position.z);
        if (player.transform.localScale.y > 0f)
        {
            playPosition = new Vector3(playPosition.x , playPosition.y + offset, playPosition.z);
        }
        else
        {
            playPosition = new Vector3(playPosition.x , playPosition.y - offset, playPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position,playPosition,offsetSmoothing * Time.deltaTime);
    }
}
