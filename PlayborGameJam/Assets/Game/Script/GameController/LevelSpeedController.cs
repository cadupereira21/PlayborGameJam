using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeedController : MonoBehaviour
{
    public BackgroundTextureAnimator bgAnimator_1;
    public BackgroundTextureAnimator bgAnimator_2;

    int minutes = 0;
    float seconds = 0;
    [SerializeField] private float secondsLimit = 1.1f;
    [SerializeField] float bgSpeedAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        Debug.Log(seconds);

        if (seconds > secondsLimit)
        {
            AccelerateLevel();
            minutes++;
            seconds = 0;

        }
    }

    void AccelerateLevel()
    {
        bgAnimator_1.speed = bgAnimator_1.speed * bgSpeedAcceleration;
        bgAnimator_2.speed = bgAnimator_2.speed * bgSpeedAcceleration;
    }
}
