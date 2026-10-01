using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
    int ID_GameOver = Animator.StringToHash("GameOver");


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger(ID_GameOver);

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
        }
    }
}
