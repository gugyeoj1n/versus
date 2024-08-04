using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody rigid;
    private Animator animator;

    void Awake()
    {
        instance = this;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        // 이동 입력 처리
        if (input != 0f)
        {
            transform.Translate(Vector3.back * input * 3f * Time.deltaTime);

            // 이동 방향에 따른 애니메이터 변수 설정
            if (input > 0f)
            {
                animator.SetBool("isFront", true);
                animator.SetBool("isBack", false);
            }
            else
            {
                animator.SetBool("isFront", false);
                animator.SetBool("isBack", true);
            }
        }
        else
        {
            animator.SetBool("isFront", false);
            animator.SetBool("isBack", false);
        }

        // 왼쪽 쉬프트 키 입력 처리
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isCrouch", true);
        }
        else
        {
            animator.SetBool("isCrouch", false);
        }

        // 마우스 좌클릭 입력 처리
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Punch");
        }

        // 마우스 우클릭 입력 처리
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Kick");
        }
    }
}