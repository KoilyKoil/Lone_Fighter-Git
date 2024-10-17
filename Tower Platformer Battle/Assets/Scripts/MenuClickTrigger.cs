using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;           //ȭ�� ��ȯ�� ���� ���ӽ����̽� ��� ����


public class MenuClickTrigger : MonoBehaviour
{
    //����
    public GameObject menuCanvas;
    public GameObject menuBG;
    public GameObject charCanvas;
    GameObject dataManager;
    
    //ȭ����ȯ ó����
    public TransitionSettings transSet;     //ȭ����ȯ�ɼ�
    public float transDelay;                //ȭ����ȯȣ�� �����ð�
    public float callDelay;                 //�޴���ȯ �����ð�
    TransitionManager manager;              //ȭ����ȯ �Ű�


    //���� ���� ȭ����ȯ ó��
    void Awake()
    {
        dataManager=GameObject.Find("DataManager");     //�����͸Ŵ��� �ʱ�ȭ
        manager=TransitionManager.Instance();       //����ȯ���� ȭ�� ��ȯ ����� ���� �ν��Ͻ� �ʱ�ȭ
    }

    //�޴�1 Ŭ��
    public void Menu1()
    {
        //������ �ʱ�ȭ
        dataManager.GetComponent<DataManager>().gameMode=1;     //���Ӹ�� ���� �Ѱ���
        dataManager.GetComponent<DataManager>().myControl=0;
        dataManager.GetComponent<DataManager>().p1Name=null;
        dataManager.GetComponent<DataManager>().p2Name=null;
        Invoke("CallCharSelect", callDelay);        //ȭ��ó���� �����ð����� ��ư Ȱ��/��Ȱ�� ó��
        manager.Transition(transSet, transDelay);   //ȭ����ȯ ó��
    }
    //�޴�6 Ŭ��
    public void Menu6()
    {
        //���� ����
        manager.Transition(transSet, transDelay);   //ȭ����ȯ ó��
        Invoke("GameEndWait", callDelay);        //ȭ��ó���� �����ð����� ���� ���� ���
    }

    void CallCharSelect()
    {
        //�޴� Ȱ��/��Ȱ�� ó��
        menuCanvas.SetActive(false);
        menuBG.SetActive(false);
        charCanvas.SetActive(true);
    }

    void GameEndWait()
    {
        //���� ���� ó��
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;      //������ ȯ�濡�� �׽�Ʈ ����
        #else
            Application.Quit();             //���� ȯ�濡�� ���� ����
        #endif
    }
}