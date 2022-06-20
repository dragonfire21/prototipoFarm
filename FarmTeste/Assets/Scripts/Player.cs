using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField]private float speed;
    public bool heCan;
    public bool ptl;
    public bool cutting;
    public bool watering;
    public bool axe;
    public bool hoe;
    public bool wheatSeed;
    public bool toPlant;
    [Header("Scripts")]
    [SerializeField]private MultiAction action;

    [Header("Componentes")]
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        action = GetComponentInChildren<MultiAction>();
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX == 0 && moveY == 0)
        {
            rig.velocity = Vector2.zero;
            switch (anim.GetInteger("transition"))
            {
                case 0:
                    anim.SetBool("walkBack", false);
                    anim.SetBool("walkFront", false);
                    anim.SetBool("walkLeft", false);
                    anim.SetBool("walkRight", false);
                    break;

                case 1:
                    anim.SetBool("walkBack", false);
                    anim.SetBool("walkFront", false);
                    anim.SetBool("walkLeft", false);
                    anim.SetBool("walkRight", false);
                    break;

                case 2:
                    anim.SetBool("walkBack", false);
                    anim.SetBool("walkFront", false);
                    anim.SetBool("walkLeft", false);
                    anim.SetBool("walkRight", false);
                    break;

                case 3:
                    anim.SetBool("walkBack", false);
                    anim.SetBool("walkFront", false);
                    anim.SetBool("walkLeft", false);
                    anim.SetBool("walkRight", false);
                    break;
            }
        }

        if(moveX > 0)
        {
            anim.SetInteger("transition", 3);
            anim.SetBool("walkBack", false);
            anim.SetBool("walkFront", false);
            anim.SetBool("walkLeft", false);           
            anim.SetBool("walkRight", true);
            rig.velocity = new Vector2(moveX * speed, rig.velocity.y);
            action.isRight = true;
            action.isLeft = false;
            action.isUp = false;
            action.isDown = false;

        }

        if(moveX < 0)
        {
            anim.SetInteger("transition", 2);
            anim.SetBool("walkBack", false);
            anim.SetBool("walkFront", false);
            anim.SetBool("walkLeft", true);
            anim.SetBool("walkRight", false);
            rig.velocity = new Vector2(moveX * speed, rig.velocity.y);
            action.isRight = false;
            action.isLeft = true;
            action.isUp = false;
            action.isDown = false;
        }

        if(moveY > 0)
        {
            anim.SetInteger("transition", 1);
            anim.SetBool("walkBack", true);
            anim.SetBool("walkFront", false);
            anim.SetBool("walkLeft", false);
            anim.SetBool("walkRight", false);
            rig.velocity = new Vector2(rig.velocity.x, moveY * speed);
            action.isRight = false;
            action.isLeft = false;
            action.isUp = true;
            action.isDown = false;

        }

        if(moveY < 0)
        {
            anim.SetInteger("transition", 0);
            anim.SetBool("walkBack", false);
            anim.SetBool("walkFront", true);
            anim.SetBool("walkLeft", false);
            anim.SetBool("walkRight", false);
            rig.velocity = new Vector2(rig.velocity.x, moveY * speed);
            action.isRight = false;
            action.isLeft = false;
            action.isUp = false;
            action.isDown = true;
        }

    }

    void Action()
    {
 
        if (Input.GetMouseButtonDown(0))
        {
            if (watering)
            {
                StartCoroutine("AnimAction");
                if (heCan)
                {
                    Wheat.FindObjectOfType<Wheat>().Grow(1);
                }    
            }
            else if (hoe)
            {
                StartCoroutine("AnimAction");
                if (ptl)
                {
                    Wheat.FindObjectOfType<Wheat>().Delete();
                    ptl = false;
                }
            }

            else if (axe)
            {
                StartCoroutine("AnimAction");
                if (cutting)
                {
                    TreeDropWood.FindObjectOfType<TreeDropWood>().TearDown(1);
                }
            }

            else if (wheatSeed && toPlant)
            {
                
            }
        }
    }   


    IEnumerator AnimAction()
    {
        if (watering)
        {
            watering = false;
            switch (anim.GetInteger("transition"))
            {
                case 0:
                    anim.SetBool("wateringFront", true);
                    break;

                case 1:
                    anim.SetBool("wateringBack", true);
                    break;

                case 2:
                    anim.SetBool("wateringLeft", true);
                    break;

                case 3:
                    anim.SetBool("wateringRight", true);
                    break;
            }

            yield return new WaitForSeconds(0.35f);
            anim.SetBool("wateringFront", false);
            anim.SetBool("wateringBack", false);
            anim.SetBool("wateringLeft", false);
            anim.SetBool("wateringRight", false);
            watering = true;
        }

        if (axe)
        {
            axe = false;
            switch (anim.GetInteger("transition"))
            {
                case 0:
                    anim.SetBool("cuttingFront", true);
                    break;

                case 1:
                    anim.SetBool("cuttingBack", true);
                    break;

                case 2:
                    anim.SetBool("cuttingLeft", true);
                    break;

                case 3:
                    anim.SetBool("cuttingRight", true);
                    break;
            }
            yield return new WaitForSeconds(0.35f);
            anim.SetBool("cuttingFront", false);
            anim.SetBool("cuttingBack", false);
            anim.SetBool("cuttingLeft", false);
            anim.SetBool("cuttingRight", false);
            axe = true;
        }

        if (hoe)
        {
            hoe = false;
            switch (anim.GetInteger("transition"))
            {
                case 0:
                    anim.SetBool("hoeFront", true);
                    break;

                case 1:
                    anim.SetBool("hoeBack", true);
                    break;

                case 2:
                    anim.SetBool("hoeLeft", true);
                    break;

                case 3:
                    anim.SetBool("hoeRight", true);
                    break;
            }
            yield return new WaitForSeconds(0.35f);
            anim.SetBool("hoeFront", false);
            anim.SetBool("hoeBack", false);
            anim.SetBool("hoeLeft", false);
            anim.SetBool("hoeRight", false);
            hoe = true;
        }
    }
}
