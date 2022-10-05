using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerRot;
    [SerializeField] private Player player;
    [SerializeField] float posY = 0.2f;

    Touch touch;
    float counter;
    public static float speed = 0.2f;


    private float stairRotY;
    private float stairPosY;
    void OnEnable()
    {
        EventManager.MousePressEvent += PlayerTransformSituation;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Data.HaveRecord("SpeedValue"))
            speed = Data.GetSpeed();

        counter = speed;
        stairPosY = -posY;
        stairRotY = -playerRot;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && GameState.playGame)
        {

            if (!Timer()) return;
            EventManager.MousePressEvent.Invoke();


        }
        else
        {
            player.IdleAnimation();

        }
#else
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Stationary && GameState.playGame)
            {
                if (!Timer()) return;
                EventManager.MousePressEvent.Invoke();
            }
            else
            {
                player.IdleAnimation();
            }
        }
#endif



      
    }

    public void PlayerTransformSituation()
    {
        transform.position = Climb(posY);
        transform.rotation = PlayerDirection(playerRot);
        counter = speed;

    }


    public Vector3 Climb(float posY)
    {
        stairPosY += posY;
        return new Vector3(transform.position.x, stairPosY, transform.position.z);
    }


    public Quaternion PlayerDirection(float rotY)
    {
        stairRotY += rotY;
        return Quaternion.AngleAxis(stairRotY, Vector3.up);
    }
    private bool Timer()
    {
        if (counter >= 0)
        {
            counter -= Time.deltaTime;

            return false;
        }
        return true;
    }

    void OnDisable()
    {
        EventManager.MousePressEvent -= PlayerTransformSituation;
    }
}
