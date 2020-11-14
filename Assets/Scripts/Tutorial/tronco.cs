using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    private SpriteRenderer troncoSprite;
    private BoxCollider2D playerCollider;
    private string TAG_PRINCIPE = "plyer_pricipe";


    // Start is called before the first frame update
    void Start()
    {
        troncoSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        troncoSprite.color = new Color(1f, 1f, 1f, .255f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
      troncoSprite.color = new Color(1f, 1f, 1f, .1f);
      Debug.Log("GameObject1 collided with " + col.name);
    }
}

 