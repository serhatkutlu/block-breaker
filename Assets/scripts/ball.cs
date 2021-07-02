using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    
    [SerializeField] int ball_velocity;
    [SerializeField] float ball_random_speed;
    bool first_jump_bool=true,deadbool=true;
    GameObject paddle;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && first_jump_bool)
        {

            first_jump(ball_velocity);


        }
        if (transform.position.y+1<paddle.transform.position.y&&deadbool)
        {
            dead();
            deadbool = false;
        }
    }

    private void dead()
    {
        print("dead");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        bug_fix();
 
        speed_balancing();
       
    }
private void bug_fix()
    {
        if (rb.velocity.y>-2&&rb.velocity.y<2)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 3);
        }
        rb.velocity = new Vector2(rb.velocity.x +rb.velocity.x/ball_velocity, rb.velocity.y);
    }
    private void speed_balancing()
    {
        float x_velocity = Mathf.Clamp(rb.velocity.x, -ball_velocity, ball_velocity);
        float y_velocity = Mathf.Clamp(rb.velocity.y, -ball_velocity, ball_velocity);

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
