using UnityEngine;

public class cratebase : MonoBehaviour
{
    public int crateindex;
    //[SerializeField] holecontroller checkindex;

    private string holeName;
    [SerializeField] int checkindex;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        crateindex = GameObject.Find("Crates").GetComponent<Crates>().crateType;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.tag == "Player" )
        {


            Vector2 direction = col.GetContact(0).normal;
            if (direction.x == 1)
            {
                transform.position += new Vector3(1f, 0f);

            }
            else if (direction.x == -1)
            {
                transform.position += new Vector3(-1f, 0f);

            }
            else if (direction.y > 0)
            {
                transform.position += new Vector3(0f, 1f);
            }
            else if (direction.y < 0)
            {
                transform.position += new Vector3(0f, -1f);

            }

        }

        if ( col.gameObject.tag == "Crate")
        {
            Vector2 direction = col.GetContact(0).normal;
            if (direction.x == 1)
            {
                transform.position += new Vector3(1f, 0f);

            }
            else if (direction.x == -1)
            {
                transform.position += new Vector3(-1f, 0f);

            }
            else if (direction.y == 1)
            {
                transform.position += new Vector3(0f, 1f);
            }
            else if (direction.y == -1)
            {
                transform.position += new Vector3(0f, -1f);

            }
        }
        if (col.gameObject.tag == "Hole")
        {
            checkindex = col.gameObject.GetComponent<holecontroller>().checkindex;
            if (checkindex == crateindex)
            {
                Debug.Log("U DID IT");
                player.EarnPoint(crateindex + 1);
                Object.Destroy(this.gameObject);
            }

            else
            {
                Debug.Log("WRONG HOLE");
                player.TakeDamage(1);
                Object.Destroy(this.gameObject);
            }
        }

    }


}