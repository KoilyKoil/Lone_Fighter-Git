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
        //이전의 게임오버 처리 해제
        Time.timeScale=1f;

        //리소스 로딩
        ingameUI.SetActive(true);
        UISet.SetActive(true);
        BGSet.SetActive(true);
        
        //플레이어 오브젝트 설정
        p1Data=GameObject.Find("Player1 Set");
        p2Data=GameObject.Find("Player2 Set");
        
        //게임오버 UI 해제
        gameoverUI.SetActive(false);

        //캐릭터 체력 초기화
        p1Data.GetComponent<PlayerData>().HP=10;
        p1Data.GetComponent<PlayerData>().MP=0;
        p2Data.GetComponent<PlayerData>().HP=10;
        p2Data.GetComponent<PlayerData>().MP=0;

        //판정 초기화
        if(ingameUI.transform.GetChild(0).childCount>=2)
        {
            GameObject.Destroy(ingameUI.transform.GetChild(0).GetChild(1).gameObject);
        }
        if(ingameUI.transform.GetChild(1).childCount>=2)
        {
            GameObject.Destroy(ingameUI.transform.GetChild(1).GetChild(1).gameObject);
        }

        //애니메이션 초기화
        p1Data.GetComponent<Animator>().SetInteger("AtkStat", 0);
        p2Data.GetComponent<Animator>().SetInteger("AtkStat", 0);
        p1Data.GetComponent<Animator>().SetBool("Dead", false);
        p2Data.GetComponent<Animator>().SetBool("Dead", false);

        //이동처리 초기화
        p1Data.GetComponent<PlayerMovement>().enabled=true;
        p2Data.GetComponent<AISet>().enabled=true;

        //판정초기화
        p1Data.GetComponent<CapsuleCollider2D>().enabled=true;
        p2Data.GetComponent<CapsuleCollider2D>().enabled=true;
        p1Data.GetComponent<Rigidbody2D>().gravityScale=3;
        p2Data.GetComponent<Rigidbody2D>().gravityScale=3;
    
        //위치 초기화
        ingameUI.transform.GetChild(0).localPosition=new Vector3(0.032f, -0.169f, -0.1f);
        ingameUI.transform.GetChild(1).localPosition=new Vector3(1.068f, -0.186f, -0.1f);
    }
}
