using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        // GameManager.instance.LoadState();
        // add event for scene loaded event
        // SceneManager.sceneLoaded += SaveState;
        SceneManager.sceneLoaded += LoadState;
    }

    // Resources

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References

    public Player player;
    public FloatingTextManager floatingTextManager;

    public void ShowText(
        string msg,
        int fontSize,
        Color color,
        Vector3 position,
        Vector3 motion,
        float duration
    )
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // State

    public int pesos;
    public int experience;
    public int health;
    public int maxHealth = 5;

    // Save state
    /*
    *   INT preferredSkin
    *   INT pesosAmount
    *   INT experience
    *   INT weaponLevel
    */
    public void SaveState()
    {
        // SceneManager.sceneLoaded -= SaveState;
        string SaveState = "";

        // preferredSkin
        SaveState += "0" + "|";
        // pesosAmount
        SaveState += pesos.ToString() + "|";
        // experience
        SaveState += experience.ToString() + "|";
        // weaponLevel
        SaveState += "0";

        PlayerPrefs.SetString("SaveState", SaveState);
        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("No save state found");
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // preferredSkin
        // pesosAmount
        pesos = int.Parse(data[1]);
        // experience
        experience = int.Parse(data[2]);
        // weaponLevel

        Debug.Log("LoadState");
    }
}
