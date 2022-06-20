using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private bool toGrow = true;
    [SerializeField] private bool canWater = true;
    [SerializeField] private int time;
    public bool sap;

    [Header("Componentes")]
    [SerializeField]private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Grow(int value)
    {
        if (canWater)
        {
            time += value;
        }

        if (toGrow)
        {
            StartCoroutine(ToGrow(time));
        }

    }
    

    IEnumerator ToGrow(int value)
    {
        canWater = false;
        toGrow = false;
        if(value == 1)
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("phaseTwo", true);
            anim.SetBool("phaseThree", false);
            anim.SetBool("phaseFour", false);
        }
        
        else if(value == 2)
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("phaseTwo", false);
            anim.SetBool("phaseThree", true);
            anim.SetBool("phaseFour", false);
        }
        else if(value == 3)
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("phaseTwo", false);
            anim.SetBool("phaseThree", false);
            anim.SetBool("phaseFour", true);
            sap = true;
        }
        yield return new WaitForSeconds(0.8f);
        toGrow = true;
        canWater = true;
    }


    public void Delete()
    { 
        Destroy(gameObject);
    }
}
