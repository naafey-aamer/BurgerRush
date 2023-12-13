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

        //update all gameflow variables
        gameFlow.winCondition = result; 
        gameFlow.numOfCustomers = gameFlow.numOfCustomers + 1; 
        gameFlow.idx = 0 ; 
        for (int i = 0; i < 13; i++) {
            gameFlow.plateValue[i] = 0;
        }
        

        animator.SetBool("Win", result);

    }

    
}
