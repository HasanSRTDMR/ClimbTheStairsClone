using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField]TMP_Text text;
    float scorePosY;
    public float score=-600;
    float riseValue = 0.2f;
    void OnEnable()
    {
        EventManager.MousePressEvent += ScoreTransformSituation;
    }
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        scorePosY = rectTransform.position.y;
        if (Data.HaveRecord("Score"))
            score = Data.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = String.Format("{0:0.0}", score) + " m";
    }
    public void ScoreTransformSituation()
    {
        rectTransform.position = ScoreUp(0.1f);
        score += riseValue;
        
    }
  
    public Vector3 ScoreUp(float posY)
    {
        scorePosY += posY;
        return new Vector3(transform.position.x, scorePosY, transform.position.z);
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= ScoreTransformSituation;
    }
}
