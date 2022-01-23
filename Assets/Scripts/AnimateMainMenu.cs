using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMainMenu : MonoBehaviour
{
    public GameObject mouse;
    private float delta = 180f;
    private float multiplier = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime * multiplier;
        mouse.transform.rotation = Quaternion.Euler(new Vector3(-90,delta,0));
    }
}
