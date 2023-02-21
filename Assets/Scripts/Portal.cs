using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collideable
{

    public string[] sceneNames;
    // public Vector2 spawnPoint;
    // public VectorValue playerStorage;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);

            GameManager.instance.SaveState();
            // playerStorage.initialValue = spawnPoint;
            // Debug.Log("Load level " + levelToLoad);
        }
    }
}
