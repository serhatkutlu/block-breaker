using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uı : MonoBehaviour
{
    GameManager gm;
    Text scoretext;
    int score;
    GameObject panel;
    Slider slider;
    
    
    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        scoretext = GameObject.Find("score").GetComponent<Text>();
        panel = GameObject.Find("Panel");
        slider = GameObject.FindObjectOfType<Slider>();
        if (PlayerPrefs.HasKey("difficulty"))
        {
            int last_difficulty = PlayerPrefs.GetInt("difficulty");
            slider.value = last_difficulty;
        }
       
        
    }
    private void Update()
    {
        
       

        if (!gm.gamestart)
        {
            slider_difficulty();
        }
        
    }

    private void slider_difficulty()
    {
        int difficulty =(int)slider.value;
        gm.difficulty =  difficulty;
        PlayerPrefs.SetInt("difficulty", difficulty);
    }
    
    // Update is called once per frame
    public void startbutton()
    {
       
        gm.gamestart = true;
        panel.SetActive(false);
       
    }
    public void score_update()
    {
        score += 45;
        scoretext.text = score.ToString();

    }

}

