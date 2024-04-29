using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holecontroller : MonoBehaviour
{
    public int checkindex;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("YEAHHHH ");
            player.TakeDamage(5);
        }
    }

}
