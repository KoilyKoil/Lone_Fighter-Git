using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataManager : MonoBehaviour
{
    public int gameMode=0;      //1=아케이드, 2=vs AI, 3=AI vs AI, 4=트레이닝, 5=멀티
    public int myControl=0;     //현 화면에서 조작자의 화면 (1=1P, 2=2P)
    public string p1Name;       //1P자리 이름
    public string p2Name;       //2P자리 이름

    //싱글톤을 이용한 데이터매니저 중복 방지
    //참고링크 : https://glikmakesworld.tistory.com/2

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
