using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHitEff : MonoBehaviour
{
    //��ũ��Ʈ Ȱ��ȭ�� ����
    void Awake()
    {
        //����Ʈ ����� �˾Ƽ� �� ��
        //����Ʈ Ȱ��ȭ�� �ִϸ��̼� ������ ������ ���� �Ͻ�����
        //����Ʈ ��� ���ᰡ Ȯ�εǸ� ��� ���� �� ���� Ȱ��ȭ
        Time.timeScale=0.5f;        //�ð��� 0���� ����
    }

    public void EndHitEffect()
    {
        Time.timeScale=1;
        Destroy(gameObject);
    }
}
