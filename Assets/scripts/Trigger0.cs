using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pexty;

public class Trigger0 : MonoBehaviour
{
    public FirstPersonController controller;
    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.position == controller.transform.position) controller.Teleport(point.position);
    }
}
