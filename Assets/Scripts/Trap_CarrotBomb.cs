using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap_CarrotBomb : Trap
{
    [SerializeField] private float ad;

    [SerializeField] private bool bomb;

    [SerializeField] private float boundDistance;

    [SerializeField]
    protected CircleCollider2D collider;

    private GameObject[] enemy;

    


    // Start is called before the first frame update
    protected override void Start()
    {
        ad = 30.0f;
        bomb = false;
        boundDistance = 3.0f;
        collider = gameObject.GetComponent<CircleCollider2D>();

        gameObject.GetComponent<CircleCollider2D>().radius = 0.64f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("onTrigger");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Check");
            bomb = true;
        }
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(bomb)
        {
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            
            for (int i = 0; i<=enemy.Length-1; i++)
            {
                if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                    new Vector2(enemy[i].transform.position.x, enemy[i].transform.position.y))<= boundDistance)
                {
                    enemy[i].GetComponentInParent<Enemy>().GetDamaged(ad);
                }
            }
            // 애니메이션 재생 
            Destroy(this.gameObject);
        }


        /*for()
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(enemy.transform.position.x, enemy.transform.position.y)) < 5.0f)
        {
            Debug.Log(Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(enemy.transform.position.x, enemy.transform.position.y)));
            enemy.GetComponentInParent<Enemy>().GetDamaged(ad);
        }  */
    }
}
