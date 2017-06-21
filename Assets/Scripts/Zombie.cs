using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    ENEMYSTATE enemyState = ENEMYSTATE.IDLE;
    //delegate void Func();
    //Dictionary<ENEMYSTATE, Func> dicState = new Dictionary<ENEMYSTATE, Func>();

    Dictionary<ENEMYSTATE, System.Action> dicState = new Dictionary<ENEMYSTATE, System.Action>();
    //System.Func ->반환값이 있다.

    public Animation anima;

    PlayerState playerState;

    private void Awake()
    {
        InitZombie();  
    }

    Transform target = null;
    CharacterController characterController = null;
    private void Start()
    {
        dicState[ENEMYSTATE.IDLE] = Idle;
        dicState[ENEMYSTATE.MOVE] = Move;
        dicState[ENEMYSTATE.ATTACK] = Attack;
        dicState[ENEMYSTATE.DAMAGE] = Damage;
        dicState[ENEMYSTATE.DEAD] = Dead;

        target = GameObject.FindWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();

        playerState = target.GetComponent<PlayerState>();
    }

    private void Update()
    {
        dicState[enemyState]();
    }

    float stateTime = 0.0f;
    public float idleStateMaxtime = 2.0f;
    void Idle()
    {
        stateTime += Time.deltaTime;

        if(stateTime > idleStateMaxtime)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.MOVE;
        }
    }

    void InitZombie()
    {
        enemyState = ENEMYSTATE.IDLE;
        PlayIdleAni();
    }

    void PlayIdleAni()
    {
        anima["Idle"].speed = 3.0f;
        anima.Play("Idle");
    }

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 2.5f;

    void Move()
    {
        anima["Move"].speed = 2.0f;
        anima.CrossFade("Move");

        Vector3 dir = target.position - transform.position;

        float length = dir.magnitude;

        if(length < attackRange)
        {
            enemyState = ENEMYSTATE.ATTACK;
            stateTime = attackStateTime;
        }
        else
        {

            dir.y = 0.0f;

            dir.Normalize();

            characterController.SimpleMove(dir * moveSpeed);

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(dir),
                rotationSpeed * Time.deltaTime);//from->to percentage
        }

    }

    public float attackStateTime = 2.0f;

    void Attack()
    {
        stateTime += Time.deltaTime;
        if(stateTime > attackStateTime)
        {
            stateTime = 0.0f;
            anima["Attack"].speed = -0.5f;
            anima["Attack"].time = anima["Attack"].length;

            anima.Play("Attack");

            playerState.DamageByEnemy();
        }
        Vector3 dir = target.position - transform.position;
        float length = dir.magnitude;
        if (length > attackRange)
        {
            enemyState = ENEMYSTATE.MOVE;
        }

    }

    public int hp = 5;
    void Damage()
    {
        --hp;

        AnimationState animState = anima.PlayQueued("Damage", QueueMode.PlayNow);

        animState.speed = 2.0f;
        float length = anima["Damage"].length / animState.speed;
        CancelInvoke();//don't use invoke just know
        Invoke("PlayIdleAni", length);
        stateTime = 0.0f;
        enemyState = ENEMYSTATE.IDLE;

        if (hp<=0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Ball")
        {
            return;
        }

        enemyState = ENEMYSTATE.DAMAGE;
    }
}
