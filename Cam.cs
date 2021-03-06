using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script makes camera follow the player, starts the game and changes the background music.
public class Cam : MonoBehaviour
{
    public GameObject dummySkull; //Start gui components
    public GameObject gui;

    public Transform target; //Follows the skull
    public Vector3 offset; //Set in runtime

    public bool isGameActive;
    public GameObject allGame;

    static AudioSource audioSource;
    public AudioClip gameClip;

    void Start()
    {
        isGameActive = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isGameActive == false && (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))) //Starts the game
        {
            gui.SetActive(false);
            dummySkull.SetActive(false);

            allGame.SetActive(true);
            isGameActive = true;

            ChangeMusic(gameClip);
        }
        if(GroundBehaviour.isGameOver && Input.GetKey("z")) //Starts the game again when its over
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GroundBehaviour.isGameOver = false;
        }
    }

    void LateUpdate() //Runs right after
    {
        if(GroundBehaviour.isGameOver == false) 
        {
            transform.position = target.position + offset;
        }
        else 
        {
            Destroy(GameObject.FindWithTag("Donut")); //Destroying all the donuts if the game is over
        }
    }

    public static void ChangeMusic(AudioClip clip) //It's used in the ground class as well 
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
