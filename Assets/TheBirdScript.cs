using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 1;
    public LogicScript logic;
    public bool birdActive = true;
    public int endOfScreen = 15;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdActive)
            myRigidBody.velocity = Vector2.up * flapStrength;

        if (transform.position.y < -endOfScreen || transform.position.y > endOfScreen)
        {
            logic.gameOver();
            birdActive = false;
        }

        if (!birdActive)
        {
            transform.position = new Vector3(transform.position.x, -20, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdActive = false;
    }
}
