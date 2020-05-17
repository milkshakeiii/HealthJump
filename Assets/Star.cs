using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarManager.GetInstance().StarCaught(starNumber);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        StarManager.GetInstance().AddStar(this, starNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
