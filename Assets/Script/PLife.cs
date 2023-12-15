using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool justDied = false;
    private float delayBeforeRestarting = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(HealthManager.health <= 0)
        {
            if(!justDied)
            {
                Die();
                justDied = true;
                StartCoroutine(RestartLevel());
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Trampa")){
            HealthManager.health--;
            if(HealthManager.health<=0){
                Die();
            }
            else{
                anim.SetTrigger("hurting");
            }
        }
    }

    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(delayBeforeRestarting);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
