﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class HighScoreText : MonoBehaviour {

    Text highscore;

    // Use this for initialization
    void OnEnable()
    {
        highscore = GetComponent<Text>();
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    //// Update is called once per frame
    //void Update () {

    //}
}
