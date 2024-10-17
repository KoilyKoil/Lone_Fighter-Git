using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISet : MonoBehaviour
{
    public GameObject opponent;                 //�� ������. ���⼱ P1���� ����
    //bool jumpCount=false;                       //�������� ����
    public float jumppower=5f;
    public float movespeed=0.3f;
    public float speedLimit=1.2f;
    public float dirDiffer=0.6f;
    Animator anim;
    Rigidbody2D plrRigidbody;
    //AI���� ����. 0==����, 1==����
    int AIStat=0;

    void Awake()
    {
        //�ִϸ��̼� ������Ʈ ����
        anim=GetComponent<Animator>();
        //��ü �����ٵ� ����
        plrRigidbody=gameObject.GetComponent<Rigidbody2D>();
        anim.SetBool("Run", true);
    }


    void FixedUpdate()
    {
        /*
        AI ���� ��ȹ
        - �÷��̾ ������ �ൿ
        - - �̵�, ����, ����

        - AI�� �ϰ��� �ϴ� �ൿ
        - - �÷��̾ ����-> �ݰ� ���� ������ ����
        - - ���� �����ϸ� ���� -> ������ �� ���� �簳

        - AI ���� ��ȹ
        - - 1��1�� ���, �÷��̾ �ִ� �������� �̵� ����.
        - - ���� �÷��̾ �ݰ泻�� ������ �Ǹ� �ش� �÷��̾ ���� �߰�
        - - �÷��̾ �ٷ� �տ� ������ �Ϲݰ��� �Ǵ� �ʻ��
        - - �÷��̾ �Ʒ��� ������ ���߰���
        - - �÷��̾ ���� ������ �Ʒ�����
        - - �÷��̾�� ���� �Ÿ��� �Ǹ� �������

        - - �÷��̾ �����ϸ� �Ÿ��α� �Ǵ� ����

        or

        �̵� �� ���ٱ����� ��������, ������ �������� ó��?
        */

        //���� 0, ����
        if(AIStat==0)
        {
            anim.SetBool("Run", true);
            //�Ÿ����� ���� ���� ����
            if(gameObject.transform.position.x-opponent.transform.position.x>=0)
                gameObject.GetComponent<SpriteRenderer>().flipX=true;
            else
                gameObject.GetComponent<SpriteRenderer>().flipX=false;

            //ĳ���� �̵�
            float h=gameObject.GetComponent<SpriteRenderer>().flipX==true?-1f:1f;
            plrRigidbody.AddForce(new Vector2(movespeed*h,0), ForceMode2D.Impulse);

            //�ִ� �̼� ����
            if(plrRigidbody.velocity.x>speedLimit)
                plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
            else if(plrRigidbody.velocity.x<-speedLimit)
                plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);
        }
        else if(AIStat==1)
        {
            if(anim.GetInteger("AtkStat")==0)
            {
                anim.SetInteger("AtkStat", 1);
                anim.SetBool("Run", false);
                Invoke("StopAnim", 0.15f);
            }
        }

        //AI ���� ����
        if(Math.Abs(gameObject.transform.position.x-opponent.transform.position.x)<=dirDiffer)
        {
            AIStat=1;
        }
        else
        {
            AIStat=0;
        }
        
        /*
        //��ü �����ٵ� ����
        Rigidbody2D plrRigidbody=gameObject.GetComponent<Rigidbody2D>();
        //�����ν�->����
        if(opponent.transform.GetChild(0).gameObject.activeSelf==true&&jumpCount==false)      //���� �������̶��
        {
            plrRigidbody.velocity=Vector2.up*jumppower;
            jumpCount=true;
        }

        //�ٴ��ν�->����
        //������ ����. �ϴܿ� ����
        Debug.DrawRay(plrRigidbody.position, Vector3.down, new Color(0,1,0));
        RaycastHit2D downRay=Physics2D.Raycast(plrRigidbody.position, Vector3.down, 1, LayerMask.GetMask("platform"));
        ////���� ����
        //�������� �̿��� ���� �� ����
        //��ü�� y���� 0������ ��,
        if(plrRigidbody.velocity.y<0)
        {
            //�������� ��ü�ν��� ������ �ƴϰ�, �������� ���̰� 0.5 ���ϰ� ���� ��
            if(downRay.collider != null && downRay.distance<0.5f)
                jumpCount=false;
        }

        //�Ÿ����� ���� ���� ����
        if(gameObject.transform.position.x-opponent.transform.position.x>=0)
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX=false;

        //ĳ���� �̵�
        float h=gameObject.GetComponent<SpriteRenderer>().flipX==true?-1f:1f;
        plrRigidbody.AddForce(new Vector2(movespeed*h,0), ForceMode2D.Impulse);
        
        //�ִ� �̼� ����
         if(plrRigidbody.velocity.x>speedLimit)
            plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
        else if(plrRigidbody.velocity.x<-speedLimit)
            plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);
        
        //�ٰŸ� ����ó��
        if(Math.Abs(gameObject.transform.position.x-opponent.transform.position.x)<=0.3 && anim.GetInteger("AtkStat")==0)    //���� ���������� ��
        {
            Debug.Log("AI����ó��");
            anim.SetInteger("AtkStat", 1);
        }
        else
        {
            anim.SetInteger("AtkStat", 0);
        }
        */
    }

    void StopAnim()
    {
        anim.SetInteger("AtkStat", 0);
        anim.SetBool("Run", false);
    }
}
