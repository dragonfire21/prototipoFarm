using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSeed : MonoBehaviour
{
    [SerializeField] private int sideDrop;
    public bool drop;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        StartCoroutine(MovingDrop());
    }
    public Sprite SeedWhetSprite()
    {
        sprite = spriteRenderer.sprite;

        return sprite;
    }
    public void Delete()
    {
        Destroy(gameObject);
    }

    public void GetSide(int side)
    {
        switch (side)
        {
            case 1:
                sideDrop = 1;
                break;

            case 2:
                sideDrop = 2;
                break;

            case 3:
                sideDrop = 3;
                break;

            case 4:
                sideDrop = 4;
                break;

            default:
                sideDrop = 1;
                break;
        }
    }

    IEnumerator MovingDrop()
    {
        if (drop)
        {
            switch (sideDrop)
            {
                case 1:
                    yield return new WaitForSeconds(0.042f);
                    transform.Translate(new Vector2(21f, transform.position.y) * Time.deltaTime);
                    drop = false;
                    break;

                case 2:
                    yield return new WaitForSeconds(0.042f);
                    transform.Translate(new Vector2(-21f, transform.position.y) * Time.deltaTime);
                    drop = false;
                    break;

                case 3:
                    yield return new WaitForSeconds(0.042f);
                    transform.Translate(new Vector2(transform.position.x, 21f) * Time.deltaTime);
                    drop = false;
                    break;

                case 4:
                    yield return new WaitForSeconds(0.042f);
                    transform.Translate(new Vector2(transform.position.x, -21f) * Time.deltaTime);
                    drop = false;
                    break;
            }
        }

    }
}
