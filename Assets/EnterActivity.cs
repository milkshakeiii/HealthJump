using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterActivity : MonoBehaviour
{
    public TMPro.TMP_InputField m;
    public TMPro.TMP_InputField d;
    public TMPro.TMP_InputField y;
    public TMPro.TMP_InputField minutes;
    public TMPro.TMP_Dropdown dropdown;
    public TMPro.TMP_InputField notes;

    // Start is called before the first frame update
    void Start()
    {
        m.onEndEdit.AddListener(CleanMonth);
        d.onEndEdit.AddListener(CleanDay);
        y.onEndEdit.AddListener(CleanYear);
        minutes.onEndEdit.AddListener(CleanMinutes);
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
        minutes.text = "";
        notes.text = "";
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
    private void CleanMinutes(string text)
    {
        CleanInput(minutes, "", 0, 999);
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
        if (minutes.text.Equals(""))
            return;

        string record = "\n";
        record += "submitted:" + System.DateTime.Now.ToString() + ",";
        record += "logged_year:" + y.text + ",";
        record += "logged_month:" + m.text + ",";
        record += "logged_day:" + d.text + ",";
        record += "activity:" + dropdown.options[dropdown.value].text + ",";
        record += "minutes:" + minutes.text + ",";

        string notes_text = "";
        foreach (char c in notes.text)
        {
            if (!c.Equals(':') && !c.Equals(','))
            {
                notes_text += c;
            }
        }
        record += "notes:" + notes_text;

        string path = System.IO.Path.Combine(Application.persistentDataPath, "record");
        System.IO.File.AppendAllText(path, record);
    }
}
