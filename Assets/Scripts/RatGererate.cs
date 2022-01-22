using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatGererate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject ratPref;
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3 obsPosition = new Vector3(
                Random.Range(-(mesh.bounds.size.x / 2) * (transform.localScale.x - 1) + 0.5f, (mesh.bounds.size.x / 2) * (transform.localScale.x - 1) + 0.5f)
                , 1,
                  Random.Range(-(mesh.bounds.size.z / 2) * (transform.localScale.z - 1) + 0.5f, (mesh.bounds.size.z / 2) * (transform.localScale.z - 1)) + 0.5f);
            Instantiate(
                ratPref, obsPosition, ratPref.transform.rotation
            );     
    }
    void Update()
    {
        
    }
}
