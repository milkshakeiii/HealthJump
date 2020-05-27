using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private static StarManager instance;

    public TMPro.TMP_Text text;

    private Dictionary<int, Star> stars = new Dictionary<int, Star>();

    public static StarManager GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType<StarManager>();
        return instance;
    }

    private void Start()
    {
        //set score
        string path = System.IO.Path.Combine(Application.persistentDataPath, "score");
        int score;
        if (System.IO.File.Exists(path))
        {
            score = System.IO.File.ReadAllText(path).Split('\n').Length - 1;
        }
        else
        {
            score = 0;
        }
        text.text = "x " + score.ToString();

        //hide stars
        if (System.IO.File.Exists(path))
        {
            string[] starLines = System.IO.File.ReadAllText(path).Split('\n');
            foreach (string starLine in starLines)
            {
                if (starLine.Equals(""))
                    continue;
                int starNumber = int.Parse(starLine);
                stars[starNumber].SetCaptured();
            }
        }
    }

    public void AddStar(Star star, int number)
    {
        stars[number] = star;
    }

    public void StarCaught(int starNumber)
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "score");
        System.IO.File.AppendAllText(path, starNumber.ToString() + '\n');
        int score = System.IO.File.ReadAllText(path).Split('\n').Length - 1;
        text.text = "x " + score.ToString();
    }

}
