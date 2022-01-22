using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform snakePosition;
    private float speed = 2.5f;
    Quaternion initAngle;
    private void Awake()
    {
        snakePosition = GameObject.FindGameObjectWithTag("Player").transform;
        initAngle = transform.rotation;
        Debug.Log(initAngle);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float areaOfPanic = (transform.position - snakePosition.position).magnitude;
        if (areaOfPanic<=20)
        {
            
            Quaternion lookatSnake = Quaternion.LookRotation(snakePosition.position - transform.position);;
            transform.rotation  = new Quaternion(initAngle.x,lookatSnake.y, initAngle.z, initAngle.w);
                
        }
        if(areaOfPanic <= 10)
        {
            transform.position += transform.up *speed* Time.deltaTime;

        }
    }
}
