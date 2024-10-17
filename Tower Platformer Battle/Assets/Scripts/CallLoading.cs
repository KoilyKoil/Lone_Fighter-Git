using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;

public class CallLoading : MonoBehaviour
{
    public string myScene="Battle";
    public TransitionSettings transSet;     //화면전환옵션
    
    public void SelectToBattle()
    {
        Time.timeScale=1f;
        //데이터 매니저에 값들을 넘겨줌
        GameObject getManager=GameObject.Find("DataManager");

        if(getManager.GetComponent<DataManager>().gameMode!=5)
        {
            getManager.GetComponent<DataManager>().myControl=1;
        }

        //데이터를 다 넘겼을 때 로딩 호출
        TransitionManager.Instance().Transition(myScene, transSet, 0f);
        //SceneManager.LoadScene(myScene);
    }    
}
