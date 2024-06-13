using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Collider2D col;
    private ParticleSystem destroyFX;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        destroyFX = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        destroyFX.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);

        }
    }

    public void EnemyDestroy()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;
        destroyFX.Play();
        Destroy(gameObject, 1);
        
    }
}
