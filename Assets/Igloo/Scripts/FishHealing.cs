using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FishHealing : MonoBehaviour
{
    [Tooltip("time it takes to heal in seconds")]
    public float healingTime;
    [Tooltip("fish that will be thrown out once healed(they don't have insurance)")]
    public GameObject healedFish1;
    [Tooltip("the other one")]
    public GameObject healedFish2;
    [Tooltip("where new fish spawn")]
    public Transform spawnPoint;

    static readonly int capacity = 3;

    struct FishPatient
    {
        public FishPatient(float finished, int variant)
        {
            this.finished = finished;
            this.variant = variant;
        }
        public float finished;
        public int variant;
    }

    readonly Queue<FishPatient> fishQueue = new(capacity);

    // Update is called once per frame
    void Update()
    {
        if (fishQueue.Count > 0 && Time.time > fishQueue.Peek().finished)
        {
            switch (fishQueue.Dequeue().variant)
            {
                case 1:
                    Instantiate(healedFish1, spawnPoint.position, spawnPoint.rotation);
                    break;
                case 2:
                    Instantiate(healedFish2, spawnPoint.position, spawnPoint.rotation);
                    break;
                default:
                    Debug.LogWarning("Invalid fish variant in hospital");
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.ContainsInsensitive("fish")) // honestly a dumb way of checking for fish
        {
            if (fishQueue.Count < capacity
            && collider.GetComponent<FishDespawning>().is_alive)
            {
                Destroy(collider.gameObject);

                int variant = 1;
                fishQueue.Enqueue(new FishPatient(Time.time + healingTime, variant));
            }
            else
            {
                collider.GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }
    }

}
