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
        anim=gameObject.GetComponent<Animator>();               //애니메이션 컴포넌트 따옴
        hbObj=hbObj.transform.Find("Hitbox").gameObject;        //타격판정 컴포넌트 따옴
    }

    
    public void StopAttackAnim()
    {
        //판정 제거
        try
        {
            GameObject.Destroy(gameObject.transform.GetChild(2).gameObject);
        }
        catch(Exception e)
        {
            Debug.Log("비판정 스킬 진행");
            Debug.Log(e);
        }
        //애니메이션 정상화
        anim.SetInteger("AtkStat", 0);
        anim.Play("Idle");
    }

    //공격방향 처리
    public void SetHitboxDir(string parameter)
    {
        //매개변수 분리 및 설정
        string[] paramList=parameter.Split(',');
        float posX=float.Parse(paramList[0]);
        float posY=float.Parse(paramList[1]);
        float sizeX=float.Parse(paramList[2]);
        float sizeY=float.Parse(paramList[3]);
        bool chrDir=gameObject.GetComponent<SpriteRenderer>().flipX;         //플레이어 방향 가져옴

        if(chrDir==true)
        {
            //히트박스 가져옴
            hbObj.SetActive(true);
            GameObject clone=Instantiate(hbObj, new Vector3(0.5f*(-1), 0f, 0f), Quaternion.identity);
            hbObj.SetActive(false);
            //좌표 및 크기 지정
            clone.transform.SetParent(gameObject.transform);
            clone.transform.localPosition=new Vector3(0f, 0f, 0f);
            clone.GetComponent<BoxCollider2D>().size=new Vector2(sizeX, sizeY);
            clone.GetComponent<BoxCollider2D>().offset=new Vector2(posX*(-1), posY);
        }
        else if(chrDir==false)
        {
            //히트박스 가져옴
            hbObj.SetActive(true);
            GameObject clone=Instantiate(hbObj, new Vector3(0.5f, 0f, 0f), Quaternion.identity);
            hbObj.SetActive(false);
            //좌표 및 크기 지정
            clone.transform.SetParent(gameObject.transform);
            clone.transform.localPosition=new Vector3(0f, 0f, 0f);
            clone.GetComponent<BoxCollider2D>().size=new Vector2(sizeX, sizeY);
            clone.GetComponent<BoxCollider2D>().offset=new Vector2(posX, posY);
        }
    }

    public void GetHitBack()
    {
        //판정 제거
        try
        {
            GameObject.Destroy(gameObject.transform.GetChild(2).gameObject);
        }
        catch(Exception e)
        {
            Debug.Log("비판정 스킬 진행");
            Debug.Log(e);
        }
        if(gameObject.name=="Player1 Set")
            gameObject.GetComponent<PlayerMovement>().enabled=true;
        else
            gameObject.GetComponent<AISet>().enabled=true;
    }
}
