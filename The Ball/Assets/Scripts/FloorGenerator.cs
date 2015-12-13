using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

    public float pos1;
    public float pos2;
    public GameObject ball;
    public GameObject[] floorPref;

    GameObject floorIns;
    GameObject lastFloor;
    Vector3 endPos;

	// Use this for initialization
	void Start () {
        floorIns = Instantiate(floorPref[0], new Vector3(ball.transform.position.x,ball.transform.position.y-5f,ball.transform.position.z), Quaternion.identity) as GameObject;
        lastFloor = GameObject.FindGameObjectWithTag("last");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.x >= lastFloor.transform.position.x)
        {
            
            int randFloor = Random.Range(0, floorPref.Length);
            lastFloor.tag = "floor";
            floorIns = Instantiate(floorPref[randFloor], new Vector3(ball.transform.position.x + 30f, lastFloor.transform.position.y + Random.Range(10, -10),lastFloor.transform.position.z), Quaternion.identity) as GameObject;
            
            lastFloor = GameObject.FindGameObjectWithTag("last");
        }      
	}
}
