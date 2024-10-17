using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayGame : MonoBehaviour
{
    public GameObject gameoverUI;
    public GameObject ingameUI;
    public GameObject UISet;
    public GameObject BGSet;

    GameObject p1Data;
    GameObject p2Data;

    public void Replay()
    {
        //������ ���ӿ��� ó�� ����
        Time.timeScale=1f;

        //���ҽ� �ε�
        ingameUI.SetActive(true);
        UISet.SetActive(true);
        BGSet.SetActive(true);
        
        //�÷��̾� ������Ʈ ����
        p1Data=GameObject.Find("Player1 Set");
        p2Data=GameObject.Find("Player2 Set");
        
        //���ӿ��� UI ����
        gameoverUI.SetActive(false);

        //ĳ���� ü�� �ʱ�ȭ
        p1Data.GetComponent<PlayerData>().HP=10;
        p1Data.GetComponent<PlayerData>().MP=0;
        p2Data.GetComponent<PlayerData>().HP=10;
        p2Data.GetComponent<PlayerData>().MP=0;

        //���� �ʱ�ȭ
        if(ingameUI.transform.GetChild(0).childCount>=2)
        {
            GameObject.Destroy(ingameUI.transform.GetChild(0).GetChild(1).gameObject);
        }
        if(ingameUI.transform.GetChild(1).childCount>=2)
        {
            GameObject.Destroy(ingameUI.transform.GetChild(1).GetChild(1).gameObject);
        }

        //�ִϸ��̼� �ʱ�ȭ
        p1Data.GetComponent<Animator>().SetInteger("AtkStat", 0);
        p2Data.GetComponent<Animator>().SetInteger("AtkStat", 0);
        p1Data.GetComponent<Animator>().SetBool("Dead", false);
        p2Data.GetComponent<Animator>().SetBool("Dead", false);

        //�̵�ó�� �ʱ�ȭ
        p1Data.GetComponent<PlayerMovement>().enabled=true;
        p2Data.GetComponent<AISet>().enabled=true;

        //�����ʱ�ȭ
        p1Data.GetComponent<CapsuleCollider2D>().enabled=true;
        p2Data.GetComponent<CapsuleCollider2D>().enabled=true;
        p1Data.GetComponent<Rigidbody2D>().gravityScale=3;
        p2Data.GetComponent<Rigidbody2D>().gravityScale=3;
    
        //��ġ �ʱ�ȭ
        ingameUI.transform.GetChild(0).localPosition=new Vector3(0.032f, -0.169f, -0.1f);
        ingameUI.transform.GetChild(1).localPosition=new Vector3(1.068f, -0.186f, -0.1f);
    }
}
