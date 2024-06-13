using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playmovement : MonoBehaviour
{

    //A modifier which changes the speed of the player in the movement code
    [Header("Movement Variables")]
    public float movespeed;

    //The height modifier for the player's jump
    public float jumpheight;

    //The Rigidbody of the player character
    public Rigidbody Myrigidbody;



    //This layermask will be used to register if the player is on the ground
    [SerializeField] private LayerMask ground;
    //The distance of the raycast used to check if the player is on the ground.
    [SerializeField] private float raycastdistance;

    //If the player is on the ground this bool will be set to true, which will allow the player to jump
    [SerializeField] private bool groundbool;

    public Vector3 moveValuesKeys;
    public Vector3 moveValuesUI;


    //Contains the gameobject which collides at the bottom of the object
    [SerializeField] private Collision Collide;

    //The bool thats called when the player jumps
    public bool jump;

    //The players Transform
    public Transform MyTransform;

    //A float which will store the Vector3.Dot data for the jump
    public float Jumpdirection;

    //A bool called when the player has jumped, to then call on the float
    public bool jumped;

    //The animator for the characters legs
    public Animator Legs;

    //The animator for the character's eyes
    public Animator Eyes;

    //Called when I want to pause player input controls
    public bool StopMovement = false;

    //Used to stop the player from jumping
    public bool StopJump = false;
    public bool SlowJump = false;

    public PlayerInput Playerinput;

    [SerializeField] Animator SlowAnim;



    // Start is called before the first frame update
    void Start()
    {
        Myrigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();

        Playerinput = GetComponent<PlayerInput>();


        StartCoroutine(BlinkRandom());


    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //Adds gravity to the object

            Myrigidbody.AddForce(Physics.gravity * Myrigidbody.mass, ForceMode.Acceleration);

        //Calls the movement
        if(StopMovement == false)
        {
            move();
        }

        if(jump == true)
        {
            Myrigidbody.AddForce(Vector3.up * jumpheight, ForceMode.Acceleration);
            jump = false;
            Legs.SetBool("Jumping", true);
            Legs.SetBool("Down_Jump", true);
            Eyes.SetBool("Jumping", true);
            Eyes.SetBool("Down_Jump", true);
            jumped = true;
        }

        if(jumped == true)
        {
            //Once the player has reached the peak of there jump they will spend a bit still in the air
            if (Jumpdirection < 0)
            {
                StartCoroutine(FloatJump());
            }
        }





    }
    void Update()
    {
        //The raycast used to check for the ground.
        RaycastHit Ghit;

        //The code which sets the groundbool if the player is on the ground.
        groundbool = Physics.Raycast(transform.position, Vector3.down, out Ghit, raycastdistance, ground);


        //This if statement checks whether the player is pressing the jump button and is on the ground, before allowing the player to jump
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Registers the change to the player's jump height
        Jumpdirection = Vector3.Dot(transform.up, Myrigidbody.velocity);

        if ((Myrigidbody.velocity.x != 0 || Myrigidbody.velocity.z != 0) && Myrigidbody.velocity.y == 0)
        {
            Legs.SetBool("Walking", true);
            SlowAnim.SetBool("Walking", true);
        }
        else
        {
            Legs.SetBool("Walking", false);
            SlowAnim.SetBool("Walking", false);
        }

        if(Eyes.GetBool("Down_Jump") == true && groundbool == true)
        {
            Eyes.SetBool("Down_Jump", false);
        }
        
        if(Legs.GetBool("Down_Jump") == true && groundbool == true)
        {
            Legs.SetBool("Down_Jump", false);
        }

        //Resets the Jumpdirection to 0 when the player is not jumping
        if(groundbool)
        {
            Jumpdirection = 0;
        }

        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator BlinkRandom()
    {
        Eyes.SetInteger("Blink", Random.Range(0, 26));
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(BlinkRandom());
    }

    IEnumerator FloatJump()
    {
        Myrigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        Legs.SetBool("Mid_Jump", true);
        Legs.SetBool("Jumping", false);
        jumped = false;
        yield return new WaitForSeconds(0.3f);
        Myrigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        Legs.SetBool("Mid_Jump", false);
        Eyes.SetBool("Jumping", false);
    }

    public void Jump()
    {
        if(groundbool)
        {
            if (StopJump == false && SlowJump == false)
            {
                jump = true;
            }
        }
    }

    private void move()
    {

        //This vector stores the movement information of the character, which then goes on to effect the characters rigidbody.
        moveValuesKeys = new Vector3();

        moveValuesKeys.z = movespeed * Input.GetAxis("Vertical") * Time.deltaTime;
        moveValuesKeys.x = movespeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        moveValuesKeys.y = Myrigidbody.velocity.y;

        Vector2 UIInput = Playerinput.actions["Move"].ReadValue<Vector2>();
        Vector3 Move = new Vector3(UIInput.x, 0, UIInput.y);
        moveValuesUI.x = movespeed * Move.x * Time.deltaTime;
        moveValuesUI.z = movespeed * Move.z * Time.deltaTime;
        moveValuesUI.y = Myrigidbody.velocity.y;

        if(moveValuesKeys.x != 0f || moveValuesKeys.z != 0f)
        {
            Myrigidbody.velocity = moveValuesKeys;
        }

        if(moveValuesUI.x != 0f || moveValuesUI.z != 0f)
        {
            Myrigidbody.velocity = moveValuesUI;
        }
    }


}
