using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ActivateAnimationOnCondition : MonoBehaviour
{
    public Animator customerAnimator;

    public Animator customerAnimator1;

    public Animator customerAnimator2;
    public Animation animationComponent; // Assign the Animation component reference in the Inspector
    public string animationName; // Name of the animation clip you want to play

    private bool animationStarted = false;

    void Start()
    {
        animationComponent = GetComponent<Animation>();
        // Check if the animation component exists
        if (animationComponent != null)
        {
            // Debug.Log("Object clicked!");
            // Deactivate the animation component initially
            animationComponent.enabled = false;
        }
    }

    void Update()
    {
        // Check your condition here
        bool condition = CheckYourCondition(); // Replace this with your actual condition

        if (condition && animationComponent != null)
        {
            Debug.Log("Object clicked!");
            animationComponent.enabled = true;
            animationComponent.Play(animationName); // Play the specified animation
            StartCoroutine(StartFadeOut(3.042f)); // Start the fade-out after 3.042 seconds
        }
        else
        {
            // Deactivate the animation component if the condition is not met
            if (animationComponent != null)
            {
                animationComponent.enabled = false;
            }
        }
    }

    // Your condition checking function
    bool CheckYourCondition()
    {
        // Access the name from the AnimatorStateInfo object
        Debug.Log(customerAnimator.name + "");
        if (customer_track.character_name == null)
        {
            if (customerAnimator.GetBool("take_order") && customerAnimator.GetBool("reached") && customerAnimator.GetBool("taken_order"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (customer_track.character_name == "mich")
        {
            if (customerAnimator1.GetBool("take_order") && customerAnimator1.GetBool("reached") && customerAnimator1.GetBool("taken_order"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        else
        {
            if (customerAnimator2.GetBool("take_order") && customerAnimator2.GetBool("reached") && customerAnimator2.GetBool("taken_order"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private IEnumerator StartFadeOut(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Perform your fade-out effect here
        // For example, using a UI canvas with an image fading out over time

        // Load the new scene after the fade-out
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // Replace "YourNextSceneName" with the name of your next scene
        SceneManager.LoadScene("cookStation");
    }
}
