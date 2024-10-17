using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISet : MonoBehaviour
{
    public GameObject opponent;                 //적 오브제. 여기선 P1으로 설정
    //bool jumpCount=false;                       //점프상태 구분
    public float jumppower=5f;
    public float movespeed=0.3f;
    public float speedLimit=1.2f;
    public float dirDiffer=0.6f;
    Animator anim;
    Rigidbody2D plrRigidbody;
    //AI상태 구분. 0==수색, 1==인지
    int AIStat=0;

    void Awake()
    {
        //애니메이션 컴포넌트 따옴
        anim=GetComponent<Animator>();
        //본체 리짓바디 설정
        plrRigidbody=gameObject.GetComponent<Rigidbody2D>();
        anim.SetBool("Run", true);
    }


    void FixedUpdate()
    {
        /*
        AI 구현 계획
        - 플레이어가 가능한 행동
        - - 이동, 점프, 공격

        - AI가 하고자 하는 행동
        - - 플레이어를 수색-> 반경 내에 들어오면 공격
        - - 적이 공격하면 도주 -> 도주한 뒤 수색 재개

        - AI 구현 계획
        - - 1대1의 경우, 플레이어가 있는 방향으로 이동 진행.
        - - 만약 플레이어가 반경내에 들어오게 되면 해당 플레이어를 집중 추격
        - - 플레이어가 바로 앞에 있으면 일반공격 또는 필살기
        - - 플레이어가 아래에 있으면 공중공격
        - - 플레이어가 위에 있으면 아래공격
        - - 플레이어와 조금 거리가 되면 전방공격

        - - 플레이어가 공격하면 거리두기 또는 점프

        or

        이동 및 접근까지는 괜찮은데, 공격을 랜덤으로 처리?
        */

        //상태 0, 수색
        if(AIStat==0)
        {
            anim.SetBool("Run", true);
            //거리차에 따른 방향 설정
            if(gameObject.transform.position.x-opponent.transform.position.x>=0)
                gameObject.GetComponent<SpriteRenderer>().flipX=true;
            else
                gameObject.GetComponent<SpriteRenderer>().flipX=false;

            //캐릭터 이동
            float h=gameObject.GetComponent<SpriteRenderer>().flipX==true?-1f:1f;
            plrRigidbody.AddForce(new Vector2(movespeed*h,0), ForceMode2D.Impulse);

            //최대 이속 제한
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

        //AI 상태 결정
        if(Math.Abs(gameObject.transform.position.x-opponent.transform.position.x)<=dirDiffer)
        {
            AIStat=1;
        }
        else
        {
            AIStat=0;
        }
        
        /*
        //본체 리짓바디 설정
        Rigidbody2D plrRigidbody=gameObject.GetComponent<Rigidbody2D>();
        //공격인식->점프
        if(opponent.transform.GetChild(0).gameObject.activeSelf==true&&jumpCount==false)      //적이 공격중이라면
        {
            plrRigidbody.velocity=Vector2.up*jumppower;
            jumpCount=true;
        }

        //바닥인식->착지
        //레이저 생성. 하단에 생성
        Debug.DrawRay(plrRigidbody.position, Vector3.down, new Color(0,1,0));
        RaycastHit2D downRay=Physics2D.Raycast(plrRigidbody.position, Vector3.down, 1, LayerMask.GetMask("platform"));
        ////점프 구현
        //레이저를 이용해 벽과 땅 구분
        //몸체의 y값이 0이하일 때,
        if(plrRigidbody.velocity.y<0)
        {
            //레이저의 물체인식이 거짓이 아니고, 레이저의 길이가 0.5 이하가 됐을 때
            if(downRay.collider != null && downRay.distance<0.5f)
                jumpCount=false;
        }

        //거리차에 따른 방향 설정
        if(gameObject.transform.position.x-opponent.transform.position.x>=0)
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX=false;

        //캐릭터 이동
        float h=gameObject.GetComponent<SpriteRenderer>().flipX==true?-1f:1f;
        plrRigidbody.AddForce(new Vector2(movespeed*h,0), ForceMode2D.Impulse);
        
        //최대 이속 제한
         if(plrRigidbody.velocity.x>speedLimit)
            plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
        else if(plrRigidbody.velocity.x<-speedLimit)
            plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);
        
        //근거리 공격처리
        if(Math.Abs(gameObject.transform.position.x-opponent.transform.position.x)<=0.3 && anim.GetInteger("AtkStat")==0)    //적이 근접해있을 때
        {
            Debug.Log("AI공격처리");
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
