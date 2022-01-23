using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startScreen;
    public UnityEvent OnGameStart;

    public GameObject[] foodPrefabs;

    [SerializeField]
    private int maxFood = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
        if (food.Length < maxFood) {
            GameObject foodToSpawn = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            Vector3 spawnLocation = new Vector3(Random.Range(-19f, 19f), 0f, Random.Range(-19f, 19f));
            Instantiate(foodToSpawn, spawnLocation, foodToSpawn.transform.rotation);
        }
    }
}
