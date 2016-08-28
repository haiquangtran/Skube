using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts;
using System;

public class BulletScript : MonoBehaviour {
    public GameObject remainsCube;
    public AudioSource explosion_astroid;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == Constants.Tags.ENEMY_TAG)
        {
            //We have colided with an enemy 
            enemyCollision(other);
            incrementScore(100);
        }
        else if (other.collider.tag == Constants.Tags.POWERUP_TAG)
        {
            Destroy(other.gameObject);       
            powerUpCollision(other);
            incrementScore(50);

        }
    }

    void powerUpCollision(Collision powerUp)
    {
        int turnOffBullets = UnityEngine.Random.Range(0, 3);
        if (turnOffBullets == 1)
        {
            int random = UnityEngine.Random.Range(0, 10);
            if (random == 0)
            {
                ErrorText.errorText = "Null Pointer Exception";
            }
            else if (random == 1)
            {
                ErrorText.errorText = "NPM build passed but failed";
            }
            else if (random == 2)
            {
                ErrorText.errorText = "PHP is undefined";
            }
            else if (random == 3)
            {
                ErrorText.errorText = "Array index out of bounds expcetion";
            }
            else if (random == 4)
            {
                ErrorText.errorText = "Stack overflow exception";
            }
            else if (random == 5)
            {
                ErrorText.errorText = "PixelJam.exe has encounted an exception and needs to close";
            }
            else if (random == 6)
            {
                ErrorText.errorText = "Illegal Argument Exception";
            }
            else if (random == 7)
            {
                ErrorText.errorText = "Class cast exception";
            }
            else if (random == 7)
            {
                ErrorText.errorText = "IOE Exception";
            }
        }
        else if (turnOffBullets == 2)
        {
            Debug.Log("good power up");
            FireFire.doubleBullets = true;
        }
        else
        {
            int random = UnityEngine.Random.Range(0, 10);
            if (random == 0)
            {
                ErrorText.errorText = "Null Pointer Exception";
            }
            else if (random == 1)
            {
                ErrorText.errorText = "NPM build passed but failed";
            }
            else if (random == 2)
            {
                ErrorText.errorText = "PHP is undefined";
            }
            else if (random == 3)
            {
                ErrorText.errorText = "Array index out of bounds expcetion";
            }
            else if (random == 4)
            {
                ErrorText.errorText = "Stack overflow exception";
            }
            else if (random == 5)
            {
                ErrorText.errorText = "PixelJam.exe has encounted an exception and needs to close";
            }
            else if (random == 6)
            {
                ErrorText.errorText = "Illegal Argument Exception";
            }
            else if (random == 7)
            {
                ErrorText.errorText = "Class cast exception";
            }
            else if (random == 7)
            {
                ErrorText.errorText = "IOE Exception";
            }
        }
    }

    void enemyCollision(Collision enemy)
    {
        instantiateFragments();
        Destroy(enemy.gameObject);
        explosion_astroid.Play();
    }

    void instantiateFragments()
    {
        GameObject fragmentHandler;
        fragmentHandler =  Instantiate(remainsCube, transform.position, transform.rotation) as GameObject;

        //Retrieve the Rigidbody component from the instantiated fragments and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = fragmentHandler.GetComponent<Rigidbody>();

        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(fragmentHandler, 2f);

    }

    private void incrementScore(int v)
    {
        Score.score += v;
    }
}
