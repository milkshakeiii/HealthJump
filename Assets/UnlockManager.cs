using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    private static UnlockManager instance;

    public GameObject player;

    private List<Platform> platforms = new List<Platform>();
    private List<Star> stars = new List<Star>();

    public static UnlockManager GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType<UnlockManager>();
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUnlocks(true);
    }

    public void AddStar(Star star)
    {
        stars.Add(star);
    }

    public void UpdateUnlocks(bool placePlayer)
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "record");
        int unlockNumber;
        if (System.IO.File.Exists(path))
        {
            string record = System.IO.File.ReadAllText(path);
            string[] record_lines = record.Split('\n');
            unlockNumber = record_lines.Length;
        }
        else
        {
            unlockNumber = 0;
        }
        Debug.Log(unlockNumber);
        Platform highestUnlockedPlatform = null;
        foreach (Platform platform in platforms)
        {
            if (platform.unlockNumber <= unlockNumber)
            {
                platform.Unlock();

                if (highestUnlockedPlatform == null || (platform.unlockNumber > highestUnlockedPlatform.unlockNumber))
                {
                    highestUnlockedPlatform = platform;
                }
            }
            else
            {
                platform.Lock();
            }
        }
        foreach (Star star in stars)
        {
            if (star.unlockNumber <= unlockNumber)
            {
                star.Unlock();
            }
            else
            {
                star.Lock();
            }
        }
        if (placePlayer)
        {
            PlacePlayer(highestUnlockedPlatform.transform.position);
        }
    }

    private void PlacePlayer(Vector2 position)
    {
        player.transform.position = position + new Vector2(0, 2);
        ReturnBarrier.GetInstance().SetReturnPosition(player.transform.position);
        player.GetComponent<CameraUpifier>().Snap();
    }

    public void AddPlatform(Platform platform)
    {
        platforms.Add(platform);
    }
}
