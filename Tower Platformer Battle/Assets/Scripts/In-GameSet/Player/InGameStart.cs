using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameStart : MonoBehaviour
{
    ////변수 선언
    //데이터매니저 주소부
    GameObject dm;                      //데이터매니저 오브젝트
    public GameObject destForPlr;       //캐릭터 오브젝트를 놓을 목적지
    public GameObject objDataFolder;    //캐릭터 오브젝트가 들어있는 창고
    public GameObject UIFolderForP2;    //UI데이터 오브젝트
    public GameObject LoadingSkin;      //로딩화면 오브젝트

    //받아낼 데이터
    string p1Name;     //플레이어1자리 이름
    string p2Name;     //플레이어2자리 이름
    GameObject obj1;    //해당 이름의 오브젝트1
    GameObject obj2;    //해당 이름의 오브젝트2

    //캐릭터 복제를 위한 세부사항
    public int isOnline;        //게임모드, 온라인 상태 확인을 위함
    public int controller;      //조작을 하는 유저의 플레이어 자리

    //외부 스크립트의 데이터 적용
    public GameObject camera;

    //코루틴 사용을 위한 인터페이스 선언
    IEnumerator WaitForGameBegin()
    {
        yield return new WaitForSeconds(2.0f); //조건 설정. 3초뒤 함수 진행

        //함수 내용
        LoadingSkin.GetComponent<CallVersus>().GameGo();
    }

    public void Awake()
    {
        //데이터매니저를 받아옴
        dm=GameObject.Find("DataManager");
        p1Name=dm.GetComponent<DataManager>().p1Name;
        p2Name=dm.GetComponent<DataManager>().p2Name;
        isOnline=dm.GetComponent<DataManager>().gameMode;
        controller=dm.GetComponent<DataManager>().myControl;
        LoadingSkin.GetComponent<CallVersus>().GetBeginData(p1Name, p2Name);
        
        //오브젝트의 이름을 가져와 오브젝트 지정
        objDataFolder.SetActive(true);
        obj1=objDataFolder.transform.Find(p1Name).gameObject;
        obj2=objDataFolder.transform.Find(p2Name).gameObject;
        objDataFolder.SetActive(false);
        
        //오브젝트 복제
        GameObject clone1=GameObject.Instantiate(obj1, destForPlr.transform);
        clone1.name="Player1 Set";

        GameObject clone2=GameObject.Instantiate(obj2, destForPlr.transform);
        clone2.name="Player2 Set"; 
        clone2.GetComponent<PlayerData>().HPBar=UIFolderForP2.transform.Find("HP Bar2").gameObject.GetComponent<RectTransform>();
        clone2.GetComponent<PlayerData>().MPBar=UIFolderForP2.transform.Find("MP Bar2").gameObject.GetComponent<RectTransform>();        

        //본격적인 오브젝트 이동
        if(isOnline!=0)             //만일 온라인이 아닐시. 추후 온라인 개발시 게임모드 반영해줄 것
        {
            //카메라 오브젝트 적용처리
            camera.GetComponent<CameraMovementt>().pl1Set=clone1;
            camera.GetComponent<CameraMovementt>().pl2Set=clone2;

            //캐릭터 좌표 처리
            clone1.transform.position=new Vector3(-1.041f, -0.547f, -0.1f);
            clone2.transform.position=new Vector3(1.068f, -0.199f, -0.1f);

            Debug.Log("조건 접근");
            //컨트롤러 상태에 따라 컴포넌트 구분
            if(controller==1)       //1P 조작
            {
                clone1.AddComponent<PlayerMovement>();
                clone1.GetComponent<PlayerMovement>().plrData=clone1.GetComponent<PlayerData>();
                clone1.GetComponent<PlayerMovement>().plrRigidbody=clone1.GetComponent<Rigidbody2D>();
                clone2.AddComponent<AISet>();
                clone2.GetComponent<AISet>().opponent=clone1;
            }
            else if(controller==2)  //2P 조작
            {
                clone2.AddComponent<PlayerMovement>();
                clone2.GetComponent<PlayerMovement>().plrData=clone2.GetComponent<PlayerData>();
                clone2.GetComponent<PlayerMovement>().plrRigidbody=clone2.GetComponent<Rigidbody2D>();
                clone1.AddComponent<AISet>();
                clone1.GetComponent<AISet>().opponent=clone2;
            }
        }

        StartCoroutine("WaitForGameBegin");     //코루틴 접근
    }
}
