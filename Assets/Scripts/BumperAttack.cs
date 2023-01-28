using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] BumperBlasts;
    private Animator anim;
    private Bumper Bumper;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Bumper= GetComponent<Bumper>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && Bumper.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        BumperBlasts[FindBumperBlast()].transform.position = firePoint.position;
        BumperBlasts[FindBumperBlast()].GetComponent<BumperProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBumperBlast()
    {
        for (int i = 0; i <BumperBlasts.Length; i++)
        {
            if (!BumperBlasts[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
