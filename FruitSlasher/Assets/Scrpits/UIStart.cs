using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour {

    private Button btnPlay;
    private Button btnSound;
    private Button EXIT;
    private AudioSource audioSourceBG;
    private Image imgSound;
    public Sprite[] soundSprites;//声音图片变化

	void Start () {
        getComponents();
       // EXIT.onClick.AddListener(onPlayClick);
        btnPlay.onClick.AddListener(onPlayClick);
        btnSound.onClick.AddListener(onSoundClick);

	}
    private void getComponents() {
        btnPlay = transform.Find("btnPlay").GetComponent<Button>();
        btnSound = transform.Find("btnSound").GetComponent<Button>();
        //EXIT = transform.Find("Exit").GetComponent<Button>();
        audioSourceBG = transform.Find("btnSound").GetComponent<AudioSource>();
        imgSound = transform.Find("btnSound").GetComponent<Image>();
    }
     void OnDestroy()
    {
        btnPlay.onClick.RemoveListener (onPlayClick);
        btnSound.onClick.RemoveListener(onSoundClick);
        
    }
    
    void onPlayClick() {
        SceneManager.LoadScene("play", LoadSceneMode.Single);
       // Application.Quit();
    }
    void onSoundClick() {
        if (audioSourceBG.isPlaying)
        {
            //正在播放
            audioSourceBG.Pause();
            imgSound.sprite=soundSprites[1];//显示不同的图片
        }
        else {
            audioSourceBG.Play();
            imgSound.sprite = soundSprites[0];
            //停止播放

        }
    }
}
