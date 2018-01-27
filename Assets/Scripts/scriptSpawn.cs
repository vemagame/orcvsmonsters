using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptSpawn : MonoBehaviour {

    public GameObject[] enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int score;
    public Text txtscore;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
        txtscore.text = "Score " + score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
       
    }


    void Spawn()
    {
       
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }

    public void AddScore()
    {

        score += 1;

    }




}
