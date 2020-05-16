using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBarrier : MonoBehaviour
{
    public GameObject returnMe;
    public float yLimit;

    private Vector2 returnPosition;

    // Start is called before the first frame update
    void Start()
    {
        returnPosition = returnMe.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (returnMe.transform.position.y < yLimit)
        {
            returnMe.transform.position = returnPosition;
            returnMe.transform.localEulerAngles = Vector3.zero;
            returnMe.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
