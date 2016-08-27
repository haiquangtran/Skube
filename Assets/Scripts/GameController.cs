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
        GenerateEnemyCubes();
    }

    // Update is called once per frame
    public void Update()
    {
        deletedEnemyCubes = new ArrayList();

        // Animate enemies
        foreach (GameObject enemyCube in enemyCubes)
        {
            AnimateEnemyCube(enemyCube);

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

        // Generate new enemies
        if (enemyCubes.Count == 0)
        {
            GenerateEnemyCubes();
        }
    }

    private bool IsOutOfWorldBounds(GameObject cube)
    {
        var enemyPosition = cube.transform.position;
        return enemyPosition.z < Constants.World.MIN_Z || enemyPosition.z > Constants.World.MAX_Z || enemyPosition.x < Constants.World.MIN_X ||
            enemyPosition.x > Constants.World.MAX_X || enemyPosition.y < Constants.World.MIN_Y || enemyPosition.y > Constants.World.MAX_Y;
    }

    private void GenerateEnemyCubes()
    {
        for (int i = 0; i < Constants.World.NUM_OF_ENEMIES; i++)
        {
            var enemyGap = Constants.World.ENEMY_WIDTH * 2;
            var offsetToMiddle = (Constants.World.NUM_OF_ENEMIES / 2) * (Constants.World.ENEMY_WIDTH + enemyGap);
            GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(i * (Constants.World.ENEMY_WIDTH + enemyGap) - offsetToMiddle, 0, Constants.World.MAX_Z), Quaternion.identity) as GameObject;
            enemyObject.tag = Constants.Tags.ENEMY_TAG;
            enemyCubes.Add(enemyObject);
        }
    }

    private void AnimateEnemyCube(GameObject enemyCube)
    {
        // Move
        Vector3 newPosition = new Vector3(0, 0, Constants.World.ENEMY_SPEED);
        enemyCube.transform.position += newPosition;

        // Rotation
        Vector3 rotationVector = new Vector3(Random.Range(-200.0f, 0.0f), Random.Range(-100.0f, 0f), 0);
        enemyCube.transform.Rotate(rotationVector * Time.deltaTime);
    }

}
