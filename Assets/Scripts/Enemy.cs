using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float hp;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float ad;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private EState targetCurrentState;


    [SerializeField]
    private BoxCollider2D collider;

    
    


    // Start is called before the first frame update
    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Base");
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    protected void TargetChase()
    {
        targetCurrentState = target.GetComponent<Base>().CurrentState();

        if (targetCurrentState != EState.DEAD && targetCurrentState != EState.READY)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.transform.position, speed * Time.deltaTime);
        }
    }


    protected void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float Attack()
    {
        return ad;
    }

    public void GetDamaged(float damaged)
    {
        if (hp - damaged > 0)
        {
            hp -= damaged;
            Debug.Log("Get Damaged!");
        }
        else
        {
            Dead();
        }
    }

    void Dead()
    {
        // 죽는 애니메이션 재생
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }
}
