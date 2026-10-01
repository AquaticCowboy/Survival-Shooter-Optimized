using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Enemy_Data_Template EnemyData;
    public int currentHealth;
    public AudioClip deathClip;
    public EnemyPool pool;


    Animator anim;
    int ID_Dead = Animator.StringToHash("Dead");
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    NavMeshAgent _agent;
    Rigidbody rb;
    
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        

        currentHealth = EnemyData.MaxHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * EnemyData.SinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (ID_Dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        _agent.enabled = false;
        rb.isKinematic = true;
        isSinking = true;
        ScoreManager.score += EnemyData.ScoreValue;
        StartCoroutine(ReturnToQueue());
    }

    public void SetPool(EnemyPool inputPool)
    {
        pool = inputPool;
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.addToQueue(this);
        }
    }

    IEnumerator ReturnToQueue()
    {

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
