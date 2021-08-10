using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private float timeS = 0.0f;
    private float stunValue = 0;
    private bool isGameActive;
    public GameObject target;
    public GameObject titleScreen;
    public GameObject all;
    public GameObject plane;
    private float spawn = 0;
    public float spawnMax = 30;
    public float detectionRange;
    private float[] supply;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stunText;
    public TextMeshProUGUI youWin;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI objectsLeft;

    private Vector3 min = new Vector3(130, -38, -314);

    private Vector3 max = new Vector3(325, 151, 38);
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Supply") == null && isGameActive) YouWin();
        Debug.Log("Time = " + timeS);
    }

    public void YouWin()
    {
        
        StopCoroutine(Timer());
        youWin.gameObject.SetActive(true);
        youWin.text = "You Won with a time of: " + timeS + " seconds";
        isGameActive = false;
        Time.timeScale = 0;




    }

    IEnumerator Timer()
    {
       while (isGameActive)
        {
            timeCount();
            yield return new WaitForSeconds(1);
            
        }
    }
    public void timeCount()
    {
        timeS++;
        scoreText.text = "Time: " + timeS;
    }

   

    public void SpawnEnemies()
    {
        while(spawn < spawnMax)
        {
            Instantiate(target, new Vector3(Random.Range(min.x,max.x),Random.Range(min.y,max.y),Random.Range(min.z,max.z)), Quaternion.Euler(0,0,0));
            spawn++;
        } 
    }
   
    public void StunScore(float stunVal)
    {
        stunText.text = "Stun: " + Mathf.RoundToInt(stunVal);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(Timer());
        SpawnEnemies();
        //Timer(0);
        StunScore(0);
        detectionRange = difficulty * 10;
        //all.gameObject.SetActive(true);
        plane.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    public void RestartGame()
    {
        youWin.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
