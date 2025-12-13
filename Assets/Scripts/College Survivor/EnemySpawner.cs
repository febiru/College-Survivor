using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float startMinSpawnTime;
    [SerializeField] private float startMaxSpawnTime;
    [SerializeField] private float endMinSpawnTime;
    [SerializeField] private float endMaxSpawnTime;
    [SerializeField] private float rampDuration;
    [SerializeField] private AnimationCurve difficultyCurve = default; // set in Inspector or leave default linear
    [SerializeField] private int maxSpawnPerWave = 3;
    [SerializeField] public Transform player;

    private float spawnTimer;

    void Awake()
    {
        if (difficultyCurve == null || difficultyCurve.length == 0) difficultyCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        SpawnEnemy();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            int tCount = Mathf.Max(1, Mathf.RoundToInt(Mathf.Lerp(1, maxSpawnPerWave, difficultyCurve.Evaluate(Mathf.Clamp01(Time.timeSinceLevelLoad / rampDuration)))));
            for (int i = 0; i < tCount; i++)
            {
                Vector3 spawnPos = transform.position;
                GameObject instance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                var enemyScript = instance.GetComponent<Enemy>();
                if (enemyScript != null) enemyScript.player = player;
            }
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float t = Mathf.Clamp01(Time.timeSinceLevelLoad / rampDuration);
        float curveVal = difficultyCurve.Evaluate(t);
        float currentMin = Mathf.Lerp(startMinSpawnTime, endMinSpawnTime, curveVal);
        float currentMax = Mathf.Lerp(startMaxSpawnTime, endMaxSpawnTime, curveVal);
        spawnTimer = Random.Range(currentMin, currentMax);
    }
}
