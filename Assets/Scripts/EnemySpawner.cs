using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] waveVariations;
    public Transform spawnPoint;

    public float baseSpawnFrequency;
    public float minSpawnFrequency;
    public float timeFrequencyMultiplierSpeed;

    private float timeToNextSpawn;
    void Start()
    {
    }

    void Update()
    {
        if (!SequencingManager.isGameRunning)
        {
            return;
        }

        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            timeToNextSpawn = baseSpawnFrequency - (Time.time * timeFrequencyMultiplierSpeed);
            timeToNextSpawn = Mathf.Max(timeToNextSpawn, minSpawnFrequency);
            print(timeToNextSpawn);
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        GameObject wave = waveVariations[Random.Range(0, waveVariations.Length)];
        Instantiate(wave, spawnPoint.position, Quaternion.identity).SetActive(true);
    }
}
