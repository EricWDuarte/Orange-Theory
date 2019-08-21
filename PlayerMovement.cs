using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera cam;
    Rigidbody2D rb;

    public float speed = 20f;
    Vector2 targetPos;

    float rotation = -191f;


    void Start () {
        Cursor.visible = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    //void Update () {
    //       float h = Input.GetAxis("Horizontal");
    //       float v = Input.GetAxis("Vertical");

    //       Vector2 move = new Vector2(h, v);
    //       move *= speed * Time.deltaTime;
    //       transform.position += new Vector3(move.x, move.y, 0);


    //       if (transform.position.x > 24f)
    //       {
    //           transform.Translate(-48f, 0, 0);
    //       } else if (transform.position.x < -24f)
    //       {
    //           transform.Translate(48f, 0, 0);
    //       }

    //       cam.transform.position = new Vector3(0, cam.transform.position.y, -10f);

    //   }

    private void Update()
    {
        float rot = rotation + Mathf.Atan2(-Input.mousePosition.x + Screen.width/2f, -Input.mousePosition.y + Screen.height/2f) * Mathf.Rad2Deg;
        float h = Mathf.Lerp(-24f, 24f, Mathf.Repeat(rot, 360f) / 360f);

        float v = Input.mouseScrollDelta.y * 30f;

        targetPos = new Vector2(h, transform.position.y + v);

        rb.MovePosition(new Vector2(Mathf.MoveTowardsAngle(transform.position.x * 360f / 48f, targetPos.x * 360f / 48f, speed * Time.deltaTime * 360f / 48f) * 48f/360f,
                                    Mathf.MoveTowards(transform.position.y, targetPos.y, speed * 1.2f * Time.deltaTime)));

        //rb.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPos, speed * Time.deltaTime));

        if (transform.position.x > 24.5f)
        {
            transform.Translate(-48f, 0, 0);
        }
        else if (transform.position.x < -24.5f)
        {
            transform.Translate(48f, 0, 0);
        }

        cam.transform.position = new Vector3(0, cam.transform.position.y, -10f);
        rotation += ConeRotation.rot * Time.deltaTime;

    }
}
