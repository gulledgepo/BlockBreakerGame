using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private bool isBreakable;
    private int timesHit;
    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            PuffSmoke();
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smokeColored = smokePuff.GetComponent<ParticleSystem>().main;
        smokeColored.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Brick Missing Sprite");
        }
    }

    

    // Update is called once per frame
    void Update ()
    {
		
	}

    // TODO REMOVE THIS METHOD ONCE WE ACTUALLY WIN
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
