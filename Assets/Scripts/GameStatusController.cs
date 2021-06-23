using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.1f, 20)][SerializeField] float speed;
    [SerializeField] int numberOfPointsPerBlock = 10;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI ScoreField;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatusController>().Length;
        if (gameStatusCount > 1)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        ScoreField.text = score.ToString();   
    }

    public void ScoreCalculator()
    {
        score = numberOfPointsPerBlock + score;
        ScoreField.text = score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
    }
}
