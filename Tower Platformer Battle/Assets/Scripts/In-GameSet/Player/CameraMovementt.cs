using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementt : MonoBehaviour
{
    //선언
    //public Vector3 offset;
    public float followSpeed=0.15f;     //카메라 추적 속도
    public Vector2 minCameraBoundary;   //카메라 최소경계
    public Vector2 maxCameraBoundary;   //카메라 최대 경계
    public float distLimit=0.5f;
    public float CameraDistanceNum=1.5f;

    //플레이어 좌표
    public GameObject pl1Set;
    public GameObject pl2Set;

    void FixedUpdate()
    {
        //두 좌표간 중점연산
        Vector3 pos1=pl1Set.transform.position;
        Vector3 pos2=pl2Set.transform.position;
        Vector3 middlePoint=(pos1+pos2)/2f;

        //좌표 경계 적용
        middlePoint.x=Mathf.Clamp(middlePoint.x, minCameraBoundary.x, maxCameraBoundary.x);
        middlePoint.y=Mathf.Clamp(middlePoint.y, minCameraBoundary.y, maxCameraBoundary.y);
        middlePoint.z=this.transform.position.z;

        //중점을 활용한 카메라 좌표점 설정
        //Vector3 camera_pos=middlePoint+offset;
        Vector3 camera_pos=middlePoint;
        //선형 보간
        Vector3 lerp_pos=Vector3.Lerp(transform.position, camera_pos, followSpeed);
        //Vector3 lerp_pos=Vector3.Lerp(transform.position, camera_pos, followSpeed);
        //좌표 적용
        transform.position=lerp_pos;

        //transform.LookAt(middlePoint);

        //카메라 사이즈 변경
        float dist=Vector3.Distance(pos1, pos2)/CameraDistanceNum;
        if(dist<distLimit)
        {
            dist=distLimit;   
        }
        this.GetComponent<Camera>().orthographicSize=dist;
    }
}
