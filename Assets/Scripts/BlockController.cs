using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public int lives;
    public Sprite[] sprites = new Sprite[0];

    private SpriteRenderer blockSpriteRenderer;

    public void Start()
    {
        blockSpriteRenderer = this.GetComponent<SpriteRenderer>();
        blockSpriteRenderer.sprite = sprites[lives - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Break();
        }
    }

    private void Break()
    {
        lives--;
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            blockSpriteRenderer.sprite = sprites[lives - 1];
        }
    }
}
