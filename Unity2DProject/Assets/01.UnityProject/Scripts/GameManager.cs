using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;          // Text Mash Pro 컴포넌트 쓴 경우
    public Text scoreText_;    // Legacy Text 컴포넌트 쓴 경우
    public GameObject gameOverUi;
    public float growTime;
    public bool isMushroom = false;
    GameObject player;
    private int score = 0;

    private void Awake()
    {
        if (instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        //List<int> intList = null;

        //Debug.LogFormat("intList가 유효한지? (존재하는지?) : {0}", intList.IsValid());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            // GFunc.LoadScene("PlayScene");
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }

        if ((growTime + 3f) <= Time.time && growTime != 0f)
        {
            growTime = 0f;
            player.transform.localScale /= 2f;
            isMushroom = false;
        }
    }

    public void AddSCore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }

    public void LinkPlayer(GameObject player_)
    {
        player = player_;
    }
}
