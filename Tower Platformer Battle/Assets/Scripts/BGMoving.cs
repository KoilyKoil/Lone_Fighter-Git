using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMoving : MonoBehaviour
{
    public GameObject ingre;
    
    //�޹�� �̵� ����
    Vector3 limitation;         //�Ӱ��� ����
    GameObject[] bgObj=new GameObject[2];   //������ ���� ����
    public int bgSpeed=1, depth=10;


    //�غ�
    void Start()
    {
        int setPos=1280;
        for(int i=0;i<2;i++)
        {
            bgObj[i]=Instantiate(ingre, ingre.transform.localPosition, ingre.transform.localRotation);
            bgObj[i].transform.SetParent(gameObject.transform);
            bgObj[i].GetComponent<Image>().sprite=ingre.GetComponent<Image>().sprite;
            bgObj[i].transform.localPosition=new Vector3(ingre.transform.localPosition.x, ingre.transform.localPosition.y+setPos, depth);
            bgObj[i].transform.localScale=new Vector3(1f,1f,1f);
            setPos-=1280;
        }
        limitation=bgObj[0].transform.localPosition;
        ingre.SetActive(false);
    }

    //����
    void Update()
    {
        foreach(GameObject i in bgObj)
        {
            if(i.transform.localPosition.x>=2280)
            {
                i.transform.localPosition=new Vector3(i.transform.localPosition.x, -1280, depth);
            }
        }
        foreach(GameObject i in bgObj)
        {
            i.transform.localPosition=new Vector3(i.transform.localPosition.x, i.transform.localPosition.y+bgSpeed, depth);
        }
    }
}
