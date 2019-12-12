using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] managers;
    public GameObject[] dialogue;
    public GameObject canvas;
    float timer = 0;
    public static bool dialogueOut = false;

    // Spawns a random manager once
    private void Spawn()
    {
        int count = 0;
        int dCount = 0;
        int dialogueChance = 0;

        count = Random.Range(0, managers.Length);
        dCount = Random.Range(0, dialogue.Length);
        dialogueChance = Random.Range(0, 100);
        GameObject manager = Instantiate(managers[count], transform.position, managers[count].transform.rotation);
        //parent the clone to the object
        manager.transform.parent = transform;

        //print dialogue
        print(dialogueChance);
        if(dialogueOut==false)
        {
            if (dialogueChance < 10)
            {
                print("something should happen" + transform.name);
                GameObject canvasClone = Instantiate(canvas, transform.position, canvas.transform.rotation);
                GameObject dialogueText = Instantiate(dialogue[dCount], manager.transform.localPosition, dialogue[dCount].transform.rotation);
                RectTransform drt = dialogueText.GetComponent<RectTransform>();
                drt.localScale = new Vector3(0.025f, 0.025f, 0.025f);
                drt.localPosition = new Vector3(manager.transform.position.x, manager.transform.position.y+1.5f, manager.transform.position.z);
                canvasClone.gameObject.transform.position = manager.transform.position;
                canvasClone.transform.parent = manager.transform;
                dialogueText.transform.parent = canvasClone.transform;
                dialogueOut = true;
            }
        }

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
        timer = timer - 1 * Time.deltaTime;
        if (timer < 0)
        {
            Spawn();
        }
    }
}
