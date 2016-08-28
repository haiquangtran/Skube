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
            Score.score += 50;

            int turnOffBullets = UnityEngine.Random.Range(0, 3);
            if(turnOffBullets == 1)
            {
                FireFire.turnOffBullets = true;
                Debug.Log("bad power up");
            }
            else if (turnOffBullets == 2)
            {
                Debug.Log("good power up");
                FireFire.doubleBullets = true;
            }
            else
            {
                SceneManager.LoadScene("NPEscreen");       
            }
            powerUpCollision(other);
            incrementScore(50);

        }
    }

    void powerUpCollision(Collision powerUp)
    {
        Destroy(powerUp.gameObject);
        float turnOffBullets = UnityEngine.Random.Range(0, 1);
        if (turnOffBullets <= 0.5)
        {
            FireFire.turnOffBullets = true;
            Debug.Log("bad power up");
        }
        else
        {
            Debug.Log("good power up");
            FireFire.doubleBullets = true;
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
        Destroy(fragmentHandler, 2.0f);

    }

    private void incrementScore(int v)
    {
        Score.score += v;
    }
}
