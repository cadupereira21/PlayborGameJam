using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0.1f, 30.0f)]
    [SerializeField] 
    float speed;

    Rigidbody2D enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.velocity = new Vector2(-speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
