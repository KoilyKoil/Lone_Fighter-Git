using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZRoll : MonoBehaviour
{
    void DoABarrelRoll()
    {
        //���ӿ�����Ʈ�� �߷� �� ���� �ӽ� ����
        gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale=0;

        //�÷��̾��� ������ ������ �ش� �������� �̵�
        bool dir=gameObject.GetComponent<SpriteRenderer>().flipX;
        if(dir==false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*1.8f, ForceMode2D.Impulse);
        }else{
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*(-1.8f), ForceMode2D.Impulse);
        }
        
    }

    void StopABarrelRoll()
    {
        //���ӿ�����Ʈ�� �߷� �� ���� ����
        gameObject.GetComponent<CapsuleCollider2D>().enabled=true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale=3;
        gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
    }
}
