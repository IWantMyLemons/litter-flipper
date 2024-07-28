using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FishHealing : MonoBehaviour
{
    [Tooltip("time it takes to heal in seconds")]
    public float healingTime;
    [Tooltip("fish that will be thrown out once healed(they don't have insurance)")]
    public GameObject healedFish;
    [Tooltip("where new fish spawn")]
    public Transform spawnPoint;

    static readonly int capacity = 1;

    readonly Queue<float> fishQueue = new(capacity);

    // Update is called once per frame
    void Update()
    {
        if (fishQueue.Count > 0 && Time.time > fishQueue.Peek())
        {
            fishQueue.Dequeue();
            GameObject newFish = Instantiate(healedFish, spawnPoint.position, spawnPoint.rotation);
            newFish.name = "Healed Fish";
            newFish.GetComponentInChildren<Animator>().SetBool("is_healed", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.ContainsInsensitive("fish")) // honestly a dumb way of checking for fish
        {
            if (fishQueue.Count < capacity)
            {
                Destroy(collider.gameObject);
                fishQueue.Enqueue(Time.time + healingTime);
            }
            else
            {
                collider.GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }
    }

}
