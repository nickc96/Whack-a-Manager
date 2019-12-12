using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] managers;
    float timer = 0;

    // Spawns a random manager once
    private void Spawn()
    {
        int count = 0;

        count = Random.Range(0, managers.Length);
        GameObject manager = Instantiate(managers[count], transform.position, managers[count].transform.rotation);
        //parent the clone to the object
        manager.transform.parent = transform;

        //reset timer
        timer = Random.Range(1,10);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - 1 * Time.deltaTime / 3;
        if (timer < 0)
        {
            Spawn();
        }
    }
}
