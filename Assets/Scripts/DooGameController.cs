using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DooGameController : MonoBehaviour
{

    int gameLV;

    //두더지 게임 시작 대기 
    float elapsedTimeReadyStep;

    //두더자 게임 진행 시간
    float elapsedTimeOnStep;

    int gameScore;

    int moleCounts;

    public GameObject mole;

    //public GameObject tempText;

    public TextMeshProUGUI textScore;

    public TextMeshProUGUI countDown;

    enum Steps
    {
        readyStep,
        onStep,
        judgeStep,
        nextStep,
    }

    private Steps nowStep;

    void Awake()
    {
        gameLV = 1;

        elapsedTimeReadyStep = 3;

        gameScore = 0;

        moleCounts = 3;

        //tempText.GetComponent<TextMesh>().text = "100";
    }

    // Start is called before the first frame update
    void Start()
    {
        nowStep = Steps.readyStep;

        mole.GetComponent<MoleWork>().setAvail(true);
    }

    // Update is called once per frame
    void Update()
    {

        switch (nowStep)
        {
            case Steps.readyStep:

                ReadyGame();

                break;

            case Steps.onStep:

                OnGame();

                break;

            case Steps.judgeStep:

                JudgeGame();

                break;
            case Steps.nextStep:

                NextGame();

                break;

        }

        textScore.text = "Score : " + gameScore.ToString();

    }

    public void catchMole()
    {
        gameScore = gameScore + 100;
    }

    public void ReadyGame()
    {
        elapsedTimeReadyStep = elapsedTimeReadyStep - Time.deltaTime;

        if(elapsedTimeReadyStep > 2.0f)
        {
            countDown.text = "3";
        }
        else if (elapsedTimeReadyStep > 1.0f)
        {
            countDown.text = "2";
        }
        else if (elapsedTimeReadyStep > 0f)
        {
            countDown.text = "1";
        }
        else if (elapsedTimeReadyStep < 0f && elapsedTimeReadyStep > -1.0f)
        {
            countDown.text = "Start";
        }
        else if (elapsedTimeReadyStep < -1.0f)
        {
            countDown.text = "";

            nowStep = Steps.onStep;
        }
    }

    public void OnGame()
    {


    }

    public void JudgeGame()
    {

    }

    public void NextGame()
    {

    }
}
