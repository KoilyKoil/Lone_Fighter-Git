using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //���� ����
    float h;
    ////�̵�
    public Rigidbody2D plrRigidbody;              //�÷��̾��� �����ٵ� ������Ʈ�� ������
    public Vector2 plrSpeed=new Vector2(1.2f, 0f);                       //�÷��̾��� �̵��ӵ��� ����
    public float speedLimit=1.5f;                   //�ִ� �̵��ӵ�
    ////����
    public int jumpCount=0;
    public int maxJumpCount=1;
    public float jumpPower=6f;
    ////�ִϸ��̼� ó��
    SpriteRenderer sprRnder;
    Animator anim;
    Vector3 dirVec;     //���� ��ǥ

    //���� ó��
    //public AudioSource jumpsnd, groundsnd;

    //��Ʈ�ڽ� ó��
    //public GameObject hitbox;

    //������ ó��
    public PlayerData plrData;

    //���� �Է� ����
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
        ////���� ����
        if(Input.GetKeyDown(KeyCode.X) && jumpCount>0)       //�����̽��� ������ Ȯ�εư�, ���� ������ Ƚ���� ��,
        {
            anim.SetBool("Run", false);
            anim.SetBool("InAir", true);
            //jumpsnd.Play();
            plrRigidbody.velocity=Vector2.up*jumpPower;
            jumpCount--;
        }
        
        ////���� ����
        if(Input.GetKey(KeyCode.Z) && AttackKeyDown==false)
        {
            AttackKeyDown=true;
            //���� Ŀ�ǵ� ����
            if(anim.GetBool("InAir")==true)
            {
                Debug.Log("���߰���");
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
                Debug.Log("�ϴ� ����");
            }
            else if(Input.GetButton("Horizontal"))
            {
                anim.SetBool("Run", false);
                Debug.Log("�������");
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
                Debug.Log("�ʻ� ����");
            }
            else
            {
                Debug.Log("���� ����");
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
            ////�̵�����
            //�¿� �̵�
            h=Input.GetAxisRaw("Horizontal");     //������� ����Ű �Է��� �޾Ƴ�. ������ 1, ������ -1, �߸��� 0
            plrRigidbody.AddForce(plrSpeed*h, ForceMode2D.Impulse);        //���� �ӵ����� h�� �ӵ��� ����

            ////������ȯ
            //�ø�
            if(Input.GetButton("Horizontal"))       //������� ��ư �Է��� �̷������
                sprRnder.flipX=Input.GetAxisRaw("Horizontal")==-1;       //������ ���� 1, �ƴϸ� 0 ��ȯ �� ��ȯ���� �̿��� �ø����� ó��
            //�ٶ󺸴� ����
            h=Input.GetAxisRaw("Horizontal");     //������� ����Ű �Է��� �޾Ƴ�. ������ 1, ������ -1, �߸��� 0
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

            //�ִ� ���ǵ带 ���� ���ϰ� ��
            if(plrRigidbody.velocity.x>speedLimit)
                plrRigidbody.velocity=new Vector2(speedLimit, plrRigidbody.velocity.y);
            else if(plrRigidbody.velocity.x<-speedLimit)
                plrRigidbody.velocity=new Vector2(-speedLimit, plrRigidbody.velocity.y);
        }

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
            {
                anim.SetBool("InAir", false);
                jumpCount=2;
            }
        }

        //���� ó��
        //if(Input.GetKey(KeyCode.Z)) plrData.MP++;
    }
/*
    //�ִϸ��̼� ���� ó��
    public void StopAttackAnim()
    {
        plrData.MP++;
        if(plrData.MP>=10) plrData.MP=10;
        
    }
    */
}
