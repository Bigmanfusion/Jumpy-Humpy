using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    public  float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth) ;

        if(currentHealth > 0) 
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(dead)
            {
                anim.SetTrigger("die");


                if(GetComponent<Bumper>() != null) 
                GetComponent<Bumper>().enabled = false;


                if (GetComponentInParent<LizudoPatrol>() != null)
                  
                    GetComponentInParent<LizudoPatrol>().enabled = false;
                
                if(GetComponent<Lizudo>() != null)
                GetComponent<Lizudo>().enabled = false;

                dead = true;
            }
          
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    ///private void Update()
  //  {
    ///    if(Input.GetKeyUp(KeyCode.E)) 
    ///        TakeDamage(1);
   // }
}
