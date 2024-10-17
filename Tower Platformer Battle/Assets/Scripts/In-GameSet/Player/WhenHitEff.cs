using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHitEff : MonoBehaviour
{
    //스크립트 활성화시 진행
    void Awake()
    {
        //이펙트 재생은 알아서 될 것
        //이펙트 활성화시 애니메이션 종료할 때까지 게임 일시정지
        //이펙트 재생 종료가 확인되면 재생 종료 및 게임 활성화
        Time.timeScale=0.5f;        //시간을 0으로 설정
    }

    public void EndHitEffect()
    {
        Time.timeScale=1;
        Destroy(gameObject);
    }
}
