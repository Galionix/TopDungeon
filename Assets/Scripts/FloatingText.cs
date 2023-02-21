using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{

    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(true);
        // go.SetActive(true);
        // txt.fontSize = fontSize;
        // txt.color = color;
        // txt.text = message;
        // go.transform.position = position;
        // this.motion = motion;
        // this.duration = duration;
        // lastShown = Time.time;
        // active = true;
    }

    public void Hide()
    {
        go.SetActive(false);
        active = false;
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
        {
            Hide();
            return;
        }

        go.transform.position += motion * Time.deltaTime;
    }
}
