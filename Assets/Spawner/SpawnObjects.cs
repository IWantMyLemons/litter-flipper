using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [System.Serializable]
    public class SpawnAction
    {
        public float delay;
        public int count;
    }

    [Tooltip("Object(s) to spawn")]
    public GameObject[] toSpawn;

    [Tooltip("When to spawn")]
    public SpawnAction[] schedule;

    PolygonCollider2D spawnArea;
    int currSchedule = 0;
    int currCount = 0;
    float timePassed = 0;

    // Start is called before the first frame update
    void Awake()
    {
        spawnArea = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > schedule[currSchedule].delay)
        {
            timePassed -= schedule[currSchedule].delay;
            if (currCount <= 0)
            {
                currSchedule = (currSchedule + 1) % schedule.Length;
                currCount = schedule[currSchedule].count;
            }
            else
            {
                SpawnObject();
                currCount--;
            }
        }
    }

    void SpawnObject()
    {
        Vector3 minBounds = spawnArea.bounds.min;
        Vector3 maxBounds = spawnArea.bounds.max;

        // Currently objects are spawned by choosing a random point and checking whether its inside
        // this should still be performant since it usually lands after 1-2 iterations
        Vector2 randomPoint;
        do
        {
            randomPoint.x = Mathf.Lerp(minBounds.x, maxBounds.x, Random.value);
            randomPoint.y = Mathf.Lerp(minBounds.y, maxBounds.y, Random.value);
        } while (!spawnArea.OverlapPoint(randomPoint));
        Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], randomPoint, Quaternion.identity);

        if (gameObject.name == "Fish Spawner")
        {
            AudioManager.Instance.PlaySFX("fish");
        }
    }
}
