using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script ends the game as well as setting the ground behaviour
public class GroundBehaviour : MonoBehaviour
{
    static Rigidbody rb;
    public static Collider collider;

    public GameObject ball;
    public GameObject finalRose;
    public GameObject aimPoint;

    public Camera camera;
    public GameObject gameOver;
    public GameObject scoreText;
    private float rotateSpeed;

    public AudioClip endMusic;

    private int distance;
    public static float zPosition;

    public static bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        rotateSpeed = 0.5f;
        distance = 120;
        zPosition = rb.transform.position.z;
    }

    void Update()
    {
        transform.Rotate(0,0,rotateSpeed); //Spinning effect 
        if(rb.transform.position.z < ball.transform.position.z - 7) //-7 is to delay the moving to make it look like there are different grounds instead of moving the same ground 
        {
            if(SkullBehaviour.isLost == false)
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z + distance);
                aimPoint.transform.position = new Vector3(Random.Range(-4,16), Random.Range(-18,1), aimPoint.transform.position.z); //It's randomly spawned within the ground bounds

                SkullBehaviour.speed += 0.8f;
                SkullBehaviour.rotateSpeed += 3.0f;
                rotateSpeed += 0.03f;
                zPosition = rb.transform.position.z;

                SkullBehaviour.isLost = true; //Set to be true by default, but if the player collides with the destination, it turns to false
            } else //If the game is lost
            {
                isGameOver = true; 
                gameOver.SetActive(true);
                scoreText.SetActive(false);
                Destroy(this.gameObject);

                //End screen effects
                Cam.ChangeMusic(endMusic);                
                camera.backgroundColor = Color.Lerp(Color.black, Color.black, 3.0f);
                GameObject b = Instantiate(finalRose) as GameObject;
                b.transform.position = new Vector3(SkullBehaviour.ballBody.transform.position.x+15, SkullBehaviour.ballBody.transform.position.y+65, SkullBehaviour.ballBody.transform.position.z + distance*2 + 150);
            }
        }  
    }
}
