using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((MainCamera.transform.position.y-transform.position.y) > 10)
        {
            Debug.Log(MainCamera.transform.position);
            Destroy(gameObject);
        }
    }
}
