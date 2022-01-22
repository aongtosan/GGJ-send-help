using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform snakePosition;
    private float normalSpeed = 2.5f;
    private float panicSpeed = 4f;
    Quaternion initAngle;

    private NavMeshAgent agent;
    private void Awake()
    {
        snakePosition = GameObject.FindGameObjectWithTag("Player").transform;
        initAngle = transform.rotation;
        Debug.Log(initAngle);
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 1f;
    }
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance) {
            SetNewDestination();
        }
        transform.LookAt(agent.nextPosition);
        transform.Rotate(Vector3.right, -90f); //account for swapped y/z axis from blender model
        float areaOfPanic = (transform.position - snakePosition.position).magnitude;
        if(areaOfPanic <= 10)
        {
            agent.speed = panicSpeed;
        } else {
            agent.speed = normalSpeed;
        }
    }

    private void SetNewDestination() {
        //Just hard-coding this for now, assumes we're using a fixed size ground plane
        Vector3 target = new Vector3(Random.Range(-18, 18), 0f, Random.Range(-18, 18));
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target, path);
        while (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid) {
            target = new Vector3(Random.Range(-18, 18), 0f, Random.Range(-18, 18));
            agent.CalculatePath(target, path);
        }
        agent.SetDestination(target);
    }
}
