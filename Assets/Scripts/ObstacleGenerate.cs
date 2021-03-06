using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject obsPref;
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        for (int i=0; i < 10; i++)
        {
            Vector3 obsPosition = new Vector3(
                Random.Range( -(mesh.bounds.size.x/2) * (transform.localScale.x - 1)+0.5f, (mesh.bounds.size.x / 2) * (transform.localScale.x - 1)+0.5f)
                , 1 ,
                  Random.Range(-(mesh.bounds.size.z / 2) * (transform.localScale.z - 1) + 0.5f, (mesh.bounds.size.z / 2) * (transform.localScale.z - 1)) + 0.5f);
            Instantiate(
                obsPref,obsPosition,obsPref.transform.rotation
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
