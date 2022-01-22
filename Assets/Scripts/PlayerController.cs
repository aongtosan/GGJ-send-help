using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject part;
    private float speed = 5f;
    private List<GameObject> body = new List<GameObject>();
    private List<Vector3> positionPart = new List<Vector3>();
    void Awake(){
        Growing();
        Growing();
        Growing();
    }
    void Start()
    {

    }
    void Growing(){
        GameObject newPart = Instantiate(part);
        body.Add(newPart);
    }
    void FixedUpdate()
    {

        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        float turn1Direction =  Input.GetAxis("Player1Horizontal"); 
        float turn2Direction =  Input.GetAxis("Player2Horizontal"); 
        transform.Rotate(Vector3.up * (turn1Direction + turn2Direction) * 180 * Time.fixedDeltaTime);
        positionPart.Insert(0,transform.position);
        GameObject headR = GameObject.Find("HeadR");
        GameObject headL = GameObject.Find("HeadL");
        
        headL.transform.Rotate(Vector3.up * turn2Direction * 180 * Time.fixedDeltaTime);
        headR.transform.Rotate(Vector3.up * turn1Direction * 180 * Time.fixedDeltaTime);
        int index = 0;
        int gap = 10;
        foreach(GameObject part in body){
            Vector3 partLoc =  positionPart[Mathf.Min(index * gap,  positionPart.Count-1)];
            part.transform.position = partLoc;
            index++;
        }


    }
}
