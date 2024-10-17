using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;

public class CallLoading : MonoBehaviour
{
    public string myScene="Battle";
    public TransitionSettings transSet;     //ȭ����ȯ�ɼ�
    
    public void SelectToBattle()
    {
        Time.timeScale=1f;
        //������ �Ŵ����� ������ �Ѱ���
        GameObject getManager=GameObject.Find("DataManager");

        if(getManager.GetComponent<DataManager>().gameMode!=5)
        {
            getManager.GetComponent<DataManager>().myControl=1;
        }

        //�����͸� �� �Ѱ��� �� �ε� ȣ��
        TransitionManager.Instance().Transition(myScene, transSet, 0f);
        //SceneManager.LoadScene(myScene);
    }    
}
