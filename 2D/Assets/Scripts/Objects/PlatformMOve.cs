using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMOve : MonoBehaviour
{
    //public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float waitTime;
    public float starWaitTime = 2;
    private int i = 0;
    //private Vector2 actualPos;
    public Transform[] moveSpot;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = starWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(CheckEnemyMoving());
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpot[i] != moveSpot[moveSpot.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = starWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }

    //IEnumerator CheckEnemyMoving()
    //{
    //    actualPos = transform.position;
    //    yield return new WaitForSeconds(0.5f);
    //    if (transform.position.x > actualPos.x)
    //    {
    //        spriteRenderer.flipX = true;
    //        animator.SetBool("Idle", false);
    //    }
    //    else if (transform.position.x < actualPos.x)
    //    {
    //        spriteRenderer.flipX = false;
    //        animator.SetBool("Idle", false);
    //    }
    //    else if (transform.position.x == actualPos.x)
    //    {
    //        animator.SetBool("Idle", true);

    //    }
    //}
}
