using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Transform movePoint;
    public float moveSpeed = 1f;
    //public float collisionOffset = 0.05f;

    public ContactFilter2D movimentFilter;
    Vector2 movimentInput;
    public float movimentOutput;
    Rigidbody2D rb;
    public Animator animator;
    public LayerMask whatStopsMovement;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private int count;

    public int healthPoints;
    public int maxHealthPoints;
    public int points;

    public float PosX;
    public float PosY;

    public GameObject gameOverScreen;

    public GameObject loseSound;
    public GameObject gainSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        PosX = transform.position.x - movePoint.position.x;
        PosY = transform.position.y - movePoint.position.y;

        animator.SetFloat("PosX", PosX);
        animator.SetFloat("PosY", PosY);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) != 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.02f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }



            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.02f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                }

            }

        }
    }
    public void OnMove(InputValue movimentValue)
    {
            movimentInput = movimentValue.Get<Vector2>();

    }

    public void TakeDamage(int amount)
    {
        healthPoints -= amount;
        loseSound.GetComponent<AudioSource>().Play();
            if (healthPoints <= 0)
            {
                Debug.Log("GAME OVER");
                gameOverScreen.SetActive(true);
            }
    }

    public void EarnPoint(int amount)
    {
        points += amount;
        gainSound.GetComponent<AudioSource>().Play();
    }

    

}