using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMoving : MonoBehaviour
{
    public GameObject ingre;
    
    //뒷배경 이동 선언
    Vector3 limitation;         //임계점 설정
    GameObject[] bgObj=new GameObject[2];   //복제된 변수 설정
    public int bgSpeed=1, depth=10;


    //준비
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

    //연산
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
