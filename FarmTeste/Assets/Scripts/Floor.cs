using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField] private GameObject roof;
    // Start is called before the first frame update
    void Start()
    {
        roof = GameObject.Find("Roof");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roof.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roof.SetActive(true);
        }
    }
}
