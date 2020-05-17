using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBarrier : MonoBehaviour
{
    private static ReturnBarrier instance;

    public GameObject returnMe;
    public float yLimit;

    private Vector2 returnPosition;

    public static ReturnBarrier GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType<ReturnBarrier>();
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetReturnPosition(Vector2 newReturnPosition)
    {
        returnPosition = newReturnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (returnMe.transform.position.y < yLimit)
        {
            returnMe.transform.position = returnPosition;
            returnMe.transform.localEulerAngles = Vector3.zero;
            returnMe.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            returnMe.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
}
