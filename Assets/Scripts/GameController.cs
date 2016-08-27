using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    private ArrayList enemyCubes = new ArrayList();

    void Start()
    {
        for (int i = 0; i < Constants.World.NUM_OF_ENEMIES; i++)
        {
            var enemyGap = Constants.World.ENEMY_WIDTH;
            var offsetToMiddle = (Constants.World.NUM_OF_ENEMIES / 2) * (Constants.World.ENEMY_WIDTH + enemyGap);
            enemyCubes.Add(Instantiate(prefab, new Vector3(i * (Constants.World.ENEMY_WIDTH + enemyGap) - offsetToMiddle, 0, Constants.World.MAX_Z), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update () {
	    foreach(GameObject enemyCube in enemyCubes)
        {
            Vector3 newPosition = new Vector3(0, 0, Constants.World.ENEMY_SPEED);
            enemyCube.transform.position += newPosition;
        }
	}

  

}
