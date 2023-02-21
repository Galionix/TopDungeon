using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private FloatingText GetFloatingText()
    {
        FloatingText text = floatingTexts.Find(t => !t.active);
        if (text == null)
        {
            text = new FloatingText();
            text.go = Instantiate(textPrefab);
            text.go.transform.SetParent(textContainer.transform);
            text.txt = text.go.GetComponent<Text>();
            floatingTexts.Add(text);
        }
        return text;
    }

    public void Show(
        string message,
        int fontSize,
        Color color,
        Vector3 position,
        Vector3 motion,
        float duration
    )
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = message;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;

        floatingText.duration = duration;
        floatingText.lastShown = Time.time;
        floatingText.active = true;

        floatingText.Show();

        // text.Show(message, fontSize, color, position, motion, duration);
    }

    private void Update()
    {
        foreach (FloatingText text in floatingTexts)
        {
            text.UpdateFloatingText();
        }
    }
}
