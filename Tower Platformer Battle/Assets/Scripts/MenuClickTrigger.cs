using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;           //화면 전환을 위한 네임스페이스 사용 선언


public class MenuClickTrigger : MonoBehaviour
{
    //선언
    public GameObject menuCanvas;
    public GameObject menuBG;
    public GameObject charCanvas;
    GameObject dataManager;
    
    //화면전환 처리용
    public TransitionSettings transSet;     //화면전환옵션
    public float transDelay;                //화면전환호출 지연시간
    public float callDelay;                 //메뉴전환 지연시간
    TransitionManager manager;              //화면전환 매개


    //이후 기존 화면전환 처리
    void Awake()
    {
        dataManager=GameObject.Find("DataManager");     //데이터매니저 초기화
        manager=TransitionManager.Instance();       //씬전환없이 화면 전환 사용을 위한 인스턴스 초기화
    }

    //메뉴1 클릭
    public void Menu1()
    {
        //데이터 초기화
        dataManager.GetComponent<DataManager>().gameMode=1;     //게임모드 값을 넘겨줌
        dataManager.GetComponent<DataManager>().myControl=0;
        dataManager.GetComponent<DataManager>().p1Name=null;
        dataManager.GetComponent<DataManager>().p2Name=null;
        Invoke("CallCharSelect", callDelay);        //화면처리중 암전시간동안 버튼 활성/비활성 처리
        manager.Transition(transSet, transDelay);   //화면전환 처리
    }
    //메뉴6 클릭
    public void Menu6()
    {
        //게임 종료
        manager.Transition(transSet, transDelay);   //화면전환 처리
        Invoke("GameEndWait", callDelay);        //화면처리중 암전시간동안 게임 종료 대기
    }

    void CallCharSelect()
    {
        //메뉴 활성/비활성 처리
        menuCanvas.SetActive(false);
        menuBG.SetActive(false);
        charCanvas.SetActive(true);
    }

    void GameEndWait()
    {
        //게임 종료 처리
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;      //에디터 환경에서 테스트 종료
        #else
            Application.Quit();             //실제 환경에서 게임 종료
        #endif
    }
}