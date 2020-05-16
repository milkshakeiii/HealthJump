using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private static PlatformManager instance;

    private List<Platform> platforms = new List<Platform>();

    public static PlatformManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        UpdatePlatforms();
    }

    public void UpdatePlatforms()
    {

    }

    public void AddPlatform(Platform platform)
    {
        platforms.Add(platform);
    }
}
