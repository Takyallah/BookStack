using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{

    private float min_x = -300f, max_x = 300f;

    private bool canMove;
    private float move_Speed = 300f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        if(Random.Range(0,2) > 0)
        {
            move_Speed *= -1f;
        }

        GameplayController.instance.currentBook = this;

    }

    // Update is called once per frame
    void Update()
    {
        MoveBook();
    }

    void MoveBook()
    {

        if(canMove)
        {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;

            if (temp.x < min_x)
            {
                move_Speed *= -1f;
            }
            else if (temp.x > max_x)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBook()
    {
        canMove = false;

        myBody.gravityScale = Random.Range(400,500);
    }

    public void Landed()
    {
        if (gameOver) return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBook();
        GameplayController.instance.MoveCamera();
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target) {

        if (ignoreCollision) return;

        if(target.gameObject.tag == "Platform" || target.gameObject.tag == "Book")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger) return;

        if(target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 1f);
        }

    }

}
