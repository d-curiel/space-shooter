using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public List<GameObject> items;
    public GameObject itemPrefab;
    public int poolSize = 10;

    public void InitializePool(GameObject itemPrefab, int poolSize = 10)
    {
        this.itemPrefab = itemPrefab;
        this.poolSize = poolSize;

        this.itemPrefab.SetActive(false);
        items = new List<GameObject>();
        for (int i = 0; i < this.poolSize; i++)
        {
            items.Add(Instantiate(this.itemPrefab));
        }
    }

    public GameObject GetItem()
    {
        GameObject nextItem = items.Find(item => !item.activeInHierarchy);
        if (nextItem == null)
        {
            nextItem = Instantiate(itemPrefab);
            items.Add(nextItem);
        }
        return nextItem;
    }
}
