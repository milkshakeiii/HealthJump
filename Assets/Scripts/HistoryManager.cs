using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryManager : MonoBehaviour
{
    private static HistoryManager instance;

    public static HistoryManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public int GetHighestReachedPlatformNo()
    {
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
