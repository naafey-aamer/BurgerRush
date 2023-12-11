using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addToStove : MonoBehaviour
{
    // audio 
    public AudioSource audioSource;

    public GameObject objectToAdd;
    private float removeTimer = 0f;

    private GameObject gameFlowObject ; 
    private cookManagerGameFlow gameFlowInstance ;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
        // Set the audio to loop
        audioSource.loop = true;

        gameFlowObject = GameObject.Find("GameObjectTimer"); 
        gameFlowInstance = gameFlowObject.GetComponent<cookManagerGameFlow>();

        for (int i = 0; i < 4; i++) {
            gameFlowInstance.publicText[i].text = FormatTimer(cookManagerGameFlow.timer[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++) {
            if (cookManagerGameFlow.isTiming[i])
            {
                cookManagerGameFlow.timer[i] += Time.deltaTime;
                UpdateUITimer(i);
            }
        }
    }

    public void OnButtonPress()
    {
        
        Vector3[] spawnPositions = {
            new Vector3(0.176f, 0f, 0.072f),
            new Vector3(-0.125f,0f,0.387f),  
            new Vector3(-0.078f,0f,-0.187f), 
            new Vector3(-0.394f,0f,0.129f)   
        };

        int found = 0;
        int i;
        for (i = 0; i < 4; i++) {
            if (cookManagerGameFlow.stoves[i] == null) {
                GameObject newObject = Instantiate(objectToAdd, spawnPositions[i], Quaternion.identity);
                newObject.SetActive(true); // spawn object above stove at position i
                cookManagerGameFlow.stoves[i] = newObject;
                Debug.Log("Stove Number taken: " + i);
                found = 1;

                // play sound
                audioSource.Play();
                cookManagerGameFlow.cooking = cookManagerGameFlow.cooking + 1; 

                break;
            }
        }

        if (found == 0) {
            Debug.Log("invalid action: no more space on stove");
        }
        else {
            cookManagerGameFlow.canRemove[i] = false;
            StartCoroutine(RemovePattyCooldown(i));
        }

    }

    // Coroutine for the removal cooldown timer
    private IEnumerator RemovePattyCooldown(int i)
    {
        StartTimer(i);
        yield return new WaitForSeconds(removeTimer);
        cookManagerGameFlow.canRemove[i] = true; // Enable patty removal after the timer finishes
    }

    public void removePatty(int stoveIndex) 
    {

        if (cookManagerGameFlow.canRemove[0] == true && stoveIndex == 1 && cookManagerGameFlow.stoves[0] != null)
        {
            Destroy(cookManagerGameFlow.stoves[0]);
            cookManagerGameFlow.stoves[0] = null;
            cookManagerGameFlow.cookedPatties = cookManagerGameFlow.cookedPatties + 1;
            StopTimer(0);

            cookManagerGameFlow.cooking = cookManagerGameFlow.cooking - 1; 
            checkStop();

            Debug.Log("cooked patties: " + cookManagerGameFlow.cookedPatties);
        }
        else if (cookManagerGameFlow.canRemove[1] == true && stoveIndex == 2 && cookManagerGameFlow.stoves[1] != null)
        {
            Destroy(cookManagerGameFlow.stoves[1]);
            cookManagerGameFlow.stoves[1] = null;
            cookManagerGameFlow.cookedPatties = cookManagerGameFlow.cookedPatties + 1;
            StopTimer(1);
            
            cookManagerGameFlow.cooking = cookManagerGameFlow.cooking - 1; 
            checkStop();

            Debug.Log("cooked patties: " + cookManagerGameFlow.cookedPatties);
        }
        else if (cookManagerGameFlow.canRemove[2] == true && stoveIndex == 3 && cookManagerGameFlow.stoves[2] != null)
        {
            Destroy(cookManagerGameFlow.stoves[2]);
            cookManagerGameFlow.stoves[2] = null;
            cookManagerGameFlow.cookedPatties = cookManagerGameFlow.cookedPatties + 1;
            StopTimer(2);
            
            cookManagerGameFlow.cooking = cookManagerGameFlow.cooking - 1; 
            checkStop();

            Debug.Log("cooked patties: " + cookManagerGameFlow.cookedPatties);
        }
        else if (cookManagerGameFlow.canRemove[3] == true && stoveIndex == 4 && cookManagerGameFlow.stoves[3] != null)
        {
            Destroy(cookManagerGameFlow.stoves[3]);
            cookManagerGameFlow.stoves[3] = null;
            cookManagerGameFlow.cookedPatties = cookManagerGameFlow.cookedPatties + 1;
            StopTimer(3);
            
            cookManagerGameFlow.cooking = cookManagerGameFlow.cooking - 1; 
            checkStop();

            Debug.Log("cooked patties: " + cookManagerGameFlow.cookedPatties);
        }

    }


    private void StartTimer(int i)
    {
        cookManagerGameFlow.isTiming[i] = true;
    }

    private void StopTimer(int i)
    {
        cookManagerGameFlow.isTiming[i] = false;
        cookManagerGameFlow.timer[i] = 0f;
        UpdateUITimer(i);
    }

    void UpdateUITimer(int i)
    {
        gameFlowInstance.publicText[i].text = FormatTimer(cookManagerGameFlow.timer[i]);
    }

    string FormatTimer(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void checkStop() {
        if (cookManagerGameFlow.cooking <= 0) {
            audioSource.Stop(); // stop sound
        }
    }
}
