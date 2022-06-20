using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDropWood : MonoBehaviour
{
    [Header("Atributos")]
    public bool playerLeft;
    public bool playerRight;
    [SerializeField] private int damage;

    [Header("Componentes")]
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D box;

    [Header("Outros")]
    [SerializeField] private Transform isLeft;
    [SerializeField] private Transform isRight;
    [SerializeField] private Transform trunk;
    [SerializeField] private GameObject trunkPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        isLeft = GameObject.Find("Fall Left").transform;
        isRight = GameObject.Find("Fall Right").transform;
        trunk = GameObject.Find("trunk").transform;
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    public void TearDown(int value)
    {
        damage += value;
        if (playerLeft && damage == 4)
        {
            anim.SetBool("cutti", true);
            Instantiate(trunkPrefab, trunk.position, transform.rotation);
            transform.position = isRight.position;
            transform.eulerAngles = new Vector2(0f, 180f);
            box.offset = new Vector2(0.005605459f, 0.03363347f);
            box.size = new Vector2(1.594721f, 0.5556736f);

        }

        else if (playerRight && damage == 4)
        {
            anim.SetBool("cutti", true);
            Instantiate(trunkPrefab, trunk.position, transform.rotation);
            transform.position = isLeft.position;
            transform.eulerAngles = Vector2.zero;
            box.offset = new Vector2(0.005605459f, 0.03363347f);
            box.size = new Vector2(1.594721f, 0.5556736f);

        }
    }


}
