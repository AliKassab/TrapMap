using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLine : MonoBehaviour
{
    private AudioSource Win;

    private bool CompleteLevel = false;
    void Start()
    {
        Win = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !CompleteLevel)
        {
            CompleteLevel = true;
            Win.Play();
            Invoke("EndLevel", 2f);
           
        }
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
