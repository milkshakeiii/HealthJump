using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int unlockNumber = 0;
    public GameObject body;
    public Vector2 lockOffset = new Vector2(-5, 0);
    public float floatTime = 4f;

    private Vector2 unlockedPosition;

    // Start is called before the first frame update
    void Start()
    {
        unlockedPosition = gameObject.transform.position;
        PlatformManager.GetInstance().AddPlatform(this);
    }

    public void Unlock()
    {
        if (!body.activeSelf)
        {
            body.SetActive(true);
            StartCoroutine(UnlockFloat());
        }
    }

    public void Lock()
    {
        body.SetActive(false);
        gameObject.transform.position += (Vector3)lockOffset;
    }

    private IEnumerator UnlockFloat()
    {
        float startTime = Time.time;
        while (Time.time < startTime + floatTime)
        {
            gameObject.transform.position -= (Vector3)lockOffset * Time.deltaTime / floatTime;
            yield return null;
        }
    }
}
