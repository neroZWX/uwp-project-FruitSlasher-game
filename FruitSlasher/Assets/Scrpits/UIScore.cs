using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {
    public static UIScore Instance = null;//单例对象
    private void Awake()
    {
        Instance = this;
    }
    public Text txtScore;
    public int score =0;
    public void Add(int score) {
        this.score += score;
        txtScore.text = this.score.ToString();
    }
    public void Remove(int score) {
        this.score -= score;
        if (this.score < 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            return;
        }
        txtScore.text = this.score.ToString();
       
    }
    
}
