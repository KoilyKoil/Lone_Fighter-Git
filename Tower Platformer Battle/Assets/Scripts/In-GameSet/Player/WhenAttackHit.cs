using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WhenAttackHit : MonoBehaviour
{
    //이 콜라이더에 히트가 인식되는걸 감지
    //콜라이더에 무언가 들어오면, 대상을 검사
    //대상의 이름에 'Player' 가 들어간다면 코드 진행
    //대상의 좌표점을 따낸 뒤,해당 위치에 HitEff 오브젝트 복제

    public GameObject hitEff;          //타격 이펙트

    //경직시간 설정
    public float xknockb=-5f;
    public float yknockb=5f;
    public float hity=5f;

    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("타격확인");
        //타격 오브제의 이름 탐색
        string target=hit.gameObject.name;
        string search="Player";
        if(target.Contains(search) && target!=gameObject.transform.parent.gameObject.name)
        {
            //경직 처리
            Debug.Log("플레이어입력처리 완료");
            Debug.Log(target);
            hit.gameObject.GetComponent<Animator>().SetInteger("AtkStat", 0);
            hit.gameObject.GetComponent<Animator>().SetBool("Run", false);
            hit.gameObject.GetComponent<Animator>().SetBool("InAir", false);
            hit.gameObject.GetComponent<Animation>().Stop();
            hit.gameObject.GetComponent<Animator>().SetTrigger("Hit");
            hit.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*yknockb, ForceMode2D.Impulse);
            hit.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*xknockb, ForceMode2D.Impulse);
            if(target=="Player1 Set")
                hit.gameObject.GetComponent<PlayerMovement>().enabled=false;
            else
                hit.gameObject.GetComponent<AISet>().enabled=false;

            //마나 처리
            PlayerData plrData=gameObject.transform.parent.gameObject.GetComponent<PlayerData>();
            plrData.MP++;

            //타격 처리
            hit.gameObject.GetComponent<PlayerData>().HP--;
            Vector3 hitPos=hit.transform.position;
            GameObject clone=Instantiate(hitEff);
            //float dir=clone.transform.parent.gameObject.GetComponent<SpriteRenderer>().flipX==false?1:-1;
            clone.transform.position=new Vector3(hitPos.x, hitPos.y+hity, hitPos.z);
            clone.gameObject.SetActive(true);
        }
    }
}
