using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0.1f, 30.0f)]
    public float speed;

    [Range(30.0f, 100.0f)]
    [SerializeField]
    float speedFactor = 50.0f;

    Rigidbody2D enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.velocity = new Vector2(-speed * Time.fixedDeltaTime * speedFactor, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyRigidbody.velocity = new Vector2(-speed * Time.fixedDeltaTime * speedFactor, 0f);
    }
}
