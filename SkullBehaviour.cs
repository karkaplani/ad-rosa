using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script makes the skull playable, and informs the ground if the game is over according to its collision with the destination.
public class SkullBehaviour : MonoBehaviour
{
    public static Rigidbody ballBody;
    public GameObject ground;
    public GameObject bum;

    AudioSource audioSource;
    public AudioClip collectDonut;

    public static float speed;
    public static float rotateSpeed;
    public static int score;
    public static bool isLost = true;

   void Start()
    {
        speed = 10.0f; //Resetting when game starts again
        rotateSpeed = 50.0f;
        ballBody = GetComponent<Rigidbody>();   
        audioSource = GetComponent<AudioSource>(); 
        score = 0;
    }

    void Update()
    {
        //To achieve the spinning effect
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); 
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left * rotateSpeed/2 * Time.deltaTime);
        //Moving the skull with arrow keys
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        ballBody.velocity = new Vector3(xMov, yMov, 1) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dest")
        {
            isLost = false;
            score += 5;
        }
        if(other.gameObject.tag == "Donut") 
        {
            score += 1;
            this.audioSource.PlayOneShot(collectDonut);
            GameObject b = Instantiate(bum) as GameObject; //Destroying effect

            b.transform.position = new Vector3(other.transform.position.x+1, other.transform.position.y-2, other.transform.position.z-3.6f); //Arranged to make the effect placed as the donut's position
            other.transform.position = new Vector3(Random.Range(-6,18), Random.Range(-20,3), Random.Range(GroundBehaviour.zPosition+50, GroundBehaviour.zPosition+100)); //Donut's not destroyed, instead it's position changes 
            Destroy(b, 3.0f);
        }
    }
}
