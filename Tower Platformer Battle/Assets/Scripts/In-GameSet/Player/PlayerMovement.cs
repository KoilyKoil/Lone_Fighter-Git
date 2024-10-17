using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //변수 선언
    float h;
    ////이동
    public Rigidbody2D plrRigidbody;              //플레이어의 리짓바디 컴포넌트를 가져옴
    public Vector2 plrSpeed=new Vector2(1.2f, 0f);                       //플레이어의 이동속도를 결정
    public float speedLimit=1.5f;                   //최대 이동속도
    ////점프
    public int jumpCount=0;
    public int maxJumpCount=1;
    public float jumpPower=6f;
    ////애니메이션 처리
    SpriteRenderer sprRnder;
    Animator anim;
    Vector3 dirVec;     //방향 좌표

    //사운드 처리
    //public AudioSource jumpsnd, groundsnd;

    //히트박스 처리
    //public GameObject hitbox;

    //데이터 처리
    public PlayerData plrData;

    //연속 입력 방지
    bool AttackKeyDown=false;

    void Awake()
    {
        sprRnder=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        //jumpsnd=jumpsnd.GetComponent<AudioSource>();
        //groundsnd=groundsnd.GetComponent<AudioSource>();
    }

    void Update()
    {
        ////점프 구현
        if(Input.GetKeyDown(KeyCode.X) && jumpCount>0)       //스페이스바 눌림이 확인됐고, 점프 가능한 횟수일 때,
        {
            anim.SetBool("Run", false);
            anim.SetBool("InAir", true);
            //jumpsnd.Play();
            plrRigidbody.velocity=Vector2.up*jumpPower;
            jumpCount--;
        }
        
        ////공격 구현
        if(Input.GetKey(KeyCode.Z) && AttackKeyDown==false)
        {
            AttackKeyDown=true;
            //공격 커맨드 구분
            if(anim.GetBool("InAir")==true)
            {
                Debug.Log("공중공격");
                anim.SetBool("InAir", false);
                anim.SetBool("Run", false);
                anim.SetInteger("AtkStat", 3);
                //anim.Play("Char1JA");
                //plrData.MP++;
                if(plrData.MP>=10) plrData.MP=10;
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("Run", false);
                anim.SetInteger("AtkStat", 4);
                //plrData.MP++;
                Debug.Log("하단 공격");
            }
            else if(Input.GetButton("Horizontal"))
            {
                anim.SetBool("Run", false);
                Debug.Log("전방공격");
                anim.SetInteger("AtkStat", 2);
                //anim.Play("Char1FA");
                //plrData.MP++;
                if(plrData.MP>=10) plrData.MP=10;
            }
            else if(Input.GetKey(KeyCode.X) && gameObject.GetComponent<PlayerData>().MP>=5)
            {
                anim.SetInteger("AtkStat", 5);
                gameObject.GetComponent<PlayerData>().MP=gameObject.GetComponent<PlayerData>().MP-5;
                gameObject.AddComponent<XZCounter>();
                Debug.Log("필살 진행");
            }
            else
            {
                Debug.Log("공격 진행");
                anim.SetInteger("AtkStat", 1);
                //anim.Play("Char1A");
                //plrData.MP++;
                if(plrData.MP>=10) plrData.MP=10;
            }
        }

    }

    GameObject scanObject;

    void FixedUpdate()
    {
        if(anim.GetInteger("AtkStat")==0)
        {
            AttackKeyDown=false;
        }
        if(AttackKeyDown==false)
        {
            ////이동구현
            //좌우 이동
            h=Input.GetAxisRaw("Horizontal");     //수평방향 방향키 입력을 받아냄. 우측이 1, 좌측이 -1, 중립이 0
            plrRigidbody.AddForce(plrSpeed*h, ForceMode2D.Impulse);        //기존 속도에서 h로 속도만 조정

            ////방향전환
            //플립
            if(Input.GetButton("Horizontal"))       //수평방향 버튼 입력이 이루어지면
                sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //오른쪽 보면 1, 아니면 0 반환 및 반환값을 이용한 플립여부 처리
            //바라보는 방향
            h=Input.GetAxisRaw("Horizontal");     //수평방향 방향키 입력을 받아냄. 우측이 1, 좌측이 -1, 중립이 0
            if(h==-1)
            {
                anim.SetBool("Run", true);
                dirVec=Vector3.left;
            }
            else if(h==1)
            {
                anim.SetBool("Run", true);
                dirVec=Vector3.right;
            }
            else if(h==0)
            {
                anim.SetBool("Run", false);
            }

            //최대 스피드를 넘지 못하게 함
            if(plrRigidbody.velocity.x>speedLimit)
                plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
            else if(plrRigidbody.velocity.x<-speedLimit)
                plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);
        }

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
            {
                anim.SetBool("InAir", false);
                jumpCount=2;
            }
        }

        //마나 처리
        //if(Input.GetKey(KeyCode.Z)) plrData.MP++;
    }
/*
    //애니메이션 종료 처리
    public void StopAttackAnim()
    {
        plrData.MP++;
        if(plrData.MP>=10) plrData.MP=10;
        
    }
    */
}
