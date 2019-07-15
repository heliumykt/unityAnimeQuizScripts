using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class GamePlay : MonoBehaviour
{
    public GameObject background;
    public GameObject personImage;
    public GameObject trueAnswer;
    public GameObject falseAnswer;
    public GameObject timerText;
    public GameObject pointsText;
    public GameObject gameOver;
    //gameobject текст итогов
    public GameObject varResultText;
    public GameObject varScoreText;
    public GameObject varCharactersText;
    public GameObject varCorrectText;
    public GameObject varWrongAnswersText;

    public int checkSelectedButton=0;
    private int correctAnswers=0;
    private int wrongAnswers=0;
    private int numberOfCharacters;
    private string answer="0";
    private float timerGamePlay = 60;
    private int scorePoints = 0;
    private List<Sprite> products = new List<Sprite>{};
    
    void Start()
    {
        int numberOfDrawings = 0;
        bool end = false;
        //получаем массив спрайтов
        while(true){
            for(int i = 1; i<=5;i++){
                if(Resources.Load<Sprite>("Heroes/"+numberOfDrawings+i)!=null){
                    products.Add(Resources.Load<Sprite>("Heroes/"+numberOfDrawings+i));
                    break;
                }
                if(i==5){
                    end = true;
                }
            }
            if(end==true) break;
            numberOfDrawings++;
        }
        numberOfCharacters=products.Count;
    }
    void Update(){
        if(timerGamePlay>0){
            timerGamePlay=timerGamePlay-Time.deltaTime;
            timerText.GetComponent<Text>().text=Convert.ToInt32(timerGamePlay).ToString();
        }
        else {
            EndMenu();
        }

        int intAnswer = Int32.Parse(answer);
        if(checkSelectedButton==intAnswer){
            //проверка на правильность ответа
            if(intAnswer!=0){
                scorePoints=scorePoints+500;
                pointsText.GetComponent<Text>().text=scorePoints.ToString();
                trueAnswer.SetActive(true);
                correctAnswers++;
                Invoke("TrueAnswer",1);
            }
            if(products.Count>1){
            //делаем рандом
            int random = UnityEngine.Random.Range(0,products.Count);

            //замена картинки по рандому
            background.GetComponent<Image>().sprite=products[random];
            personImage.GetComponent<Image>().sprite=products[random];

            
            //узнаем правильный ответ
            answer = products[random].ToString();
            answer = answer.Replace(" (UnityEngine.Sprite)","");
            answer = answer.Substring(answer.Length-1);
            products.RemoveAt(random);
            //обнуляем чек
            checkSelectedButton=0;
            }
            else{
                //последний вариант ответа
                if(checkSelectedButton==intAnswer){
                    EndMenu();
                    answer="123";
                }
            }
        }
        else if(checkSelectedButton!=0){
            //неправильные ответы
            scorePoints=scorePoints-200;
            pointsText.GetComponent<Text>().text=scorePoints.ToString();
            falseAnswer.SetActive(true);
            wrongAnswers++;
            Invoke("FalseAnswer",1); 
            checkSelectedButton=0;
        }
    }
    //отключение картинки с ответами
    void TrueAnswer(){
        trueAnswer.SetActive(false);
    }
    void FalseAnswer(){
        falseAnswer.SetActive(false);
    }
    void EndMenu(){
        gameOver.SetActive(true);
        varScoreText.GetComponent<Text>().text=scorePoints.ToString();

        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Note: make sure to add 'using GooglePlayGames'
            PlayGamesPlatform.Instance.ReportScore(scorePoints,
                GPGSIds.leaderboard_best_players,
                (bool success) =>
                {
                    Debug.Log("(AnimeQuiz Battle Arena) Leaderboard update success: " + success);
                });
        }

        if (scorePoints>20000){
            varResultText.GetComponent<Text>().text="Very good!!!! ;DDD";
        }
        else if(scorePoints>10000){
            varResultText.GetComponent<Text>().text="Good! :)";
        }
        else if(scorePoints>4000){
            varResultText.GetComponent<Text>().text="normal -_-";
        }
        else{
            varResultText.GetComponent<Text>().text="bad ... :((((";
        }

        varCharactersText.GetComponent<Text>().text=(numberOfCharacters-products.Count).ToString();
        varCorrectText.GetComponent<Text>().text=correctAnswers.ToString();
        varWrongAnswersText.GetComponent<Text>().text=wrongAnswers.ToString();
    }

}
