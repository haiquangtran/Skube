using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameController : MonoBehaviour
{

    // Use this for initialization
    public GameObject enemyPrefab;
    private ArrayList enemyCubes = new ArrayList();
    private ArrayList deletedEnemyCubes = new ArrayList();

    public void Start()
    {
        // Generate new enemies every second
        float interval = 2f;
        InvokeRepeating("GenerateEnemyCubes", 0, interval);
    }

    // Update is called once per frame
    public void Update()
    {
        deletedEnemyCubes = new ArrayList();

        // Animate enemies
        foreach (GameObject enemyCube in enemyCubes)
        {
            if(enemyCube != null)
            {
                AnimateEnemyCube(enemyCube);
            }

            if (IsOutOfWorldBounds(enemyCube))
            {
                deletedEnemyCubes.Add(enemyCube);
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

    private void GenerateEnemyCubes()
    {
        for (int i = 0; i < Constants.World.NUM_OF_ENEMIES; i++)
        {
            var startX = Random.Range(Constants.World.MIN_X, Constants.World.MAX_X);
            var startY = Random.Range(Constants.World.MIN_Y, Constants.World.MAX_Y);
            enemyCubes.Add(Instantiate(enemyPrefab, new Vector3(startX, startY, Constants.World.MAX_Z), Quaternion.identity));
        }
    }

    private void AnimateEnemyCube(GameObject enemyCube)
    {
        // Move
        Vector3 newPosition = new Vector3(0, 0, Constants.World.ENEMY_SPEED);
        enemyCube.transform.position += newPosition;

        // Rotation
        Vector3 rotationVector = new Vector3(Random.Range(-200.0f, 0.0f), 0, 0);
        enemyCube.transform.Rotate(rotationVector * Time.deltaTime);
    }

}
