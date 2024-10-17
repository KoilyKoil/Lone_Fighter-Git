using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{
    public Transform plrDir;
    public Transform ingredients;

    void OnEnable()
    {
        //�÷��̾� ������ ����
        InGameStart userData=GameObject.Find("AwakeObject").GetComponent<InGameStart>();
        int hp1=plrDir.GetChild(0).gameObject.GetComponent<PlayerData>().HP;
        int hp2=plrDir.GetChild(1).gameObject.GetComponent<PlayerData>().HP;
        GameObject dmObj=GameObject.Find("DataManager");
        DataManager dm=dmObj.GetComponent<DataManager>();

        //�̸� ����
        //�÷��̾�1�� �׾��� ��
        if(hp1<=0){SetData(dm.p2Name);}
        //�÷��̾�2�� �׾��� ��
        else if(hp2<=0){SetData(dm.p1Name);}
    }

    void SetData(string name)
    {
        //�ֿ� �� �ʱ�ȭ
        GameObject plrData=ingredients.Find(name).gameObject;
        Transform status=gameObject.transform.GetChild(0);

        //������ ����
        status.GetChild(1).GetComponent<Text>().text=name;
        status.GetChild(3).GetComponent<Text>().text=plrData.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        status.GetChild(4).GetChild(0).GetComponent<Image>().sprite=plrData.GetComponent<Image>().sprite;
    }
}
