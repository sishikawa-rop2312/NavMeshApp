using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    CharacterController cc;
    Animator charAnim;

    float pushPower = 2.0f;
    public bool isAttacking { get; set; }

    Vector3 dir = Vector3.zero;
    public float gravity = 20.0f;
    public float speed = 4.0f;
    public float rotSpeed = 300.0f;
    public float jumpPower = 8.0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        charAnim = GetComponent<Animator>();
    }


    void Update()
    {
        //前進成分を取得(0~1),今回はバックはしない
        float acc = Mathf.Max(Input.GetAxis("Vertical"), 0f);
        //設置いていたら
        if (cc.isGrounded)
        {
            //左右キーで回転
            float rot = Input.GetAxis("Horizontal");
            //回転は直接トランスフォームをいじる
            transform.Rotate(0, rot * rotSpeed * Time.deltaTime, 0);

            if (Input.GetButtonDown("Jump"))
            {
                //ジャンプ開始
                dir.y = jumpPower;

                // ジャンプアニメーション
                charAnim.SetTrigger("jump");
            }
        }
        //下方向の重力成分
        dir.y -= gravity * Time.deltaTime;

        //CharacterControllerはMoveでキャラを移動させる。
        cc.Move((transform.forward * acc * speed + dir) * Time.deltaTime);
        //移動した後着していたらy成分を0にする。
        if (cc.isGrounded)
        {
            dir.y = 0;
        }

        // 攻撃アニメーション
        if (Input.GetKeyDown(KeyCode.A))
        {
            charAnim.SetTrigger("attack");
        }

        // Runアニメーション
        charAnim.SetFloat("speed", acc);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb == null || rb.isKinematic)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.velocity = pushDir * pushPower;
    }

    public void AttackingStart()
    {
        isAttacking = true;
    }

    public void AttackingEnd()
    {
        isAttacking = false;
    }
}