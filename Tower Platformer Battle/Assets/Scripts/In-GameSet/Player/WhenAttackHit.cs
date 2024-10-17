using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WhenAttackHit : MonoBehaviour
{
    //�� �ݶ��̴��� ��Ʈ�� �νĵǴ°� ����
    //�ݶ��̴��� ���� ������, ����� �˻�
    //����� �̸��� 'Player' �� ���ٸ� �ڵ� ����
    //����� ��ǥ���� ���� ��,�ش� ��ġ�� HitEff ������Ʈ ����

    public GameObject hitEff;          //Ÿ�� ����Ʈ

    //�����ð� ����
    public float xknockb=-5f;
    public float yknockb=5f;
    public float hity=5f;

    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("Ÿ��Ȯ��");
        //Ÿ�� �������� �̸� Ž��
        string target=hit.gameObject.name;
        string search="Player";
        if(target.Contains(search) && target!=gameObject.transform.parent.gameObject.name)
        {
            //���� ó��
            Debug.Log("�÷��̾��Է�ó�� �Ϸ�");
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

            //���� ó��
            PlayerData plrData=gameObject.transform.parent.gameObject.GetComponent<PlayerData>();
            plrData.MP++;

            //Ÿ�� ó��
            hit.gameObject.GetComponent<PlayerData>().HP--;
            Vector3 hitPos=hit.transform.position;
            GameObject clone=Instantiate(hitEff);
            //float dir=clone.transform.parent.gameObject.GetComponent<SpriteRenderer>().flipX==false?1:-1;
            clone.transform.position=new Vector3(hitPos.x, hitPos.y+hity, hitPos.z);
            clone.gameObject.SetActive(true);
        }
    }
}
