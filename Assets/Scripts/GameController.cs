using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    private ArrayList cubes = new ArrayList();
    public int gameX = 1000;
    public int gameZ = 1000;
    public int gameY = 500;

    void Start()
    {
        for (int i = 0; i < 10; i++)
            cubes.Add(Instantiate(prefab, new Vector3(i * 2.0f - 10.0f, 0, 0), Quaternion.identity));
    }

    // Update is called once per frame
    void Update () {
	    foreach(GameObject c in cubes)
        {
            Vector3 temp = new Vector3(0, 0, -0.1f);
            c.transform.position += temp;
        }
	}
}
