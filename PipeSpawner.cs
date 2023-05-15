using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    void SpawnPipe()
    {
        float randomYPos = Random.Range(minHeight, maxHeight);
        Instantiate(pipe, new Vector3(transform.position.x, randomYPos, 0), transform.rotation);
    }
}
