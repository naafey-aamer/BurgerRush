using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class winCondition : MonoBehaviour
{
    public string LoseSceneName;
    public string WinSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToNextScene() {

        gameFlow.numOfCustomers = 0;
        cookManagerGameFlow.cookedPatties = 0;
        
        if (gameFlow.winCondition == false) {
            SceneManager.LoadScene(LoseSceneName);
        } 
        else {
            gameFlow.winCondition = true;
            SceneManager.LoadScene(WinSceneName);
        }
    }
}
