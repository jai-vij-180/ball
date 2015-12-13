using UnityEngine;
using System.Collections;

public class Ball_Movement : MonoBehaviour {
	public float moveSpeed;
	public float jumpPower;
	public float jumpAddPerSecond;
    public float jumpLimit;
    public GameObject ball;

    GameObject ball2;
    bool split;
	bool bounce;
	int j=1;
	bool right = true;
    bool merge;
    private float posX;
    private float posY;
    private float posZ;
    private int i = 1;
	private bool isSpawn;
	private bool flap;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {

        //split mechanim
        if(split == true)
        {
            ballSplit();
            split = false;
        }
        //merge after split
        if(merge == true)
        {
            ballMerge();
            merge = false;
        }
		
        //gravity mechanim
        if( i %2 == 0)
        {
            Physics.gravity = new Vector3(0, 40f, 0);
        }
        else
        {
            //Physics.gravity = new Vector3(0,-150f, 0);
        }

        if (Input.GetMouseButton(0))
        {
            jumpPower += jumpAddPerSecond;
            
        }
		if (Input.GetMouseButtonUp (0) && flap == true) {

            jump();
            
		}
	}

    void FixedUpdate() {

        if(right)
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        

        
           
	}

    void jump()
    {
        if (jumpPower > jumpLimit)
            jumpPower = jumpLimit;


        if (i % 2 == 0)
        {
            j = -1;
            rb.AddForce(0.0f, -1.0f * jumpPower, 0.0f, ForceMode.Impulse);
        }
        else
        {
            j = 1;
            rb.AddForce(0.0f, 1.0f * jumpPower, 0.0f, ForceMode.Impulse);
        }


        jumpPower = 0.0f;
    }

    

    void  ballSplit()
    {
       
        ball2 = (GameObject)Instantiate(ball, transform.position, Quaternion.identity);
        ball2.transform.position = Vector3.Lerp( ball2.transform.position, new Vector3(ball2.transform.position.x, ball2.transform.position.y, ball2.transform.position.z + 5f ), 0.75f);
        //transform.position = Vector3.Lerp(ball2.transform.position, new Vector3(ball2.transform.position.x, ball2.transform.position.y, ball2.transform.position.z - 5f), 0.75f);

    }

    void ballMerge()
    {

        Destroy(ball2);

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "floor")
            flap = true;

        if (collision.gameObject.tag == "kill")
            Application.LoadLevel("ui");
        
		

    }

	void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "last" )
        {
            flap = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
         if (other.gameObject.tag == "gravity")
         {
             i++ ;
         }

         if (other.gameObject.tag == "split")
         {
             split = true;
             Destroy(other);
         }

         if (other.gameObject.tag == "merge")
         {
             merge = true;
             split = false;
             Destroy(other);
         }
    }
}