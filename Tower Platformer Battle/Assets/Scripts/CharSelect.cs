using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour
{
    //��ȹ
    /*
    1. ��ư Ŭ���� ĳ���͸� �������ִ� �ڵ� (��Ʈ�� null ���ο� ���� ä��� ��Ʈ���� �޸���)
    2. ��Ʈ���� ä��鼭 ���� ä�� ��Ʈ���� �������̸� �������� �������� �Ѿ
    3. ���������� ������ �׳� ��ư���� ó��
    */

    public GameObject MainPortrait1, MainPortrait2;
    GameObject dataManager;

    void Awake()
    {
        dataManager=GameObject.Find("DataManager");     //�����͸Ŵ��� �ʱ�ȭ
    }
    
    public void SelectChar(GameObject btn)
    {
        GameObject portrait=btn.transform.GetChild(0).gameObject;
        Debug.Log(portrait);
        Sprite img=portrait.GetComponent<Image>().sprite;

        if(MainPortrait1.GetComponent<Image>().sprite==null)
        {
            MainPortrait1.GetComponent<Image>().sprite=img;
            dataManager.GetComponent<DataManager>().p1Name=btn.name;
        }
        else
        {
            MainPortrait2.GetComponent<Image>().sprite=img;
            dataManager.GetComponent<DataManager>().p2Name=btn.name;
        }
    }

    public void SelectStage()
    {

    }
}
