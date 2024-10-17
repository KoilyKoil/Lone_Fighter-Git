using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LockAnim : MonoBehaviour
{
    Animator anim;
    public GameObject hbObj;

    void Start()
    {
        anim=gameObject.GetComponent<Animator>();               //�ִϸ��̼� ������Ʈ ����
        hbObj=hbObj.transform.Find("Hitbox").gameObject;        //Ÿ������ ������Ʈ ����
    }

    
    public void StopAttackAnim()
    {
        //���� ����
        try
        {
            GameObject.Destroy(gameObject.transform.GetChild(2).gameObject);
        }
        catch(Exception e)
        {
            Debug.Log("������ ��ų ����");
            Debug.Log(e);
        }
        //�ִϸ��̼� ����ȭ
        anim.SetInteger("AtkStat", 0);
        anim.Play("Idle");
    }

    //���ݹ��� ó��
    public void SetHitboxDir(string parameter)
    {
        //�Ű����� �и� �� ����
        string[] paramList=parameter.Split(',');
        float posX=float.Parse(paramList[0]);
        float posY=float.Parse(paramList[1]);
        float sizeX=float.Parse(paramList[2]);
        float sizeY=float.Parse(paramList[3]);
        bool chrDir=gameObject.GetComponent<SpriteRenderer>().flipX;         //�÷��̾� ���� ������

        if(chrDir==true)
        {
            //��Ʈ�ڽ� ������
            hbObj.SetActive(true);
            GameObject clone=Instantiate(hbObj, new Vector3(0.5f*(-1), 0f, 0f), Quaternion.identity);
            hbObj.SetActive(false);
            //��ǥ �� ũ�� ����
            clone.transform.SetParent(gameObject.transform);
            clone.transform.localPosition=new Vector3(0f, 0f, 0f);
            clone.GetComponent<BoxCollider2D>().size=new Vector2(sizeX, sizeY);
            clone.GetComponent<BoxCollider2D>().offset=new Vector2(posX*(-1), posY);
        }
        else if(chrDir==false)
        {
            //��Ʈ�ڽ� ������
            hbObj.SetActive(true);
            GameObject clone=Instantiate(hbObj, new Vector3(0.5f, 0f, 0f), Quaternion.identity);
            hbObj.SetActive(false);
            //��ǥ �� ũ�� ����
            clone.transform.SetParent(gameObject.transform);
            clone.transform.localPosition=new Vector3(0f, 0f, 0f);
            clone.GetComponent<BoxCollider2D>().size=new Vector2(sizeX, sizeY);
            clone.GetComponent<BoxCollider2D>().offset=new Vector2(posX, posY);
        }
    }

    public void GetHitBack()
    {
        //���� ����
        try
        {
            GameObject.Destroy(gameObject.transform.GetChild(2).gameObject);
        }
        catch(Exception e)
        {
            Debug.Log("������ ��ų ����");
            Debug.Log(e);
        }
        if(gameObject.name=="Player1 Set")
            gameObject.GetComponent<PlayerMovement>().enabled=true;
        else
            gameObject.GetComponent<AISet>().enabled=true;
    }
}
