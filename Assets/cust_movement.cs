using UnityEngine;
using UnityEngine.UI;

public class CustomerBehavior : MonoBehaviour
{
    private Animator customerAnimator;
    public Transform counter;
    public Transform waitQueueStartPosition;
    public float stopDistance = 0.0f; // Increase the spacing
    public float orderDelay = 3.0f;
    public float firstCustomerDelay = 4.0f; // Delay for the first customer
    public float moveSpeed = 2.0f;
    public OrderGenerator orderGenerator; // Reference to the OrderGenerator script
    public OrderDisplay orderDisplay; // Reference to the OrderDisplay script
    public Button orderButton; // Reference to the Button script

    private Vector3 currentPosition;
    private Vector3 counterPosition;
    private Vector3 waitQueuePosition;
    private float elapsedTime = 0.0f;
    private bool isAtCounter = false;
    private bool hasOrdered = false;
    private bool isFirstCustomer = false;
    private static CustomerBehavior activeCustomer = null;
    // Static variable to keep track of the last position in the queue

    private static Vector3 lastQueuePosition = Vector3.zero;

    private void Start()
    {
        customerAnimator = GetComponent<Animator>();
        if (customerAnimator == null)
        {
            Debug.LogError("Animator component not found!");
        }
        customerAnimator.SetBool("reached", false);
        customerAnimator.SetBool("take_order", false);
        customerAnimator.SetBool("taken_order", false);
        currentPosition = transform.position;
        counterPosition = counter.position - new Vector3(0, 0, stopDistance);

        // Initialize the lastQueuePosition if this is the first customer
        if (lastQueuePosition == Vector3.zero)
        {
            lastQueuePosition = waitQueueStartPosition.position;
            isFirstCustomer = true;
        }
        else
        {
            // If not the first customer, set the waitQueuePosition behind the last customer
            lastQueuePosition += new Vector3(0, 0, stopDistance); // Change the axis to line up on
        }

        waitQueuePosition = lastQueuePosition;

        MoveToCounter();


        orderButton.onClick.AddListener(() =>
        {
            if (this == activeCustomer)
            {
                OnOrderReceived();
            }
        });
    }

    private void Update()
    {
        if (!isAtCounter)
        {
            MoveToCounter();
        }
        else if (!hasOrdered)
        {
            orderButton.gameObject.SetActive(true); // Show the button
            activeCustomer = this;            
        }
        else
        {
            orderButton.gameObject.SetActive(false); // Hide the button
            MoveToWaitQueue();
        }
    }

    private void MoveToCounter()
    {
        // Move towards the counter
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, counterPosition, step);

        if (Vector3.Distance(transform.position, counterPosition) < 0.000001f)
        {
            isAtCounter = true;
            elapsedTime = Time.time;
            orderButton.gameObject.SetActive(false); // Hide the button
            customerAnimator.SetBool("reached", true);
        }
    }

    private void MoveToWaitQueue()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waitQueuePosition, step);
    }

private void OnOrderReceived()
{
    hasOrdered = true;

    // Execute this block for the first customer after the delay
    int numberOfComponents = 4; // Adjust this to your desired number of components
    GameObject[] randomOrder = orderGenerator.GenerateRandomOrder(numberOfComponents);
    orderDisplay.UpdateOrderDisplay(randomOrder);

    MoveToWaitQueue();
}

}
