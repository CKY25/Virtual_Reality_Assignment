using UnityEngine;

public class CarMainMenu : MonoBehaviour
{
    public Transform player;
    public float speed = 5000.0f;
    private bool isMovingForward = false;

    public AudioSource audioSource;
    private bool hasTransitioned = false; 

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the AudioSource is on the same GameObject as this script
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {



        if (isMovingForward)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move the car towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
     
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the car has collided with the player
        if (collision.gameObject.tag == "Player" && !hasTransitioned)
        {
            // Transition to the next scene
            SceneTransitionManager.singleton.GoToSceneAsync(1);


            // Make the car move forward continuously
            isMovingForward = true;

            // Mark that the scene transition has been triggered
            hasTransitioned = true;

            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 forceDirection = transform.position - collision.transform.position;
            forceDirection.y = 1;  // Add upward force
            rb.AddForce(forceDirection.normalized * 500f);
        }
    }
}
