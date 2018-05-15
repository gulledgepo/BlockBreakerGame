using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX, maxX;
    private Ball ball;
	// Use this for initialization
	void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }


	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        float MousPosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(MousPosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, minX, maxX);
        this.transform.position = paddlePos;
    }
}


