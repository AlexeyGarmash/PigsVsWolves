using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public GameManager gManager;

    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText; 
    private int waveIndex = 0;
    void Start()
    {
        this.enabled = true;
        EnemiesAlive = 0;
        countdown = 2f;
        waveIndex = 0;
    }
    void Update()
    {

        if (EnemiesAlive > 0)
        {
            Debug.Log("PODOZRITELNO");
            return;
        }

        if (waveIndex == waves.Length)
        {
            gManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            SpawnWave();
            countdown = timeBetweenWaves;
            Debug.Log("PODOZRITELNO______2");
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming");

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        
    }

    public Transform spawnPoint;

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
}
