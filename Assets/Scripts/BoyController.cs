using UnityEngine;
using UnityEngine.UI; // For UI toolkit

public class BoyController : MonoBehaviour
{
    private Vector3 boyPosition;
    private Transform boyTransform;
    public float speed = 5f; // Default value for variable
    public float directionSpeed = 5f;

    // For sharp movements
    private int lineIndex = 0;
    private float linesDistance = 2.5f;

    // For fancy movement
    private Vector3 movingDirection;

    // Collisions
    private bool alive = true;
    private int points = 0;

    // Coin and GameOver Sounds
    private AudioSource audioSource;
    public AudioClip[] clips; // 0 GotCoin 1 GameOver

    // UI Things
    //[SerializeField] private Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        // Get Position
        //boyPosition = this.gameObject.transform.position;
        //Debug.Log(boyPosition);
        //Debug.Log("Started");

        // Get Transform Completely
        boyTransform = this.transform.GetComponent<Transform>();

        // Set Object position to (0, 0, 8.632f)
        this.transform.position = new Vector3(0, 0, 8.632f);
        Debug.Log("Now in position(SpawnPosition): " + this.transform.position);

        this.audioSource = this.GetComponent<AudioSource>();


        // UI Things
        //scoreText.text = points.ToString();

    }

    // Update is called once per frame
    void Update()
    {


        if (alive)
        {
            //Debug.Log(boyPosition);

            // - Forward Moving
            // - Speed value affect on speed on moving forward
            // - Time.deltatime(Tow Update function call period): 
            // If Update function has delay, and we do'nt had movement in some frames
            // movement must be multiplied by frames that we lost...
            // This also affect on Uniform Movement
            // - space: this rotate and movement is base on what? Self? Or the world?
            boyTransform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            //boyTransform.Translate();

            // Rotate (Just For Ball Objects)
            //boyTransform.Rotate(Vector3.right * speed * 100 * Time.deltaTime);

            //boyPosition = this.transform.position;



            // Sharp Movement
            // When a button Pressed, Do something
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (lineIndex < 1)
                    lineIndex++;

                //Debug.Log("Position now in right arrow(boyPosition)            " + boyPosition);
                //Debug.Log("Position now in right arrow(TransForm.Position)     " + this.transform.position);
                //Debug.Log("Position now in right arrow(BoyTransForm.Position)  " + boyTransform.position);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (lineIndex > -1)
                    lineIndex--;
            }

            // Hard Move
            // Renew the x-position
            //boyPosition = new Vector3(lineIndex * linesDistance, boyTransform.position.y, boyTransform.position.z);
            // Set new x-position value to Object
            //this.transform.position = boyPosition;

            // Soft Move
            transform.position = Vector3.MoveTowards(
                this.transform.position,
                new Vector3(
                    linesDistance * lineIndex,
                    this.transform.position.y,
                    this.transform.position.z
                    ), 
                Time.deltaTime * directionSpeed
                );




            // Fancy Movement
            // Use ProjectSettings.axises for maount of pressing button.
            // Moving direction just value the direction of movement, not the speed.
            //movingDirection.z = 1; // Forward / Backward
            //movingDirection.y = 0; // Up / Down
            //movingDirection.x = Input.GetAxis("Horizontal"); // Left / Right  ("Axis.Name")

            //boyTransform.Translate(movingDirection * speed * Time.deltaTime, Space.World);
            //boyTransform.Rotate(Vector3.right * speed * 100 * Time.deltaTime); // Just for Ball Objects

        } // if alive
    } // Update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {
            Debug.Log("Enemy accident...");
            Debug.Log("Game Over");

            audioSource.clip = clips[1]; // GameOver Clip
            audioSource.Play();

            alive = false;
        } // if enemy
        
        
    } // onCollisionEnter

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("gold"))
        {
            //Debug.Log("Triggered...");
            points++;
            //scoreText.text = points.ToString();
            //Debug.Log("Points: " + points);

            audioSource.clip = clips[0]; // GotCoin Clip
            audioSource.Play();

            Destroy(other.gameObject);
        } // if banana

    } // onTriggerEnter

    // Reset 
    public void ResetPoints()
    {
        points = 0;
        //scoreText.text = points.ToString();
    }

}


// Awake() 1
// Start() 1
// Update() PerFrame
// LateUpdate()
