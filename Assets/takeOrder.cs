using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Animator customerAnimator;

    void OnMouseUpAsButton()
    {
        customerAnimator = GetComponent<Animator>();
        if (customerAnimator != null)
        {
            customerAnimator.SetBool("take_order", true);
            StartCoroutine(ResetTakeOrderBool(5.167f)); // Start a coroutine to reset the bool after 5.167 seconds
        }
    }

    private System.Collections.IEnumerator ResetTakeOrderBool(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (customerAnimator != null)
        {
            Debug.Log("" + delay + "");
            customerAnimator.SetBool("taken_order", true); // Reset the bool after the delay
        }
    }
}
