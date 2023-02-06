using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{

    private Rigidbody2D rgd;
    private new Animator animation;
    private BoxCollider2D collider;
    [SerializeField] private GameObject trap;

    [SerializeField] private AudioSource SpawnSound;
    [SerializeField] private AudioSource DeathSound;
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
        rgd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            collider.enabled = false;
        }
    }

    private void Die()
    {
        rgd.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("death");
        DeathSound.Play();
        Invoke("levelrestart", 5f);
    }

    private void levelrestart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
