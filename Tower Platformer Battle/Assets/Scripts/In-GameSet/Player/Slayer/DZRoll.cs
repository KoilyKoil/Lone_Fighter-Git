using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZRoll : MonoBehaviour
{
    void DoABarrelRoll()
    {
        //게임오브젝트의 중력 및 판정 임시 제거
        gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale=0;

        //플레이어의 방향을 따내서 해당 방향으로 이동
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
        //게임오브젝트의 중력 및 판정 복구
        gameObject.GetComponent<CapsuleCollider2D>().enabled=true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale=3;
        gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
    }
}
