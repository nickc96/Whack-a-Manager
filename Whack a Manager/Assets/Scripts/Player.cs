using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text textScore;
    public static int statScore;
    float statTimer = 60;
    public Text textTimer;
    Text finalScore;
    bool final = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        //StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update()
    {
        if (final == true)
            return;
        statTimer = statTimer - 1 * Time.deltaTime;
        textScore.text = "Score: " + statScore;
        textTimer.text = "Time: " + (int)statTimer;

        if (statTimer < 0)
        {
            SceneManager.LoadScene("GameOver");
            StartCoroutine(Example());
            final = true;
        }

    }

    IEnumerator Example()
    {
        //yield return new WaitForSeconds(11);

            yield return new WaitForSeconds(0.1f);
            Scene gameOver = SceneManager.GetActiveScene();
            if(gameOver.name == "GameOver")
            {
                finalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>();
                finalScore.text = "Final Score: " + statScore;
            }

    }

}
