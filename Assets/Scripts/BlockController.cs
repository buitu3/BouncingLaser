using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public int lives;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {            
            lives--;
            if (lives == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
