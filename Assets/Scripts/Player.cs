using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 8;
    public float maxVelocity = 4;

    [HideInInspector] public int direction = 0;
    [HideInInspector] public const int LEFT_DIR = 0;
    [HideInInspector] public const int RIGHT_DIR = 1;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D myBody;

    protected virtual void Awake()
    {
        animator = transform.Find("Body").GetComponent<Animator>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {

        Vector3 temp = transform.localScale;


        if (Input.GetKey(KeyCode.D))
        {
            direction = RIGHT_DIR;
            animator.SetBool("move", true);
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            temp.x = Mathf.Abs(temp.x);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            direction = LEFT_DIR;
            animator.SetBool("move", true);
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            temp.x = Mathf.Abs(temp.x) * -1f;
        }
        else
        {
            animator.SetBool("move", false);
        }

        transform.localScale = temp;

    }
}