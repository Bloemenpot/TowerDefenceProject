using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;

public class WaveSpawner : MonoBehaviour
{

    public Wave[] waves;

    public Transform spawnPoint;

    private bool canSpawn = true;
    private int waveMax = 1;

    //public float timeBetweenWaves = 4f;
    public Text WaveCountdownText;

    private int waveNumber = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Pause();

        if (!GameManager.isPaused && canSpawn)
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        if (waveMax == waves.Length -1)
        {
            this.enabled = false;
        }
        canSpawn = false;
        PlayerStats.Round += 1;

        Wave wave = waves[waveNumber];

        StartCoroutine(Spawn(wave));

        waveMax += 1;


    }

    IEnumerator Spawn(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            float time = 1f / wave.rate;
            while (GameManager.isPaused)
            {
                yield return new WaitForEndOfFrame();
            }
            SpawnEnemy(wave.enemy);
            while (!GameManager.isPaused && time >= 0f)
            {
                yield return new WaitForEndOfFrame();
                time -= Time.deltaTime;
            }
        }

        StartCoroutine(Delay(wave.delay));


    }

    IEnumerator Delay(float delayTime)
    {
         //= wave.delay;
        while (!GameManager.isPaused && delayTime >= 0f)
        {
            yield return new WaitForEndOfFrame();
            delayTime -= Time.deltaTime;
            WaveCountdownText.text = Mathf.Round(delayTime).ToString();
        }

        waveNumber++;

        if (waveNumber == waves.Length)
        {
            Debug.Log("EndGame");
        }
        canSpawn = true;
    }
    void SpawnEnemy(GameObject enemy)
    {
        if (!GameManager.isPaused)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
