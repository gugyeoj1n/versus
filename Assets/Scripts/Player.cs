using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody rigid;
    private Animator animator;
    public List<SphereCollider> attackColliders;
    public bool isAttacking = false;

    void Awake()
    {
        instance = this;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        attackColliders = FindAttack( transform );
    }

    private List<SphereCollider> FindAttack( Transform parent )
    {
        List<SphereCollider> capsuleColliders = new List<SphereCollider>();

        foreach (Transform child in parent)
        {
            SphereCollider collider = child.GetComponent<SphereCollider>();
            if(collider != null)
            {
                capsuleColliders.Add(collider);
                collider.GetComponent<AttackCollider>( ).player = this;
            }

            capsuleColliders.AddRange(FindAttack(child));
        }

        return capsuleColliders;
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        // 이동 입력 처리
        if (input != 0f)
        {
            transform.Translate(Vector3.back * input * 3f * Time.deltaTime);
            animator.SetInteger("Move", input > 0 ? 1 : -1);
        }
        else
        {
            animator.SetInteger("Move", 0);
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
            isAttacking = true;
        }

        // 마우스 우클릭 입력 처리
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Kick");
            isAttacking = true;
        }
    }

    public void OnAttackFinished( )
    {
        isAttacking = false;
    }
}