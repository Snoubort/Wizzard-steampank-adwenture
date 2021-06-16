using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    public float speed = 60.0f;
    public GameObject handOriginal;
    public GameObject Player;
    private Rigidbody2D rigidBody2D;
    private GameObject hand;


    private float PlayerX;

    private bool handOut = false;
    private bool handBack = false;
    private bool PlayerGrab = false;

    // Update is called once per frame
    void Update()
    {
        if (handOut)
        {
            rigidBody2D.MovePosition(rigidBody2D.position + Vector2.left * speed * Time.deltaTime);
            if (hand.transform.position.x < PlayerX)
            {
                handBack = true;
                handOut = false;
            }
            if (hand.transform.position.x >= handOriginal.transform.position.x)
            {
                handBack = false;
                Destroy(hand);
            }

        }

        if (handBack)
            rigidBody2D.MovePosition(rigidBody2D.position + Vector2.right * speed * Time.deltaTime);

        if (PlayerGrab)
        {
            Player.GetComponent<Rigidbody2D>().MovePosition(Player.GetComponent<Rigidbody2D>().position + Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerGrab = true;
        }
    }

    public void HandDrop()
    {
        hand = Instantiate(handOriginal);
        rigidBody2D = hand.GetComponent<Rigidbody2D>();
        hand.transform.position = new Vector3(hand.transform.position.x, -3f, hand.transform.position.z);
        PlayerX = Player.transform.position.x;
        handOut = true;
    }
}
