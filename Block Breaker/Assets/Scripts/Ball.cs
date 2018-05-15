using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigi;
    private bool gameStart = false;

    private void Awake()
    {
        rigi = GetComponent <Rigidbody2D>();
    }
    void Start () {
        
        paddle = GameObject.FindObjectOfType<Paddle>();
        if (gameStart == false)
        {
            paddleToBallVector = this.transform.position - paddle.transform.position;
        }


	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStart)
        {
            //If mouse hasn't launched it will be locked to the launch pad
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked");
                rigi.velocity = new Vector2(2f, 10f);
                gameStart = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (gameStart)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            rigi.velocity += tweak;
        }
    }
}
