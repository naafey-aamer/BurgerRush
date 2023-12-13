using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ClickableObject4 : MonoBehaviour
{
    private Animator customerAnimator;
    public string nextSceneName;

    void OnMouseUpAsButton()
    {
        customerAnimator = GetComponent<Animator>();
        if (customerAnimator != null)
        {
            StartCoroutine(ResetTakeOrderBool(1f)); // Start a coroutine to reset the bool after 5.167 seconds
        }
    }

    private System.Collections.IEnumerator ResetTakeOrderBool(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (customerAnimator != null)
        {
            Debug.Log(customer_track.character_name + "");
            if (customer_track.character_name == "mich")
            {
                customer_track.character_name = "boy";
            }

            else if (customer_track.character_name == "pink")
            {
                    customer_track.character_name = "mich";
            }
            MoveToNextScene();
        }
    }

        public void MoveToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
