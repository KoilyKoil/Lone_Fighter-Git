using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataManager : MonoBehaviour
{
    //������ �Ŵ��� ����ó��
    public GameObject dataManager;

    void Start()
    {
        //������ �ѱ�
        DontDestroyOnLoad(dataManager);
        Destroy(gameObject);
    }
}
