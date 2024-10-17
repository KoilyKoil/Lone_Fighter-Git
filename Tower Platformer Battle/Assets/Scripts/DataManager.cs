using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataManager : MonoBehaviour
{
    public int gameMode=0;      //1=�����̵�, 2=vs AI, 3=AI vs AI, 4=Ʈ���̴�, 5=��Ƽ
    public int myControl=0;     //�� ȭ�鿡�� �������� ȭ�� (1=1P, 2=2P)
    public string p1Name;       //1P�ڸ� �̸�
    public string p2Name;       //2P�ڸ� �̸�

    //�̱����� �̿��� �����͸Ŵ��� �ߺ� ����
    //����ũ : https://glikmakesworld.tistory.com/2

    private static DataManager instance=null;

    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static DataManager Instance
    {
        get
        {
            if(instance==null)
            {
                return null;
            }
            return instance;
        }
    }
}
