using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCoins : MonoBehaviour
{
    public GameObject[] coin;
    private float[] positions = { 1.33f, 0.45f, -0.39f, -1.26f };

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(
                coin[Random.Range(0, coin.Length)],
                new Vector3(positions[Random.Range(0, 4)], 8f, 0),
                Quaternion.Euler(new Vector3(0, 180, 0))
            );
            yield return new WaitForSeconds(2.5f);
        }
    }
}
