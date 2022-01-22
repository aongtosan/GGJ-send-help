using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject part;
    private float speed = 5f;
    private List<GameObject> body = new List<GameObject>();
    private List<Vector3> positionPart = new List<Vector3>();

    [SerializeField]
    private int StartingLength = 10;

    [SerializeField]
    private GameObject mousePrefab;

    void Awake(){
        GameObject newPart = Instantiate(part);
        newPart.transform.SetParent(transform);
        body.Add(newPart);

        for (int i=0; i<StartingLength; i++) {
            Growing();
        }
    }
    void Start()
    {

    }
    void Growing(){
        GameObject newPart = Instantiate(part);
        newPart.transform.SetParent(body[body.Count - 1].transform);
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
        
        //headL.transform.Rotate(Vector3.up * turn2Direction * 180 * Time.fixedDeltaTime);
        //headR.transform.Rotate(Vector3.up * turn1Direction * 180 * Time.fixedDeltaTime);
        int index = 0;
        int gap = 10;
        foreach(GameObject part in body){
            Vector3 partLoc =  positionPart[Mathf.Min(index * gap,  positionPart.Count-1)];
            part.transform.position = partLoc;
            part.transform.LookAt(part.transform.parent.transform);
            index++;
        }


    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Obstacle")) {
            SceneManager.LoadScene("Game Over");
        } else if (other.collider.CompareTag("Food")) {
            Growing();
            Destroy(other.gameObject);

            // sound fx
            int rand = Random.Range(1, 7);
            FindObjectOfType<AudioManager>().Play($"eat{rand}");
        }
    }
}
