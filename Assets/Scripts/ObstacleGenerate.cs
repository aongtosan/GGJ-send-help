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
        for(int i=0; i < 10; i++)
        {
            Vector3 obsPosition = new Vector3(Random.Range(-15, 15), 1 , Random.Range(-15, 15));
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
