using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizudoPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [Header("Enemy Animator")]
    [Header("Movement parameters")]
    [SerializeField] private float speed;
    [Header("Idle Behaviour")]
    [SerializeField]private float idleDuration;
    private float idleTimer;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField]private Animator anim;
    

    private void Awake()
    {
        initScale= enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void MoveInDirection(int _direction) 
    {

        idleTimer = 0;
        anim.SetBool("moving", true);


        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (movingLeft) 
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
         
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)   
                MoveInDirection(1);
            else
                DirectionChange();
           
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
          movingLeft = !movingLeft;
    }
}
