using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public GameObject[] chunks;
    public float chunkSize;
    public Transform basePosition;
    public Vector2 numChunks;
    public float scrollSpeed;

    void Start()
    {
        for (int x = 0; x < numChunks.x; x++)
        {
            for (int y = 0; y < numChunks.y; y++)
            {
                GameObject chunk = chunks[Random.Range(0, chunks.Length)];
                Vector3 position = basePosition.position + new Vector3(x, 0, y) * chunkSize;
                Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
                Transform chunkInstance = Instantiate(chunk, position, rotation, transform).transform;
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);
    }
}
