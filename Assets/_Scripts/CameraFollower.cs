using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject FollowObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FollowObject != null)
        {
            var x = FollowObject.transform.position.x;
            var y = FollowObject.transform.position.y;
            x = Mathf.Round(x * 100) / 100;
            y = Mathf.Round(y * 100) / 100;
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
