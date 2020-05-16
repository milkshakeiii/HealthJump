using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBloodPressureHistoryText : MonoBehaviour
{
    public TMPro.TMP_Text TMPtext;

    // Start is called before the first frame update
    void OnEnable()
    {
        string text = "";

        string path = System.IO.Path.Combine(Application.persistentDataPath, "record");
        string record = System.IO.File.ReadAllText(path);
        string[] record_lines = record.Split('\n');
        foreach (string line in record_lines)
        {
            string[] entries = line.Split(',');
            if (!entries[0].Equals("bp"))
                continue;
            string[] values = new string[entries.Length];
            for (int i = 1; i < entries.Length; i++)
            {
                values[i] = entries[i].Split(':')[1];
            }
            int year = int.Parse(values[2]);
            int month = int.Parse(values[3]);
            int day = int.Parse(values[4]);
            int hour = int.Parse(values[5]);
            int minute = int.Parse(values[6]);
            int second = 0;
            System.DateTime readingTime = new System.DateTime(year, month, day, hour, minute, second);

            string systolic = values[7];
            string diastolic = values[8];
            text += readingTime.ToString() + " - " + systolic + "/" + diastolic + " mmHg\n";
        }
        TMPtext.text = text;
    }
}

