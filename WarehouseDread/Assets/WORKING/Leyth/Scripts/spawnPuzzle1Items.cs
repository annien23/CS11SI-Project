using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class spawnPuzzle1Items : MonoBehaviour
{
    const int MSECS_IN_SEC = 1000;



    /* Public Variables */
    public UnityEvent spookyMusic;

    public float startMsecDelay;
    public int decreaseDelayItemNum;  // Number of items after which to multipy the current delay by delayDecrease
    public float delayDecrease;

    public GameObject[] items;

    public int whackyThreshold;
    public float whackyOdds;

    public int totalNumitems;
    public bool countPlacedItems;
    public int numWrongToTriggerSpookyMusic;

    /* Private Variables */
    private float realMsecDelay;
    private int timeSinceLastSpawn = 0;
    private int numDone = 0;
    private int numWrong = 0;

    // Start is called before the first frame update
    void Start()
    {
        realMsecDelay = startMsecDelay;
    }

   public void Add1Done()
    {
        numDone++;
    }

    public void Add1Wrong()
    {
        numWrong++;
        if (numWrong == numWrongToTriggerSpookyMusic)
        {
            spookyMusic.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += (int)(Time.deltaTime * MSECS_IN_SEC);
        if (timeSinceLastSpawn >= realMsecDelay)
        {
            int itemIndex = Random.Range(0, items.Length);
            GameObject item = GameObject.Instantiate(items[itemIndex]);
            item.transform.position = this.transform.position;
            if (!countPlacedItems)
            {
                numDone++;
            }
            
            // If above the whackyThreshold, do whacky odds
            if (numDone > whackyThreshold)
            {
                if (Random.Range(0,1f) <= whackyOdds)
                {
                    int otherMaterialIndex = Random.Range(0, items.Length);
                    while (otherMaterialIndex == itemIndex)
                    {
                        otherMaterialIndex = Random.Range(0, items.Length);
                    }
                    item.GetComponent<MeshRenderer>().sharedMaterial = items[otherMaterialIndex].GetComponent<MeshRenderer>().sharedMaterial;
                }
            }

            // If time to decrease delay, do so
            if (numDone % decreaseDelayItemNum == 0)
            {
                realMsecDelay *= delayDecrease;
            }
            timeSinceLastSpawn = 0;
        }
        if (numDone >= totalNumitems)
        {
            this.gameObject.SetActive(false);
        }
    }
}
