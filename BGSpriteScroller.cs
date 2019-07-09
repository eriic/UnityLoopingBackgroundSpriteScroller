using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BGSpriteScroller : MonoBehaviour

{
    public float speed = 1.0f;
    public bool moveRight = false;  // scroll to left by default.
    private GameObject dupeSprite;

    private float spriteWidth;
    private float initPos;

    private void Awake()
    {
        initPos = transform.position.x;
        spriteWidth = this.GetComponent<SpriteRenderer>().bounds.size.x;

        // create duplicate sprite to right for seamless looping.
        dupeSprite = new GameObject("childBG");
        dupeSprite.AddComponent<SpriteRenderer>();

        // copy sprite renderer values from parent to duplicate.  add more if necessary.
        dupeSprite.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        dupeSprite.GetComponent<SpriteRenderer>().material = this.GetComponent<SpriteRenderer>().material;
        dupeSprite.GetComponent<SpriteRenderer>().sortingLayerName = this.GetComponent<SpriteRenderer>().sortingLayerName;
        dupeSprite.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder;

        // set position of duplicate to right (or left if moveRight flag is true).
        dupeSprite.transform.SetParent(this.transform);
        dupeSprite.transform.localPosition = new Vector3(moveRight ? -spriteWidth : spriteWidth, 0, 0);

    }

    private void Update()
    {
        if (moveRight)
        {
            float currentPos = transform.position.x;
            if (currentPos - initPos > spriteWidth)
            {
                // if distance traversed is greater than width of this sprite,
                // then reposition to original position.
                transform.position = new Vector3(initPos + speed, transform.position.y, transform.position.z);
            }
            else
                transform.position = new Vector3(currentPos + speed, transform.position.y, transform.position.z);
        }
        else
        {
            float currentPos = transform.position.x;
            if (initPos - currentPos > spriteWidth)
            {
                transform.position = new Vector3(initPos - speed, transform.position.y, transform.position.z);
            }
            else
                transform.position = new Vector3(currentPos - speed, transform.position.y, transform.position.z);
        }
    }
}