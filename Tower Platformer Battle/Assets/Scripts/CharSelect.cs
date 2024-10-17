using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour
{
    //계획
    /*
    1. 버튼 클릭시 캐릭터를 선택해주는 코드 (포트릿 null 여부에 따라 채우는 포트릿을 달리함)
    2. 포트릿을 채우면서 만약 채운 포트릿이 오른쪽이면 스테이지 선택으로 넘어감
    3. 스테이지는 지금은 그냥 버튼으로 처리
    */

    public GameObject MainPortrait1, MainPortrait2;
    GameObject dataManager;

    void Awake()
    {
        dataManager=GameObject.Find("DataManager");     //데이터매니저 초기화
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
