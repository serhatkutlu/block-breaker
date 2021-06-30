
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_control : MonoBehaviour
{
   
   
    
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            paddle_move();
        }
        
    }

   

    private void paddle_move()
    {
        Vector2 mouse_vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position =new Vector2(mouse_vector.x,transform.position.y) ;
    }
}
