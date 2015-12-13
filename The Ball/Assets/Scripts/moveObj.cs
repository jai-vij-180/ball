using UnityEngine;
using System.Collections;

public class moveObj : MonoBehaviour {

	public float distanceMove;

	bool reach;
	float currentPos;
	float maxY;
	float minY;
	float x;
	float z;
	// Use this for initialization
	void Start () {
		currentPos = transform.position.y;
		maxY = currentPos + distanceMove;
		minY = currentPos - distanceMove;

	}
	
	// Update is called once per frame
	void Update () {
	if (currentPos <= maxY && !reach)
		{
			transform.Translate( Vector3.up * Time.deltaTime * 5 );
			if(transform.position.y + 2f >= maxY)
			{
				reach = true ;
			}
		}
	if (currentPos >= minY && reach ) {
			transform.Translate( Vector3.down * Time.deltaTime * 5);
			if(transform.position.y - 2 <= minY)
			{
				reach = false ;
			}
		}
	}
}
