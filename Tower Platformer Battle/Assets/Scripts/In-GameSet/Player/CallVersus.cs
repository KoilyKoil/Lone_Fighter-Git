using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallVersus : MonoBehaviour
{
    public GameObject[] forGame;        //로딩 완료시 활성화할 오브젝트

    //처음 이름 로딩을 받았을 때 처리
    public void GetBeginData(string p1, string p2)
    {
        //필요한 오브젝트들을 따옴
        Transform UIParent=gameObject.transform.GetChild(0);
        GameObject P1Image=UIParent.GetChild(1).gameObject;
        GameObject P1Name=UIParent.GetChild(2).gameObject;
        GameObject P2Image=UIParent.GetChild(3).gameObject;
        GameObject P2Name=UIParent.GetChild(4).gameObject;
        Transform ImageTank=gameObject.transform.GetChild(1);

        //이름 설정
        P1Name.GetComponent<Text>().text=p1;
        P2Name.GetComponent<Text>().text=p2;

        //이미지 설정
        P1Image.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=ImageTank.Find(p1).gameObject.GetComponent<Image>().sprite;
        P2Image.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=ImageTank.Find(p2).gameObject.GetComponent<Image>().sprite;
    }

    public void GameGo()
    {
        //인게임 오브젝트 활성화
        foreach(GameObject obj in forGame)
        {
            obj.SetActive(true);
        }
        //로딩창 비활성화
        gameObject.SetActive(false);
    }
}
