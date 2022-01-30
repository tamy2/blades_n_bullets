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

    public int startRowCount;
    public float updateDelay;

    private float timeToNewRow;

    int row;

    async void Start()
    {
        for (int i = 0; i < startRowCount; i++)
        {
            SpawnRow();
        }
    }

    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);

        timeToNewRow -= Time.deltaTime;
        if (timeToNewRow <= 0)
        {
            timeToNewRow = updateDelay;
            DeleteRow();
            SpawnRow();
        }
    }

    void SpawnRow()
    {
        row++;
        for (int i = 0; i < numChunks.x; i++)
        {
            GameObject chunk = chunks[Random.Range(0, chunks.Length)];
            Vector3 position = basePosition.position + new Vector3(i, 0, row) * chunkSize;
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
            Transform chunkInstance = Instantiate(chunk, position, rotation, transform).transform;
        }
    }

    void DeleteRow()
    {
        for (int i = 0; i < numChunks.x; i++)
        {
            print("destroyed");
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
