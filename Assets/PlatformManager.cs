using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private static PlatformManager instance;

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
        UpdatePlatforms();
    }

    public void UpdatePlatforms()
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
        foreach (Platform platform in platforms)
        {
            if (platform.unlockNumber <= unlockNumber)
            {
                platform.Unlock();
            }
            else
            {
                platform.Lock();
            }
        }
    }

    public void AddPlatform(Platform platform)
    {
        platforms.Add(platform);
    }
}
