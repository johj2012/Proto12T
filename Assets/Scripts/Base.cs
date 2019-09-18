using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EState // 캐릭터 상태 
{
    READY,
    IDLE,
    DAMAGED,
    DEAD,
    CLEAR
}

public class Base : MonoBehaviour
{
    // Start is called before the first frame update

    private bool eating;

    [SerializeField] // AllowPrivateAccess
    private float eatingSpeed;

    [SerializeField]
    private float Maxsatiety;

    [SerializeField]
    private float currentSatiety;

    [SerializeField]
    private float MaxHP;

    [SerializeField]
    private float currentHP;

    [SerializeField]
    private Slider hpSlider;

    [SerializeField]
    private Slider satietySlider;

    [SerializeField]
    private Collider2D collider;

    EState state = EState.READY;


    void Start()
    {

        eating = true;
        eatingSpeed = 1.0f;

        Maxsatiety = 100.0f;
        currentSatiety = 0.0f;

        MaxHP = 100.0f;
        currentHP = MaxHP;

        state = EState.IDLE;


        hpSlider.maxValue = MaxHP;
        hpSlider.value = MaxHP;

        satietySlider.maxValue = Maxsatiety;
        satietySlider.value = currentSatiety;

        collider = GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I don't eating!");
        currentHP = collision.GetComponentInParent<Enemy>().Attack();
        
    }

    void Damaged(float newDamaged)
    {
        if(currentHP - newDamaged <= 0.0f)
        {
            state = EState.DEAD;
        }

        currentHP -= newDamaged;
        
    }

    public EState CurrentState ()
    {
        
        return state;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EState.IDLE)
        {
            if (currentSatiety < Maxsatiety)
                {
                currentSatiety += Time.deltaTime*eatingSpeed;
                satietySlider.value = currentSatiety;
            }
            else
            {
                state = EState.CLEAR;
            }
        }


    }
}
