using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGeneratorComponent : MonoBehaviour
{
    ObjectPool enemiesObjectPool;
    List<Vector2> spawnSlots = new List<Vector2>();

    private float minFrequency;
    private float maxFrequency;
    private float timeElapsed;

    public void Init(GameObject enemyPrefab, List<Vector2> spawnSlots, float minFrequency, float maxFrequency)
    {
        this.spawnSlots = spawnSlots;
        enemiesObjectPool = gameObject.AddComponent<ObjectPool>();
        enemiesObjectPool.InitializePool(enemyPrefab);

        this.minFrequency = minFrequency;
        this.maxFrequency = maxFrequency;
        this.timeElapsed = 0f;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            timeElapsed += Time.deltaTime; // Actualiza el tiempo transcurrido
            float frequency = Mathf.Lerp(minFrequency, maxFrequency, timeElapsed); // Utiliza el tiempo transcurrido para interpolar la frecuencia
            yield return new WaitForSeconds(frequency);
            GenerateEnemy();
        }
    }

    public void GenerateEnemy()
    {
        GameObject nextEnemy = enemiesObjectPool.GetItem();
        nextEnemy.transform.position = GenerateRandomSpawn();
        nextEnemy.SetActive(true);
        MovementComponent movement;
        nextEnemy.TryGetComponent<MovementComponent>(out movement);
        if (movement)
        {
            movement.Move(Vector2.down);
        }
    }

    private Vector2 GenerateRandomSpawn()
    {
        return spawnSlots[Random.Range(0, spawnSlots.Count)];
    }
}