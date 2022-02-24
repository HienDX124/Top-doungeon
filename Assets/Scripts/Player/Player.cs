using UnityEngine;
using UnityEngine.UI;

public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] private float speed;
    [SerializeField] private float maxVelocity;

    [SerializeField] private float attackCooldown = 0.5f;

    [HideInInspector] public int direction = 0;
    [HideInInspector] public const int LEFT_DIR = 0;
    [HideInInspector] public const int RIGHT_DIR = 1;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D myBody;
    [HideInInspector] private Animator weaponAnimator;

    protected override void Awake()
    {

        base.Awake();

        animator = transform.Find("Body").GetComponent<Animator>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    public void Move()
    {
        Vector3 temp = transform.localScale;
        animator.SetBool("move", true);
        if (Input.GetKey(KeyCode.D))
        {
            direction = RIGHT_DIR;
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            temp.x = Mathf.Abs(temp.x);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            direction = LEFT_DIR;
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            temp.x = Mathf.Abs(temp.x) * -1f;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }

        else
        {
            animator.SetBool("move", false);
        }

        transform.localScale = temp;
    }

    private void Attack()
    {
        attackCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && attackCooldown < 0)
        {
            weaponAnimator.Play("hit");
            attackCooldown = 0.5f;
        }
    }
}