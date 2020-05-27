using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starNumber;
    public int unlockNumber = 0;
    bool captured = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarManager.GetInstance().StarCaught(starNumber);
        SetCaptured();
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        StarManager.GetInstance().AddStar(this, starNumber);
        UnlockManager.GetInstance().AddStar(this);
    }

    public void SetCaptured()
    {
        captured = true;
    }

    public void Unlock()
    {
        if (!captured)
        {
            gameObject.SetActive(true);
        }
    }

    public void Lock()
    {
        gameObject.SetActive(false);
    }
}
