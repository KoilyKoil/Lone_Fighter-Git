using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoveself : MonoBehaviour
{
    //������Ʈ �̵� ó��
    public Vector2 startPos;
    public Vector2 orgPos;
    public float xSavePoint;
    public float ySavePoint;
    public float xspeed;
    public float yspeed;
    public int moveDir=0;         //1=x, 2=y, 3=xy
    public bool xloop=false;
    public bool yloop=false;

    void Start()
    {
        //x���� ����
        if(xloop==true)
        {
            //������Ʈ ����
            GameObject loopObj1=Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
            GameObject loopObj2=Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);

            //������Ʈ ������Ʈ ����
            Destroy(loopObj1.GetComponent<BGMoveself>());
            Destroy(loopObj2.GetComponent<BGMoveself>());

            //����� ������Ʈ �θ� ����
            loopObj1.transform.parent=gameObject.transform;
            loopObj2.transform.parent=gameObject.transform;

            //������Ʈ ��ġ ����
            float mySize=gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            loopObj1.transform.position=new Vector3(orgPos.x+mySize, orgPos.y, 0f);
            loopObj2.transform.position=new Vector3(orgPos.x-mySize, orgPos.y, 0f);

            //������Ʈ ũ�� ����
            loopObj1.transform.localScale=new Vector3(1f,1f,1f);
            loopObj2.transform.localScale=new Vector3(1f,1f,1f);
        }

        //y���� ����
        if(yloop==true)
        {
            //������Ʈ ����
            GameObject loopObj1=Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
            GameObject loopObj2=Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);

            //������Ʈ ������Ʈ ����
            Destroy(loopObj1.GetComponent<BGMoveself>());
            Destroy(loopObj2.GetComponent<BGMoveself>());

            //����� ������Ʈ �θ� ����
            loopObj1.transform.parent=gameObject.transform;
            loopObj2.transform.parent=gameObject.transform;

            //������Ʈ ��ġ ����
            float mySize=gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
            loopObj1.transform.position=new Vector3(orgPos.x, orgPos.y+mySize, 0f);
            loopObj2.transform.position=new Vector3(orgPos.x, orgPos.y-mySize, 0f);

            //������Ʈ ũ�� ����
            loopObj1.transform.localScale=new Vector3(1f,1f,1f);
            loopObj2.transform.localScale=new Vector3(1f,1f,1f);
        }
    }

    void Update()
    {
        if(moveDir==1)
        {
            startPos=startPos-Vector2.right*(xspeed/1000);     //������Ʈ �̵�ó��
            if((xSavePoint>0&&startPos.x>=xSavePoint)||(xSavePoint<0&&startPos.x<=xSavePoint)&&xloop==true)
            {
                startPos=new Vector2(orgPos.x, orgPos.y);
            }
            gameObject.transform.position=startPos;
        }
        else if(moveDir==2)
        {
            startPos=startPos-Vector2.up*(yspeed/1000);     //������Ʈ �̵�ó��
            if((ySavePoint>0&&startPos.y>=ySavePoint)||(ySavePoint<0&&startPos.y<=ySavePoint)&&yloop==true)
            {
                startPos=new Vector2(orgPos.x, orgPos.y);
            }
            gameObject.transform.position=startPos;
        }
        else if(moveDir==3)
        {
            startPos=startPos-Vector2.right*(xspeed/1000);     //������Ʈ �̵�ó��
            if((xSavePoint>0&&startPos.x>=xSavePoint)||(xSavePoint<0&&startPos.x<=xSavePoint)&&xloop==true)
            {
                startPos=new Vector2(orgPos.x, startPos.y);
            }
            startPos=startPos-Vector2.up*(yspeed/1000);     //������Ʈ �̵�ó��
            if((ySavePoint>0&&startPos.y>=ySavePoint)||(ySavePoint<0&&startPos.y<=ySavePoint)&&yloop==true)
            {
                startPos=new Vector2(startPos.x, orgPos.y);
            }
            gameObject.transform.position=startPos;
        }
    }
}
