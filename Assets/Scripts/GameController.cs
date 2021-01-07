using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOvertext;
    public Text eliminatedText;
    public bool gameOver = false;  
    public bool eliminated1 = false;  
    public bool eliminated2 = false;  
    public float scrollSpeed = -1.5f;
    public Text scoreText;
    public Text scoreText2;   
    private int score = 0;
    private int score2 = 0;
    public GameObject bird2;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        if(PlayerPrefs.GetInt("multiplayer")==0){
            bird2.SetActive(false);
        }else{
            bird2.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        eliminatedText.text = "Go......";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene(). buildIndex);
    }
    public void BirdDied()
    {
        eliminatedText.text = "Player 1 Eliminated";
        eliminated1 = true;
        checkGameOver();
    }
    public void Bird2Died()
    {
        eliminatedText.text = "Player 2 Eliminated";
        eliminated2 = true;
        checkGameOver();
    }
    public void checkGameOver(){
        if(PlayerPrefs.GetInt("multiplayer")==0){
            if(eliminated1==true){
                eliminatedText.text = "";
                gameOver = true;
                gameOvertext.SetActive(true);
            }
        }else{
            if(eliminated1==true && eliminated2==true){
                eliminatedText.text = "";
                gameOver = true;
                gameOvertext.SetActive(true);
            }
        }
    }
    public void BirdScored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Player 1 : " + score.ToString();
    }
    public void Bird2Scored()
    {
        if (gameOver)
            return;
        score2++;
        scoreText2.text = "Player 2 : " + score.ToString();
    }
    public void backToMenu(){
        SceneManager.LoadScene("SceneMenu");
    }

}
