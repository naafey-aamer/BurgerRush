using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrayComparerAnimator : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }


        bool result = ArrayComparer.CompareArrays();
        // Debug.Log("" + result);
        animator.SetBool("Win", result);

        //update all gameflow variables
        gameFlow.winCondition = result; 

        gameFlow.numOfCustomers = gameFlow.numOfCustomers + 1; 
        gameFlow.idx = 0 ; 
        Debug.Log("" + gameFlow.numOfCustomers);
        // for (int i = 0; i < 13; i++) {
        //     gameFlow.plateValue[i] = 0;
        // }
    }

    
}
