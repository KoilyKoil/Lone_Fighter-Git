using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallVersus : MonoBehaviour
{
    public GameObject[] forGame;        //�ε� �Ϸ�� Ȱ��ȭ�� ������Ʈ

    //ó�� �̸� �ε��� �޾��� �� ó��
    public void GetBeginData(string p1, string p2)
    {
        //�ʿ��� ������Ʈ���� ����
        Transform UIParent=gameObject.transform.GetChild(0);
        GameObject P1Image=UIParent.GetChild(1).gameObject;
        GameObject P1Name=UIParent.GetChild(2).gameObject;
        GameObject P2Image=UIParent.GetChild(3).gameObject;
        GameObject P2Name=UIParent.GetChild(4).gameObject;
        Transform ImageTank=gameObject.transform.GetChild(1);

        //�̸� ����
        P1Name.GetComponent<Text>().text=p1;
        P2Name.GetComponent<Text>().text=p2;

        //�̹��� ����
        P1Image.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=ImageTank.Find(p1).gameObject.GetComponent<Image>().sprite;
        P2Image.transform.GetChild(0).gameObject.GetComponent<Image>().sprite=ImageTank.Find(p2).gameObject.GetComponent<Image>().sprite;
    }

    public void GameGo()
    {
        //�ΰ��� ������Ʈ Ȱ��ȭ
        foreach(GameObject obj in forGame)
        {
            obj.SetActive(true);
        }
        //�ε�â ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
