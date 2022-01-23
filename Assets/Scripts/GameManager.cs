using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour{

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int scorePoints;
    [SerializeField]
    public Text scoreText;

    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    public AudioSource timeAudioWin;

    [SerializeField]
    public ParticleSystem ps;

    void Start () {     
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        updateScore(0);
        ps.Play();
    }

    public void updateScore(int points) {
        scorePoints += points;
        scoreText.text = "Score: " + scorePoints;

        if (scorePoints == 6) {
            winPanel.SetActive(true);
            timeAudioWin.Play();
            Time.timeScale =0f;
        }
    }

    void SetCurrentQuestion () {
        int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue){
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "FALSE";
        } else {
            trueAnswerText.text = "FALSE";
            falseAnswerText.text = "CORRECT";
        }
    }

    void Transition() {
        unansweredQuestions.Remove(currentQuestion);
        Start ();
    }

    public void UserSelectTrue (){
        animator.SetTrigger("True");
        if (currentQuestion.isTrue) {
            Debug.Log("CORRECT!");
            updateScore(1);
        } else {
            Debug.Log("WRONG!");
        }

        Transition();
    }

        public void UserSelectFalse (){
            animator.SetTrigger("False");
        if (!currentQuestion.isTrue) {
            Debug.Log("CORRECT!");
            updateScore(1);
        } else {
            Debug.Log("WRONG!");
        }
        Transition();
    }
}
