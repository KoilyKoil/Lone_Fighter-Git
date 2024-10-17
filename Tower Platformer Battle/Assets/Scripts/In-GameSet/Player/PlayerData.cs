using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //체력 스탯
    public int HP = 10;
    public int MP = 10;
    public RectTransform HPBar;
    public RectTransform MPBar;

    //게임오버
    public GameObject UISet;
    public GameObject InGameSet;
    public GameObject BGSet;
    public GameObject EndSet;

/*
    private void OnCollisionEnter2D(Collision2D hitCol)
    {   
        if(hitCol.transform.childCount!=0 && hitCol.transform.GetChild(0).gameObject.CompareTag("Attack") && hitCol.transform.GetChild(0).gameObject.activeSelf==true)
        {
            HP--;
            Debug.Log("히트 체크");
            
        }
    }
*/
    
    //코루틴 사용을 위한 인터페이스 선언
    IEnumerator WaitForGameEnd()
    {
        yield return new WaitForSeconds(1.0f); //조건 설정.
        //함수 내용
        UISet.SetActive(false);
        InGameSet.SetActive(false);
        BGSet.SetActive(false);
        EndSet.SetActive(true);
        Debug.Log("게임오버");
    }

    void Update()
    {
        HPBar.sizeDelta=new Vector2(HP*50, 50);
        MPBar.sizeDelta=new Vector2(MP*50, 50);         //체력바 초기화 처리
        if(HP<=0)       //체력 0 처리
        {
            Time.timeScale=0.5f;        //슬로우모션

            //이동처리 비활성화
            if(gameObject.name=="Player1 Set")
            {
                gameObject.GetComponent<PlayerMovement>().enabled=false;
            }else{
                gameObject.GetComponent<AISet>().enabled=false;
            }

            //판정처리 비활성화
            gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale=0;
            gameObject.GetComponent<Rigidbody2D>().velocity=Vector3.zero;
            //사망모션 호출
            gameObject.GetComponent<Animator>().SetBool("Dead", true);

            StartCoroutine(WaitForGameEnd());
        }
    }
}
