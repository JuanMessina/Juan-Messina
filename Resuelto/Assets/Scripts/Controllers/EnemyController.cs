using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyLife = 3f;
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public ThirdPersonPlayerController playerController;
    public float enemyDamage = 1f;
    private Coroutine enemyDamageCoroutine;
    public Animator animations;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); 

        

        

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            animations.SetBool("movimiento", true);

            if (distance <= agent.stoppingDistance)
            {
                animations.SetBool("movimiento", false);
                FaceTarget();
            }
        }

        if (enemyLife <= 0)
        {
            enemyDamage = 0;
            animations.SetTrigger("muerte");
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            target = null;
            Die();
        }

        
           
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Die()
    {

        
        Destroy(gameObject,5f);
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (enemyDamageCoroutine == null)
            {
               enemyDamageCoroutine = StartCoroutine("AtaqueEnemigo");
            }
        }
    }

    public IEnumerator AtaqueEnemigo ()
    {
        animations.SetTrigger("ataque");
        playerController.playerLife = playerController.playerLife - enemyDamage;
        yield return new WaitForSeconds(1f);
        enemyDamageCoroutine = null;
        
    }

    
}
