using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<GameObject> drops;

    public void Spawn()
    {
        int itemToDrop = Random.Range(0, drops.Count);
        if (itemToDrop < drops.Count)
        {
            Instantiate(drops[itemToDrop], gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
