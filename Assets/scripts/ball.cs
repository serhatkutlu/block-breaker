using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    
    private int difficulty=4;
    
    bool first_jump_bool=true,deadbool=true,start;
    GameObject paddle;
    Rigidbody2D rb;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gamestart)
        {

            difficulty = gm.difficulty;
            if (Input.GetMouseButtonUp(0) && first_jump_bool&&start)
            {

                first_jump(difficulty);


            }
            if (transform.position.y + 1 < paddle.transform.position.y && deadbool)
            {
                gm.Dead();
                deadbool = false;
            }
            
            start = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm.playaudio();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        bug_fix();
 
        speed_balancing();
        
        gm.nextlevel(); 
       
    }
private void bug_fix()
    {
        //prevents the ball from going into an infinite loop
        if (rb.velocity.x>-2&&rb.velocity.x<2)
        {
            rb.velocity = new Vector2(rb.velocity.x * 3, rb.velocity.y );
        }
        
        if (rb.velocity.y==0)
        {
            rb.velocity = new Vector2( rb.velocity.x,Random.Range(-difficulty, difficulty));
        }
        if (rb.velocity.x == 0)
        {
            rb.velocity = new Vector2(Random.Range(-difficulty, difficulty),rb.velocity.y);
        }
    }
    private void speed_balancing()
    {
        float x_velocity = Mathf.Clamp(rb.velocity.x, -difficulty, difficulty);
        float y_velocity = Mathf.Clamp(rb.velocity.y, -difficulty, difficulty);

        rb.velocity = new Vector2(x_velocity, y_velocity);
    }

    

    public void first_jump(int jump_velocity)
    {
        first_jump_bool = false;
        parrent_set();
        Vector2 random_vector = new Vector2(Random.Range(-jump_velocity, jump_velocity), jump_velocity);
        rb.velocity = random_vector;

    }

    private void parrent_set()
    {
        transform.parent = null;
    }
}
