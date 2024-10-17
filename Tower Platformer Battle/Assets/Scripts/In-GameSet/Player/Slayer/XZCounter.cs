using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZCounter : MonoBehaviour
{
   /*
      반격기 구현계획

0. 컴포넌트 활성화
1. 충돌 입력이 들어옴
2. 만약 충돌자의 부모와 본인의 부모가 다르고, 충돌자의 부모가 플레이어인 경우 활성화
3. 공격 애니메이션1 호출->대기->공격 애니메이션2 호출->대기->공격 애니메이션3 호출
4. 컴포넌트 비활성화

컴포넌트 활성화계획
조건 : 마나 5 이상에서 점프와 공격버튼을 동시에 클릭
0. 평상시에는 컴포넌트 비활성화상태 유지
1. 입력 스크립트에서 컴포넌트를 가져온 뒤 활성화상태로 바꿈
      */

   Animator anim;

   void Awake()
   {
      anim=GetComponent<Animator>();
   }

   void OnCollisionEnter2D(Collision2D hit)
   {
      //충돌자 탐색 (공격자가 적인 경우에 활성화)
      if(hit.gameObject.name!=gameObject.name && hit.gameObject.name.Contains("Player"))
      {
         Debug.Log("반격 입력 확인");
         //딜레이를 주고 공격 애니메이션 호출
         anim.Play("Attack1");

         Invoke("Atk2",0.5f);
         Invoke("Atk3",0.5f);
         Invoke("Stp", 0.5f);
      }
   }

   void Atk2()
   {
      anim.Play("Attack2");
   }

   void Atk3()
   {
      anim.Play("Attack3");
   }

   void Stp()
   {
      Destroy(gameObject.GetComponent<XZCounter>());
   }
}
