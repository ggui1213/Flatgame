using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public AudioClip footstepClip; 
    
    private SpriteRenderer spriteRenderer;
    private AudioSource footstepSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        footstepSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
#endif
        }
        
        float horizontal = Input.GetAxis("Horizontal");
        bool isMoving = Mathf.Abs(horizontal) > 0.1f;
        animator.SetBool("isWalking", isMoving);
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        //Restrains to the Players
        if (this.transform.position.x < 0)
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
        if (this.transform.position.x > 560f)
        {
            this.transform.position = new Vector3(560f, 0, 0);
        }
        //flip the sprite
        if (isMovingLeft)
        {
            spriteRenderer.flipX = true;
        }
        // Optionally, unflip the sprite if moving right.
        else if (isMovingRight)
        {
            spriteRenderer.flipX = false;
        }
        bool isWalking = isMovingLeft || isMovingRight;
        animator.SetBool("isWalking", isWalking);
        if (isMoving)
        {
            // If the player is moving and the footstep sound is not playing, start it.
            if (!footstepSource.isPlaying)
            {
                footstepSource.Play();
            }
        }
        else
        {
            // If the player stops moving, stop the footstep sound.
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
        }
        Vector3 pos = transform.position;
        pos.y = -1f;
        transform.position = pos;
    }
}
