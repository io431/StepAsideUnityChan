using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {

        if (camera.transform.position.z > this.transform.position.z) {

            Destroy(this.gameObject);

        }
        
    }
}
