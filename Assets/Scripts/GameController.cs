﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts;


public class GameController : MonoBehaviour
{
    // Use this for initialization
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public GameObject powerUpText;
    public AudioSource background_music;
    private ArrayList enemyCubes = new ArrayList();
    private ArrayList powerUps = new ArrayList();
    private ArrayList deletedEnemyCubes = new ArrayList();
    private float timer = 0.0f;
    private float enemySpeed = Constants.World.ENEMY_MIN_SPEED;
    public static bool showNPEscreen = false;

    public void Start()
    {
        // Generate new enemies every second
        float interval = 1.5f;
        InvokeRepeating("GenerateEnemyCubes", 0, interval);
        InvokeRepeating("GenerateDirectHits", 0, Random.Range(3.0f, 5.0f));

        float powerUpInterval = 10f;
        InvokeRepeating("GeneratePowerUps", 0, powerUpInterval);

        float resetPowerUpChangesInterval = 5f;
        InvokeRepeating("ResetPowerUps", 15f, resetPowerUpChangesInterval);

        //default no error
        ErrorText.errorText = "";

        background_music.Play();

    }

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;
        deletedEnemyCubes = new ArrayList();

        // Speed up every 10 seconds
        IncreaseEnemySpeed(5.0f);

        // Animate enemies
        foreach (GameObject enemyCube in enemyCubes)
        {
            if (enemyCube != null)
            {
                AnimateEnemyCube(enemyCube);
            }

            if (IsOutOfWorldBounds(enemyCube))
            {
                deletedEnemyCubes.Add(enemyCube);
            }
        }

        foreach (GameObject powerUp in powerUps)
        {
            if (powerUp != null)
            {
                AnimatePowerUp(powerUp);
            }

            if (IsOutOfWorldBounds(powerUp))
            {
                Destroy(powerUp);
            }
        }

        foreach (GameObject enemy in deletedEnemyCubes)
        {
            enemyCubes.Remove(enemy);
            Destroy(enemy);
        }

    }

    private bool IsOutOfWorldBounds(GameObject cube)
    {
        if (cube != null)
        {
            var enemyPosition = cube.transform.position;
            return enemyPosition.z < Constants.World.MIN_Z || enemyPosition.z > Constants.World.MAX_Z || enemyPosition.x < Constants.World.MIN_X ||
                enemyPosition.x > Constants.World.MAX_X || enemyPosition.y < Constants.World.MIN_Y || enemyPosition.y > Constants.World.MAX_Y;
        }
        return true;
    }

    private void GeneratePowerUps()
    {
        // Power up goes directly to player
        enemyCubes.Add(Instantiate(powerUpPrefab, new Vector3(0, 0, Constants.World.MAX_Z), Quaternion.identity));

        // Random power ups
        for (int i = 1; i < Constants.World.NUM_OF_POWERUPS; i++)
        {
            var startX = Random.Range(Constants.World.MIN_X, Constants.World.MAX_X);
            var startY = Random.Range(Constants.World.MIN_Y, Constants.World.MAX_Y);
            enemyCubes.Add(Instantiate(powerUpPrefab, new Vector3(startX, startY, Constants.World.MAX_Z), Quaternion.identity));
        }
    }

    private void GenerateEnemyCubes()
    {
        for (int i = 0; i < Constants.World.NUM_OF_ENEMIES; i++)
        {
            var startX = Random.Range(Constants.World.MIN_X, Constants.World.MAX_X);
            var startY = Random.Range(Constants.World.MIN_Y, Constants.World.MAX_Y);
            GameObject enemyCube = Instantiate(enemyPrefab, new Vector3(startX, startY, Constants.World.MAX_Z), Quaternion.identity) as GameObject;
            if (enemyCube != null)
            {
                DecorateEnemyCube(enemyCube);
                enemyCubes.Add(enemyCube);
            }
        }
    }

    private void GenerateDirectHits()
    {
        // Generate enemies that go directly to player between 2-8 seconds.
        Invoke("GenerateDirectHitEnemyCube", Random.Range(3.0f, 5.0f));
    }

    private void GenerateDirectHitEnemyCube()
    {
        // Always hits the player
        GameObject hitPlayerCube = Instantiate(enemyPrefab, new Vector3(0, 0, Constants.World.MAX_Z), Quaternion.identity) as GameObject;
        DecorateEnemyCube(hitPlayerCube);
        enemyCubes.Add(hitPlayerCube);
    }

    private void DecorateEnemyCube(GameObject enemyCube)
    {
        // Size
        var scaleRange = Random.Range(Constants.World.ENEMY_MIN_SIZE, Constants.World.ENEMY_MAX_SIZE);
        Vector3 scaleVector = new Vector3(scaleRange, scaleRange, scaleRange);
        enemyCube.transform.localScale = scaleVector;
    }

    private void AnimateEnemyCube(GameObject enemyCube)
    {
        // Move
        Vector3 newPosition = new Vector3(0, 0, enemySpeed);
        enemyCube.transform.position += newPosition;

        // Rotation
        Vector3 rotationVector = new Vector3(Random.Range(-200.0f, 0.0f), Random.Range(-100.0f, 0.0f), 0);
        enemyCube.transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void IncreaseEnemySpeed(float intervalSeconds)
    {
        // Increase speed every 5 seconds
        if (timer > intervalSeconds)
        {
            float enemySpeedPos = Mathf.Abs(enemySpeed);
            if (enemySpeedPos < Mathf.Abs(Constants.World.ENEMY_MAX_SPEED) && enemySpeedPos >= Mathf.Abs(Constants.World.ENEMY_MIN_SPEED))
            {
                enemySpeed += Constants.World.ENEMY_SPEED_INCREMENT;
            }
            timer = 0.0f;
        }
    }

    private void AnimatePowerUp(GameObject powerUp)
    {
        Vector3 newPosition = new Vector3(0, 0, Constants.World.ENEMY_MAX_SPEED);
        powerUp.transform.position += newPosition;
    }

    private void ResetPowerUps()
    {
        FireFire.turnOffBullets = false;
        FireFire.doubleBullets = false;
        ErrorText.errorText = "";
    }


}
