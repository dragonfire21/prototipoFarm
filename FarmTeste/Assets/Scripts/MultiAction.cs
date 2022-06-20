using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAction : MonoBehaviour
{
    [Header("Atributos")]
    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    [SerializeField] private bool runlist = true;

    [Header("GameObjects")]
    [SerializeField] private GameObject action1;
    [SerializeField] private GameObject action2;
    [SerializeField] private GameObject action3;   
    [SerializeField] private GameObject action4;

    [Header("Scrip")]
    [SerializeField]private Player player;

    [Header("Lista")]
    [SerializeField] List<Transform> position = new List<Transform> ();
    // Start is called before the first frame update
    void Start()
    {
        action1 = GameObject.Find("Action1");
        action2 = GameObject.Find("Action2");
        action3 = GameObject.Find("Action3");
        action4 = GameObject.Find("Action4");
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Action();
    }

    void Action()
    {
        RaycastHit2D hit;
        if (isRight)
        {
            position.Clear();
            action1.SetActive(true);
            action2.SetActive(false);
            action3.SetActive(false);
            action4.SetActive(false);
            FindObjectOfType<Invetory>().side = 1;
            hit = Physics2D.Raycast(action1.transform.position, Vector2.right, 0.1f);
            if (hit.collider != null)
            {
               
                position.Add(hit.collider.transform);
                StartCoroutine("RunList");
            }

        }
        else if (isLeft)
        {
            position.Clear();
            action1.SetActive(false);
            action2.SetActive(true);
            action3.SetActive(false);
            action4.SetActive(false);
            FindObjectOfType<Invetory>().side = 2;
            hit = Physics2D.Raycast(action2.transform.position, Vector2.left, 0.1f);
            if (hit.collider != null)
            {
                
                position.Add(hit.collider.transform);
                StartCoroutine("RunList");
            }
        }
        else if (isUp)
        {
            position.Clear();
            action1.SetActive(false);
            action2.SetActive(false);
            action3.SetActive(true);
            action4.SetActive(false);
            FindObjectOfType<Invetory>().side = 3;
            hit = Physics2D.Raycast(action3.transform.position, Vector2.up, 0.1f);
            if (hit.collider != null)
            {
                position.Add(hit.collider.transform);
                StartCoroutine("RunList");
            }
            
        }
        else if (isDown)
        {
            position.Clear();
            action1.SetActive(false);
            action2.SetActive(false);
            action3.SetActive(false);
            action4.SetActive(true);
            FindObjectOfType<Invetory>().side = 4;
            hit = Physics2D.Raycast(action4.transform.position, Vector2.down, 0.1f);
            if (hit.collider != null)
            {
                position.Add(hit.collider.transform);
                StartCoroutine("RunList");
            }
            
        }
        
    }

    IEnumerator RunList()
    {
        if (runlist)
        {
            runlist = false;
            foreach (Transform t in position)
            {
                if (t.transform.GetComponent<Wheat>())
                {

                    if (t.transform.GetComponent<Wheat>().sap)
                    {
                        player.ptl = true;
                    }

                    player.heCan = true;
                }
                else
                {
                    player.heCan = false;
                }

                if (t.transform.GetComponent<WateringTool>())
                {
                    Invetory.FindObjectOfType<Invetory>().wateringTool = true;
                }

                if (t.GetComponent<HoeTool>())
                {
                    Invetory.FindObjectOfType<Invetory>().hoeTool = true;
                }

                if (t.GetComponent<AxeTool>())
                {
                    Invetory.FindObjectOfType<Invetory>().axeTool = true;
                }

                if (t.GetComponent<WheatSeed>())
                {
                    Invetory.FindObjectOfType<Invetory>().seedWheat = true;
                }

                if (t.GetComponent<TreeDropWood>())
                {
                    if (action1.activeInHierarchy)
                    {
                        TreeDropWood.FindObjectOfType<TreeDropWood>().playerLeft = true;
                        
                    }

                    if (action2.activeInHierarchy)
                    {
                        TreeDropWood.FindObjectOfType<TreeDropWood>().playerRight = true;
                    }
                    player.cutting = true;
                }

                if (t.GetComponent<Dirt>())
                {
                    FindObjectOfType<Player>().toPlant = true;
                }

            }
            yield return new WaitForSeconds(0.25f);
            runlist = true;
            Invetory.FindObjectOfType<Invetory>().seedWheat = false;
            Invetory.FindObjectOfType<Invetory>().wateringTool = false;
            Invetory.FindObjectOfType<Invetory>().hoeTool = false;
            Invetory.FindObjectOfType<Invetory>().axeTool = false;
            TreeDropWood.FindObjectOfType<TreeDropWood>().playerLeft = false;
            player.heCan = false;
            player.toPlant = false;
            player.ptl = false;
            player.cutting = false;
        }

        
    }

}
