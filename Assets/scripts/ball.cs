using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int ball_velocity;
    [SerializeField] int firs_jump_velocity;
    bool first_jump_bool=true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && first_jump_bool)
        {

            first_jump(firs_jump_velocity);


        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        float x_velocity = Mathf.Clamp(rb.velocity.x, -ball_velocity, ball_velocity);
        float y_velocity = Mathf.Clamp(rb.velocity.y, -ball_velocity, ball_velocity);
        rb.velocity = new Vector2(x_velocity, y_velocity);
    }
    public void first_jump(int jump_velocity)
    {
        first_jump_bool = false;
        parrent_set();
        Vector2 random_vector = new Vector2(10, Random.Range(0, jump_velocity));
        rb.velocity = random_vector;

    }

    private void parrent_set()
    {
        transform.parent = null;
    }
}
