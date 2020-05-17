using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private static PlatformManager instance;

    public GameObject player;

    private List<Platform> platforms = new List<Platform>();

    public static PlatformManager GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType<PlatformManager>();
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlatforms(true);
    }

    public void UpdatePlatforms(bool placePlayer)
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
