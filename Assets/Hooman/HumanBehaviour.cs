using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanBehaviour : MonoBehaviour
{
    public GameObject hand; // Reference to the hand GameObject
    public GameObject[] trashItems; // The item game object
    public Transform[] spawnPoints; // Array of spawn points for the human
    public Transform[] targetPoints; // Array of target points inside the map for the human

    [Tooltip("Minimum time for spawning.")]
    public float minSpawnTime = 5f; // Minimum time for spawning
    
    [Tooltip("Maximum time for spawning.")]
    public float maxSpawnTime = 15f; // Maximum time for spawning
    
    [Tooltip("Walking speed.")]
    public float walkSpeed = 2f; // Walking speed
    
    [Tooltip("Delay before throwing the item.")]
    public float throwDelay = 2f; // Delay before throwing the item

    private bool isSurprised = false;
    private bool isHoldingItem = false;
    private bool hasRotated = false;
    private Vector3 targetPosition;
    private Coroutine throwCoroutine;

    private Animator animator;
    private Animator handAnimator;
    private GameObject item;

    private static HumanBehaviour currentHuman; // Static reference to the current human

    private void Awake()
    {
        hand.SetActive(false);
        for(int i = 0; i < trashItems.Length; i++){
            trashItems[i].SetActive(false);
        }

        animator = GetComponent<Animator>();
        handAnimator = hand.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StartCoroutine(SpawnHuman());
    }

    private IEnumerator SpawnHuman()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            // Check if there is already a human in the scene
            if (currentHuman == null)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject newHuman = Instantiate(gameObject, spawnPoint.position, Quaternion.identity);
                HumanBehaviour humanBehaviour = newHuman.GetComponent<HumanBehaviour>();
                humanBehaviour.StartBehavior();
                currentHuman = humanBehaviour; // Set the current human reference
            }
        }
    }

    public void StartBehavior()
    {
        isHoldingItem = true;
        hand.SetActive(true);
        SpawnRandomTrash();
        targetPosition = targetPoints[Random.Range(0, targetPoints.Length)].position;
        SetAnimatorParameters(isWalking: true, isThrowing: false, isSurprised: false, isHaveTrash: true);
        SetHandAnimatorParameters(isWalking: true, isThrowing: false, isSurprised: false, isHaveTrash: true);
    }

    private void SpawnRandomTrash(){
        // Destroy the current item if it exists
        if (item != null)
        {
            Destroy(item);
        }

        // Instantiate a random trash item
        int randomIndex = Random.Range(0, trashItems.Length);
        item = Instantiate(trashItems[randomIndex], hand.transform);
        item.SetActive(true);
        // trashItems[randomIndex].SetActive(true);
        item.GetComponent<Collider2D>().enabled = false; // Disable collision while holding
   
    }

    private void Update()
    {
        if (isSurprised)
        {
            WalkOut();
        }
        else if (isHoldingItem)
        {
            WalkTowardsTarget();
        }
    }

    private void WalkTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.2f && throwCoroutine == null)
        {
            throwCoroutine = StartCoroutine(ThrowItem());
        }
    }

    private IEnumerator ThrowItem()
    {
        SetAnimatorParameters(isWalking: false, isThrowing: true, isSurprised: false, isHaveTrash: true);
        SetHandAnimatorParameters(isWalking: false, isThrowing: true, isSurprised: false, isHaveTrash: true);

        yield return new WaitForSeconds(throwDelay);

        // Move item to the human's current target position
        item.transform.SetParent(null);
        item.SetActive(true);
        item.transform.position = targetPosition;
        item.GetComponent<Collider2D>().enabled = true; // Enable collision after throwing
        item.GetComponent<Rigidbody2D>().isKinematic = false; 

        yield return new WaitForSeconds(0.5f); 

        isHoldingItem = false;
        hand.SetActive(false);
        
        SetAnimatorParameters(isWalking: true, isThrowing: false, isSurprised: false, isHaveTrash: false);
        // SetHandAnimatorParameters(isWalking: false, isThrowing: false, isSurprised: false, isHaveTrash: false);

        WalkOut();
    }

    public IEnumerator Wenk()
    {
        if (!isSurprised)
        {
            isSurprised = true;
            SetAnimatorParameters(isWalking: false, isThrowing: false, isSurprised: true, isHaveTrash: false);
            SetHandAnimatorParameters(isWalking: false, isThrowing: false, isSurprised: true, isHaveTrash: false);
            hand.SetActive(true);
            if (throwCoroutine != null)
            {
                StopCoroutine(throwCoroutine);
            }
            yield return new WaitForSeconds(0.5f);
            WalkOut();
        }
    }

    private void WalkOut()
    {
        if (!hasRotated)
        {
            animator.transform.Rotate(0, 180, 0);
            hasRotated = true;
        }

        // Set the target position to be one of the spawn points, or a custom position outside the map
        Vector3 outOfMapPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

        SetAnimatorParameters(isWalking: true, isThrowing: false, isSurprised: false, isHaveTrash: false);
        hand.SetActive(false);
        // SetHandAnimatorParameters(isWalking: false, isThrowing: false, isSurprised: false, isHaveTrash: false);

        StartCoroutine(MoveToPosition(outOfMapPosition));
    }

    private IEnumerator MoveToPosition(Vector3 position)
    {
        while (Vector3.Distance(transform.position, position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, walkSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        currentHuman = null; // Clear the current human reference when the human is destroyed
    }

    private void SetAnimatorParameters(bool isWalking, bool isThrowing, bool isSurprised, bool isHaveTrash)
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isThrowing", isThrowing);
        animator.SetBool("isSurprised", isSurprised);
        animator.SetBool("isHaveTrash", isHaveTrash);
    }

    private void SetHandAnimatorParameters(bool isWalking, bool isThrowing, bool isSurprised, bool isHaveTrash)
    {
        handAnimator.SetBool("isWalking", isWalking);
        handAnimator.SetBool("isThrowing", isThrowing);
        handAnimator.SetBool("isSurprised", isSurprised);
        handAnimator.SetBool("isHaveTrash", isHaveTrash);
    }
}
