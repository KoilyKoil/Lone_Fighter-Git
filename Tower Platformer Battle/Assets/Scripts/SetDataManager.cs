using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataManager : MonoBehaviour
{
    //데이터 매니저 전역처리
    public GameObject dataManager;

    void Start()
    {
        //데이터 넘김
        DontDestroyOnLoad(dataManager);
        Destroy(gameObject);
    }
}
