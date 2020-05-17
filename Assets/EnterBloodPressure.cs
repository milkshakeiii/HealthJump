using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBloodPressure : MonoBehaviour
{
    public TMPro.TMP_InputField m;
    public TMPro.TMP_InputField d;
    public TMPro.TMP_InputField y;
    public TMPro.TMP_InputField hr;
    public TMPro.TMP_InputField min;
    public GameObject am;
    public GameObject pm;
    public TMPro.TMP_InputField systolic;
    public TMPro.TMP_InputField diastolic;
    public TMPro.TMP_InputField notes;

    // Start is called before the first frame update
    void Start()
    {
        m.onEndEdit.AddListener(CleanMonth);
        d.onEndEdit.AddListener(CleanDay);
        y.onEndEdit.AddListener(CleanYear);
        hr.onEndEdit.AddListener(CleanHour);
        min.onEndEdit.AddListener(CleanMinute);
        systolic.onEndEdit.AddListener(CleanSystolic);
        diastolic.onEndEdit.AddListener(CleanDiastolic);
    }

    private void OnEnable()
    {
        InitializeInputs();
    }

    public void InitializeInputs()
    {
        m.text = System.DateTime.Now.Month.ToString();
        d.text = System.DateTime.Now.Day.ToString();
        y.text = System.DateTime.Now.Year.ToString();
        int hour = System.DateTime.Now.Hour;
        if (hour > 12)
        {
            am.SetActive(false);
            pm.SetActive(true);
        }
        hr.text = (System.DateTime.Now.Hour % 12).ToString();
        min.text = System.DateTime.Now.Minute.ToString();
        systolic.text = "";
        diastolic.text = "";
        if (min.text.Length == 1)
            min.text = "0" + min.text;
        notes.text = "";
    }

    private void CleanSystolic(string text)
    {
        CleanInput(systolic, "", 0, 999);
    }

    private void CleanDiastolic(string text)
    {
        CleanInput(diastolic, "", 0, 999);
    }

    private void CleanMonth(string text)
    {
        CleanInput(m, System.DateTime.Now.Month.ToString(), 1, 12);
    }
    private void CleanDay(string text)
    {
        CleanInput(d, System.DateTime.Now.Day.ToString(), 1, 31);
    }
    private void CleanYear(string text)
    {
        CleanInput(y, System.DateTime.Now.Year.ToString(), 0, 9999);
    }

    private void CleanHour(string text)
    {
        CleanInput(hr, (System.DateTime.Now.Hour%12).ToString(), 1, 12);
    }

    private void CleanMinute(string text)
    {
        CleanInput(min, System.DateTime.Now.Minute.ToString(), 0, 59);
    }

    private void CleanInput(TMPro.TMP_InputField input, string adefault, int min, int max)
    {
        if (!int.TryParse(input.text, out int result))
        {
            input.text = adefault;
            return;
        }
        if (result < min || result > max)
        {
            input.text = adefault;
            return;
        }
    }

    public void RecordReading()
    {
        if (systolic.text.Equals("") || diastolic.text.Equals(""))
            return;

        string path = System.IO.Path.Combine(Application.persistentDataPath, "record");
        string record = "";
        if (System.IO.File.Exists(path))
        {
            record += "\n";
        }

        record += "bp,";
        record += "submitted:" + System.DateTime.Now.ToString() + ",";
        record += "logged_year:" + y.text + ",";
        record += "logged_month:" + m.text + ",";
        record += "logged_day:" + d.text + ",";
        record += "logged_hour:" + hr.text + ",";
        record += "logged_minute:" + min.text + ",";
        record += "systolic:" + systolic.text + ",";
        record += "diastolic:" + diastolic.text + ",";

        string notes_text = "";
        foreach (char c in notes.text)
        {
            if (!c.Equals(':') && !c.Equals(','))
            {
                notes_text += c;
            }
        }
        record += "notes:" + notes_text;

        System.IO.File.AppendAllText(path, record);
    }

}
