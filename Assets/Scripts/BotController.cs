using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private Vector2 lookDirection = new Vector2(1, 0);

    public float speed = 5;

    float horizontal;
    float vertical;

    private Animator animator;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        MoveAnimation();
        IdleAnimation();
    }
    private void FixedUpdate() //移动
    {
        Vector2 move = new Vector2(horizontal, vertical);

        // 规范化移动向量以保持斜向移动速度一致
        move.Normalize();

        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(0, move.y))
        {
            lookDirection.Set(move.x, move.y);
        }

        Vector2 position = rigidbody2d.position;

        // 当没有移动输入时，停止移动
        if (horizontal != 0 || vertical != 0)
        {
            position += speed * move * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position);
    }
    private void MoveAnimation()//移动动画
    {
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
        animator.SetFloat("Ifidle", -1);
    }
    private void IdleAnimation()//静止朝向
    {
        Vector2 move = new Vector2(horizontal, vertical);
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetFloat("Ifidle", 1);
            animator.SetFloat("MoveX", lookDirection.x);
            animator.SetFloat("MoveY", lookDirection.y);
        }
    }
}
