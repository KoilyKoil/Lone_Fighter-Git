using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementt : MonoBehaviour
{
    //����
    //public Vector3 offset;
    public float followSpeed=0.15f;     //ī�޶� ���� �ӵ�
    public Vector2 minCameraBoundary;   //ī�޶� �ּҰ��
    public Vector2 maxCameraBoundary;   //ī�޶� �ִ� ���
    public float distLimit=0.5f;
    public float CameraDistanceNum=1.5f;

    //�÷��̾� ��ǥ
    public GameObject pl1Set;
    public GameObject pl2Set;

    void FixedUpdate()
    {
        //�� ��ǥ�� ��������
        Vector3 pos1=pl1Set.transform.position;
        Vector3 pos2=pl2Set.transform.position;
        Vector3 middlePoint=(pos1+pos2)/2f;

        //��ǥ ��� ����
        middlePoint.x=Mathf.Clamp(middlePoint.x, minCameraBoundary.x, maxCameraBoundary.x);
        middlePoint.y=Mathf.Clamp(middlePoint.y, minCameraBoundary.y, maxCameraBoundary.y);
        middlePoint.z=this.transform.position.z;

        //������ Ȱ���� ī�޶� ��ǥ�� ����
        //Vector3 camera_pos=middlePoint+offset;
        Vector3 camera_pos=middlePoint;
        //���� ����
        Vector3 lerp_pos=Vector3.Lerp(transform.position, camera_pos, followSpeed);
        //Vector3 lerp_pos=Vector3.Lerp(transform.position, camera_pos, followSpeed);
        //��ǥ ����
        transform.position=lerp_pos;

        //transform.LookAt(middlePoint);

        //ī�޶� ������ ����
        float dist=Vector3.Distance(pos1, pos2)/CameraDistanceNum;
        if(dist<distLimit)
        {
            dist=distLimit;   
        }
        this.GetComponent<Camera>().orthographicSize=dist;
    }
}
