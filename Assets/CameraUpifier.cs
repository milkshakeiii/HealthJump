using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpifier : MonoBehaviour
{
    public float repositionTime = 2f;
    public float zoomTime = 2f;
    public Vector2 cameraOffset = new Vector2(0, 5);

    private Vector3 yPositionTimeAgo;
    private float lastUpdate = 0f;

    public void Snap()
    {
        Vector2 tdgoal = (Vector2)gameObject.transform.position + cameraOffset;
        Camera.main.transform.position = new Vector3(tdgoal.x, tdgoal.y - 0.6f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastUpdate) > repositionTime)
        {
            if (yPositionTimeAgo == gameObject.transform.position)
            {
                StartCoroutine(DoCameraZoom());
            }
            yPositionTimeAgo = gameObject.transform.position;
            lastUpdate = Time.time;
        }
    }

    private IEnumerator DoCameraZoom()
    {
        float startTime = Time.time;
        Vector2 cameraTarget = (Vector2)gameObject.transform.position + cameraOffset;
        Vector2 differenceVector = cameraTarget - (Vector2)Camera.main.transform.position;
        while (Time.time < (startTime + zoomTime))
        {
            Camera.main.transform.position += (Vector3)differenceVector * Time.deltaTime / zoomTime;
            yield return null;
        }
    }
}
