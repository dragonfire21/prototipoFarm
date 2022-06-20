using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invetory : MonoBehaviour
{
    [Header("Atributos publicos")]
    public int side;
    public bool wateringTool;
    public bool hoeTool;
    public bool axeTool;
    public bool seedWheat;

    [Header("Atributos privados")]
    [SerializeField] private bool nextImage;
    [SerializeField] private bool takeWatering;
    [SerializeField] private bool takeHoe;
    [SerializeField] private bool takeAxe;
    [SerializeField] private bool takeSeedW;

    [Header("Arrays")]
    [SerializeField] private bool[] pressed = new bool[10];
    [SerializeField] private Sprite[] icon;
    [SerializeField] private Image[] slotIcon;
    [SerializeField] private GameObject[] tools = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        icon = new Sprite[8];
        
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    void Action()
    {
        AllocatingIcon();
        DropItem();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (wateringTool)
            {
                icon[0] = WateringTool.FindObjectOfType<WateringTool>().WateringSprite();
                tools[0] = Resources.Load<GameObject>("Prefabs/Watering Tool");
                WateringTool.FindObjectOfType<WateringTool>().Delete();
                takeWatering = true;
                nextImage = true;

            }

            if (hoeTool)
            {
                icon[1] = HoeTool.FindObjectOfType<HoeTool>().HoeSprite();
                tools[1] = Resources.Load<GameObject>("Prefabs/Hoe Tool");
                HoeTool.FindObjectOfType<HoeTool>().Delete();
                takeHoe = true;
                nextImage = true;

            }

            if (axeTool)
            {
                icon[2] = AxeTool.FindObjectOfType<AxeTool>().AxeSprite();
                tools[2] = Resources.Load<GameObject>("Prefabs/Axe Tool");
                AxeTool.FindObjectOfType<AxeTool>().Delete();
                takeAxe = true;
                nextImage = true;
            }

            if (seedWheat)
            {
                icon[3] = FindObjectOfType<WheatSeed>().SeedWhetSprite();
                tools[3] = Resources.Load<GameObject>("Prefabs/WheatSeed");
                FindObjectOfType<WheatSeed>().Delete();
                takeSeedW = true;
                nextImage = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (slotIcon[0].sprite == null)
            {
                Player.FindObjectOfType<Player>().watering = false;
                Player.FindObjectOfType<Player>().hoe = false;
                Player.FindObjectOfType<Player>().axe = false;
                pressed[0] = false;
                pressed[1] = false;
                pressed[2] = false;
            }
            else if (slotIcon[0].sprite == icon[0])
            {
                Player.FindObjectOfType<Player>().watering = true;
                Player.FindObjectOfType<Player>().hoe = false;
                Player.FindObjectOfType<Player>().axe = false;
                FindObjectOfType<Player>().wheatSeed = false;
                FindObjectOfType<Dirt>().takeSeed = false;
                pressed[0] = true;
                pressed[1] = false;
                pressed[2] = false;
            }

            else if (slotIcon[0].sprite == icon[1])
            {
                Player.FindObjectOfType<Player>().watering = false;
                Player.FindObjectOfType<Player>().hoe = true;
                Player.FindObjectOfType<Player>().axe = false;
                FindObjectOfType<Player>().wheatSeed = false;
                FindObjectOfType<Dirt>().takeSeed = false;
                pressed[0] = true;
                pressed[1] = false;
                pressed[2] = false;
            }

            else if (slotIcon[0].sprite == icon[2])
            {
                Player.FindObjectOfType<Player>().watering = false;
                Player.FindObjectOfType<Player>().hoe = false;
                Player.FindObjectOfType<Player>().axe = true;
                FindObjectOfType<Player>().wheatSeed = false;
                FindObjectOfType<Dirt>().takeSeed = false;
                pressed[0] = true;
                pressed[1] = false;
                pressed[2] = false;
            }

            else if (slotIcon[0].sprite == icon[3])
            {
                Player.FindObjectOfType<Player>().watering = false;
                Player.FindObjectOfType<Player>().hoe = false;
                Player.FindObjectOfType<Player>().axe = false;
                FindObjectOfType<Player>().wheatSeed = true;
                FindObjectOfType<Dirt>().takeSeed = true;
                pressed[0] = true;
                pressed[1] = false;
                pressed[2] = false;
            }
        }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (slotIcon[1].sprite == null)
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = false;
                }
                else if (slotIcon[1].sprite == icon[0])
                {
                    Player.FindObjectOfType<Player>().watering = true;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = true;
                    pressed[2] = false;
                }
                else if (slotIcon[1].sprite == icon[1])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = true;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = true;
                    pressed[2] = false;
                }
                else if (slotIcon[1].sprite == icon[2])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = true;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = true;
                    pressed[2] = false;
                }
                else if (slotIcon[1].sprite == icon[3])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = true;
                    FindObjectOfType<Dirt>().takeSeed = true;
                    pressed[0] = false;
                    pressed[1] = true;
                    pressed[2] = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (slotIcon[2].sprite == null)
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = false;
                }
                else if (slotIcon[2].sprite == icon[0])
                {
                    Player.FindObjectOfType<Player>().watering = true;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = true;
                }
                else if (slotIcon[2].sprite == icon[1])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = true;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = true;
                }
                else if (slotIcon[2].sprite == icon[2])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = true;
                    FindObjectOfType<Player>().wheatSeed = false;
                    FindObjectOfType<Dirt>().takeSeed = false;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = true;
                }
                else if (slotIcon[2].sprite == icon[3])
                {
                    Player.FindObjectOfType<Player>().watering = false;
                    Player.FindObjectOfType<Player>().hoe = false;
                    Player.FindObjectOfType<Player>().axe = false;
                    FindObjectOfType<Player>().wheatSeed = true;
                    FindObjectOfType<Dirt>().takeSeed = true;
                    pressed[0] = false;
                    pressed[1] = false;
                    pressed[2] = true;
                }
            }
        }

        void DropItem()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (pressed[0])
                {
                    if (slotIcon[0].sprite == icon[0])
                    {
                        pressed[0] = false;
                        GameObject WateringT = Instantiate(tools[0], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WateringT.GetComponent<WateringTool>().drop = true;
                        FindObjectOfType<WateringTool>().GetSide(side);
                        FindObjectOfType<Player>().watering = false;
                        FindObjectOfType<Player>().hoe = false;
                        FindObjectOfType<Player>().axe = false;
                        tools[0] = null;
                        slotIcon[0].sprite = null;
                        slotIcon[0].enabled = false;
                        icon[0] = null;
                    }

                    else if (slotIcon[0].sprite == icon[1])
                    {
                        pressed[0] = false;
                        GameObject HoeT = Instantiate(tools[1], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        HoeT.GetComponent<HoeTool>().drop = true;
                        HoeT.GetComponent<HoeTool>().GetSide(side);
                        FindObjectOfType<Player>().watering = false;
                        FindObjectOfType<Player>().hoe = false;
                        FindObjectOfType<Player>().axe = false;
                        tools[1] = null;
                        slotIcon[0].sprite = null;
                        slotIcon[0].enabled = false;
                        icon[1] = null;
                    }
                    else if (slotIcon[0].sprite == icon[2])
                    {
                        pressed[0] = false;
                        GameObject AxeT = Instantiate(tools[2], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        AxeT.GetComponent<AxeTool>().drop = true;
                        AxeT.GetComponent<AxeTool>().GetSide(side);
                        FindObjectOfType<Player>().watering = false;
                        FindObjectOfType<Player>().hoe = false;
                        FindObjectOfType<Player>().axe = false;
                        tools[2] = null;
                        slotIcon[0].sprite = null;
                        slotIcon[0].enabled = false;
                        icon[2] = null;
                    }

                    else if (slotIcon[0].sprite == icon[3])
                    {
                        pressed[0] = false;
                        GameObject WheatSeedT = Instantiate(tools[3], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WheatSeedT.GetComponent<WheatSeed>().drop = true;
                        WheatSeedT.GetComponent<WheatSeed>().GetSide(side);
                        FindObjectOfType<Dirt>().takeSeed = false;
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[3] = null;
                        slotIcon[0].sprite = null;
                        slotIcon[0].enabled = false;
                        icon[3] = null;
                    }
                }

                if (pressed[1])
                {
                    if (slotIcon[1].sprite == icon[0])
                    {
                        pressed[1] = false;
                        GameObject WateringT = Instantiate(tools[0], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WateringT.GetComponent<WateringTool>().drop = true;
                        FindObjectOfType<WateringTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;                        
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[0] = null;
                        slotIcon[1].sprite = null;
                        slotIcon[1].enabled = false;
                        icon[0] = null;
                    }

                    else if (slotIcon[1].sprite == icon[1])
                    {
                        pressed[1] = false;
                        GameObject HoeT = Instantiate(tools[1], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        HoeT.GetComponent<HoeTool>().drop = true;
                        HoeT.GetComponent<HoeTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[1] = null;
                        slotIcon[1].sprite = null;
                        slotIcon[1].enabled = false;
                        icon[1] = null;
                    }
                    else if (slotIcon[1].sprite == icon[2])
                    {
                        pressed[1] = false;
                        GameObject AxeT = Instantiate(tools[2], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        AxeT.GetComponent<AxeTool>().drop = true;
                        AxeT.GetComponent<AxeTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[2] = null;
                        slotIcon[1].sprite = null;
                        slotIcon[1].enabled = false;
                        icon[2] = null;
                    }

                    else if (slotIcon[1].sprite == icon[3])
                    {
                        pressed[1] = false;
                        GameObject WheatSeedT = Instantiate(tools[3], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WheatSeedT.GetComponent<WheatSeed>().drop = true;
                        WheatSeedT.GetComponent<WheatSeed>().GetSide(side);
                        FindObjectOfType<Dirt>().takeSeed = false;
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[3] = null;
                        slotIcon[1].sprite = null;
                        slotIcon[1].enabled = false;
                        icon[3] = null;
                    }
                }

                if (pressed[2])
                {
                    if (slotIcon[2].sprite == icon[0])
                    {
                        pressed[2] = false;
                        GameObject WateringT = Instantiate(tools[0], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WateringT.GetComponent<WateringTool>().drop = true;
                        FindObjectOfType<WateringTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;                        
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[0] = null;
                        slotIcon[2].sprite = null;
                        slotIcon[2].enabled = false;
                        icon[0] = null;
                    }

                    else if (slotIcon[2].sprite == icon[1])
                    {
                        pressed[2] = false;
                        GameObject HoeT = Instantiate(tools[1], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        HoeT.GetComponent<HoeTool>().drop = true;
                        HoeT.GetComponent<HoeTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[1] = null;
                        slotIcon[2].sprite = null;
                        slotIcon[2].enabled = false;
                        icon[1] = null;
                    }
                    else if (slotIcon[2].sprite == icon[2])
                    {
                        pressed[2] = false;
                        GameObject AxeT = Instantiate(tools[2], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        AxeT.GetComponent<AxeTool>().drop = true;
                        AxeT.GetComponent<AxeTool>().GetSide(side);
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[2] = null;
                        slotIcon[2].sprite = null;
                        slotIcon[2].enabled = false;
                        icon[2] = null;
                    }

                    else if (slotIcon[2].sprite == icon[3])
                    {
                        pressed[2] = false;
                        GameObject WheatSeedT = Instantiate(tools[3], FindObjectOfType<Player>().transform.position, FindObjectOfType<Player>().transform.rotation);
                        WheatSeedT.GetComponent<WheatSeed>().drop = true;
                        WheatSeedT.GetComponent<WheatSeed>().GetSide(side);
                        FindObjectOfType<Dirt>().takeSeed = false;
                        Player.FindObjectOfType<Player>().watering = false;
                        Player.FindObjectOfType<Player>().hoe = false;
                        Player.FindObjectOfType<Player>().axe = false;
                        tools[3] = null;
                        slotIcon[2].sprite = null;
                        slotIcon[2].enabled = false;
                        icon[3] = null;
                    }
                }


            }
        }


        void AllocatingIcon()
        {
            if (slotIcon[0].sprite == null && nextImage)
            {
                if (takeWatering)
                {
                    slotIcon[0].sprite = icon[0];
                    slotIcon[0].enabled = true;
                    nextImage = false;
                    takeWatering = false;
                }

                else if (takeHoe)
                {
                    slotIcon[0].sprite = icon[1];
                    slotIcon[0].enabled = true;
                    nextImage = false;
                    takeHoe = false;
                }

                else if (takeAxe)
                {
                    slotIcon[0].sprite = icon[2];
                    slotIcon[0].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }

                else if (takeSeedW)
                {
                    slotIcon[0].sprite = icon[3];
                    slotIcon[0].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }
            }

            else if (slotIcon[1].sprite == null && nextImage)
            {
                if (takeWatering)
                {
                    slotIcon[1].sprite = icon[0];
                    slotIcon[1].enabled = true;
                    nextImage = false;
                    takeWatering = false;
                }

                else if (takeHoe)
                {
                    slotIcon[1].sprite = icon[1];
                    slotIcon[1].enabled = true;
                    nextImage = false;
                    takeHoe = false;
                }

                else if (takeAxe)
                {
                    slotIcon[1].sprite = icon[2];
                    slotIcon[1].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }

                else if (takeSeedW)
                {
                    slotIcon[1].sprite = icon[3];
                    slotIcon[1].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }
            }

            else if (slotIcon[2].sprite == null && nextImage)
            {
                if (takeWatering)
                {
                    slotIcon[2].sprite = icon[0];
                    slotIcon[2].enabled = true;
                    nextImage = false;
                    takeWatering = false;
                }

                else if (takeHoe)
                {
                    slotIcon[2].sprite = icon[1];
                    slotIcon[2].enabled = true;
                    nextImage = false;
                    takeHoe = false;
                }

                else if (takeAxe)
                {
                    slotIcon[2].sprite = icon[2];
                    slotIcon[2].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }

                else if (takeSeedW)
                {
                    slotIcon[2].sprite = icon[3];
                    slotIcon[2].enabled = true;
                    nextImage = false;
                    takeAxe = false;
                }
            }
       }
}
