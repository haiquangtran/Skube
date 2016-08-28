using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    public AudioSource explosion_player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("PLAYER CUBE");
        if (other.collider.tag == Constants.Tags.ENEMY_TAG)
        {
            explosion_player.Play();
            Destroy(other.gameObject);

            //We have colided with an enemy 
            Lives.NumberOfLives--;

            // Game over
            if (Lives.NumberOfLives <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("YOU LOOSE");
        Application.LoadLevel(Application.loadedLevel);
    }
}
