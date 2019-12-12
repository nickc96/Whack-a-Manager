using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static string myManager;
    float timer = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Disappear after some time if not clicked
        timer = timer - 1 * Time.deltaTime / 2;
        if (timer < 0)
        {
            if (this.gameObject.CompareTag(myManager))
            {
                Player.statScore += 1;
            }
            if (!(this.gameObject.CompareTag(myManager)))
            {
                Player.statScore -= 1;
            }
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (this.gameObject.CompareTag(myManager))
        {
            Player.statScore -= 1;
            Spawner.dialogueOut = false;
        }
        if (!(this.gameObject.CompareTag(myManager)))
        {
            Player.statScore += 1;
            Spawner.dialogueOut = false;
        }

        Destroy(this.gameObject);
    }
}
