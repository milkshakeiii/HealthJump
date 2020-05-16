using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float forceMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("onmousedown");
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        while (UnityEngine.Input.GetMouseButton(0))
        {
            yield return null;
        }
        Debug.Log("up");
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = mouseWorldPos - (Vector2)gameObject.transform.position;
        Vector2 center = gameObject.GetComponent<BoxCollider2D>().bounds.center;
        gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(difference * forceMultiplier, center);
    }
}
