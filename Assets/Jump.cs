using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float forceMultiplier;
    public GameObject[] indicatorDots;

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
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        foreach (GameObject dot in indicatorDots)
        {
            dot.SetActive(true);
        }
        while (UnityEngine.Input.GetMouseButton(0))
        {
            for (int i = 0; i < indicatorDots.Length; i++)
            {
                Vector3 a = gameObject.transform.position;
                Vector3 b = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int n = (indicatorDots.Length);
                indicatorDots[i].transform.position = (b * (i+1) + a * (n - i - 1)) / n;
            }
            yield return null;
        }
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = mouseWorldPos - (Vector2)gameObject.transform.position;
        Vector2 center = gameObject.GetComponent<BoxCollider2D>().bounds.center;
        gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(difference * forceMultiplier, center);
        foreach (GameObject dot in indicatorDots)
        {
            dot.SetActive(false);
        }
    }
}
