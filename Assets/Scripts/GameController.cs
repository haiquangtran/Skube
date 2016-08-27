using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    private ArrayList cubes = new ArrayList();
    public int gameX = 1000;
    public int gameZ = 1000;
    public int gameY = 500;
    private ArrayList enemyCubes = new ArrayList();
    private GameObject playerCube;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            enemyCubes.Add(Instantiate(prefab, new Vector3(i * 2.0f - 10.0f, 0, 0), Quaternion.identity));
        }

        //player cube
        //playerCube = (GameObject)Instantiate(prefab, new Vector3(0, 0, -5), Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
	    foreach(GameObject c in enemyCubes)
        {
            Vector3 temp = new Vector3(0, 0, -0.05f);

            c.transform.position += temp;
        }
	}

  

}
