using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZCounter : MonoBehaviour
{
   /*
      �ݰݱ� ������ȹ

0. ������Ʈ Ȱ��ȭ
1. �浹 �Է��� ����
2. ���� �浹���� �θ�� ������ �θ� �ٸ���, �浹���� �θ� �÷��̾��� ��� Ȱ��ȭ
3. ���� �ִϸ��̼�1 ȣ��->���->���� �ִϸ��̼�2 ȣ��->���->���� �ִϸ��̼�3 ȣ��
4. ������Ʈ ��Ȱ��ȭ

������Ʈ Ȱ��ȭ��ȹ
���� : ���� 5 �̻󿡼� ������ ���ݹ�ư�� ���ÿ� Ŭ��
0. ���ÿ��� ������Ʈ ��Ȱ��ȭ���� ����
1. �Է� ��ũ��Ʈ���� ������Ʈ�� ������ �� Ȱ��ȭ���·� �ٲ�
      */

   Animator anim;

   void Awake()
   {
      anim=GetComponent<Animator>();
   }

   void OnCollisionEnter2D(Collision2D hit)
   {
      //�浹�� Ž�� (�����ڰ� ���� ��쿡 Ȱ��ȭ)
      if(hit.gameObject.name!=gameObject.name && hit.gameObject.name.Contains("Player"))
      {
         Debug.Log("�ݰ� �Է� Ȯ��");
         //�����̸� �ְ� ���� �ִϸ��̼� ȣ��
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
