using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D arrowRB;
    [SerializeField]
    private float arrowSpeed;
    private Vector2 _arrowDirection;
    private Collider2D levelLimit;

    public Vector2 ArrowDirection { get => _arrowDirection; set => _arrowDirection = value; }

    [SerializeField]private GameObject arrowImpact;
    [SerializeField] private GameObject arrowImpactBat;
    private Transform transformArrow;

    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody2D>();
        transformArrow = GetComponent<Transform>();
    }

    private void Start()
    {
        levelLimit = GameObject.Find("LevelLimit").GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        arrowRB.velocity = ArrowDirection * arrowSpeed;
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ArrowCollisionDetection(collision);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void ArrowCollisionDetection(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().EnemyDestroy();
            Instantiate(arrowImpactBat, transformArrow.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
                if (collision != levelLimit)
        {
            if (!collision.CompareTag("Item"))
            {
                Instantiate(arrowImpact, transformArrow.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
