using UnityEngine;
using System.Collections;

public class BackChange : MonoBehaviour {
    Color current;
    Color final;
    float t;
    public Camera cam;
	// Use this for initialization
	void Start (){
        current = cam.backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t >= 3)
        {
            final.r = Random.value;
            final.g = Random.value;
            final.b = Random.value;
            final.a = Random.value;
            cam.backgroundColor = Color.Lerp(current, final, 0.75f);
            current = final;
            t = 0.0f;
        }
	}
}
