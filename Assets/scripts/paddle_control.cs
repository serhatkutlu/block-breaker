
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_control : MonoBehaviour
{


    [SerializeField] float paddle_max;
    GameManager gm;
    void Start()
    {

        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount>0)
        {
            
            if (Input.GetMouseButton(0)&&gm.gamestart)
            {
                paddle_move();
            }
        }
        




    }



    private void paddle_move()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touch_vector =Camera.main.ScreenToWorldPoint(touch.position);
        transform.position =new Vector2(touch_vector.x,transform.position.y) ;
        paddle_clamp(paddle_max);
    }

    private void paddle_clamp(float value)
    {
        transform.position=new Vector2(Mathf.Clamp(transform.position.x,-value,value),transform.position.y);
    }
}
