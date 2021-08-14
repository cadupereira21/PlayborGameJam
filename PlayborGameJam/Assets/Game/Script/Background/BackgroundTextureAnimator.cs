using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTextureAnimator : MonoBehaviour
{
    private Material mat;
    private Vector2 offset;

    [Range(0.1f, 100.0f)]
    [SerializeField]
    float speed = 5f;

    [Range(0.1f, 100.0f)]
    [SerializeField]
    float speedController = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = offset.x + (speed * Time.deltaTime / speedController);
        mat.SetTextureOffset("_MainTex", offset);
    }
}
