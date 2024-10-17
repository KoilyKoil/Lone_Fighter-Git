using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //ü�� ����
    public int HP = 10;
    public int MP = 10;
    public RectTransform HPBar;
    public RectTransform MPBar;

    //���ӿ���
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
            Debug.Log("��Ʈ üũ");
            
        }
    }
*/
    
    //�ڷ�ƾ ����� ���� �������̽� ����
    IEnumerator WaitForGameEnd()
    {
        yield return new WaitForSeconds(1.0f); //���� ����.
        //�Լ� ����
        UISet.SetActive(false);
        InGameSet.SetActive(false);
        BGSet.SetActive(false);
        EndSet.SetActive(true);
        Debug.Log("���ӿ���");
    }

    void Update()
    {
        HPBar.sizeDelta=new Vector2(HP*50, 50);
        MPBar.sizeDelta=new Vector2(MP*50, 50);         //ü�¹� �ʱ�ȭ ó��
        if(HP<=0)       //ü�� 0 ó��
        {
            Time.timeScale=0.5f;        //���ο���

            //�̵�ó�� ��Ȱ��ȭ
            if(gameObject.name=="Player1 Set")
            {
                gameObject.GetComponent<PlayerMovement>().enabled=false;
            }else{
                gameObject.GetComponent<AISet>().enabled=false;
            }

            //����ó�� ��Ȱ��ȭ
            gameObject.GetComponent<CapsuleCollider2D>().enabled=false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale=0;
            gameObject.GetComponent<Rigidbody2D>().velocity=Vector3.zero;
            //������ ȣ��
            gameObject.GetComponent<Animator>().SetBool("Dead", true);

            StartCoroutine(WaitForGameEnd());
        }
    }
}
