using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorOrquestator : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    private float minFrequency;
    [SerializeField]
    private float maxFrequency;

    private List<GameObject> generators = new List<GameObject>();
    private void Start()
    {
        GameObject enemyGenerator = new GameObject();
        enemyGenerator.name = enemyPrefab.name + "_generator";
        enemyGenerator.transform.position = Vector2.zero;
        enemyGenerator.AddComponent<EnemyGeneratorComponent>().Init(enemyPrefab, GenerateSpawSlots(), minFrequency, maxFrequency);
        generators.Add(enemyGenerator);
    }

    private List<Vector2> GenerateSpawSlots()
    {
        List<Vector2> spawnSlots = new List<Vector2>();
        Vector2 leftBottomCorner = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector2 rightTopCorner = Camera.main.ViewportToWorldPoint(Vector3.one);

        SpriteRenderer prefabSprite = enemyPrefab.GetComponent<SpriteRenderer>();
        float spacing = prefabSprite.bounds.size.x;
        float initialPointX = leftBottomCorner.x;
        float finalPointX = rightTopCorner.x - (spacing / 4f);
        float initialPointY = rightTopCorner.y;
        float currentPositionX = initialPointX + (spacing / 2f);
        while (currentPositionX <= finalPointX)
        {
            Vector2 currentPosition = new Vector2(currentPositionX, initialPointY);
            spawnSlots.Add(currentPosition);
            currentPositionX += (spacing / 2f);
        }
        return spawnSlots;
    }

    private void OnDisable()
    {
        foreach(GameObject generator in generators)
        {
            if (generator)
            {
                generator.SetActive(false);
            }
            
        }
    }
}
