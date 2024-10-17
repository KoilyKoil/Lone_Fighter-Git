using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Loading_Scenee : MonoBehaviour
{
    //�ε� ���� (�� ��ü���)
    //����ũ = https://wergia.tistory.com/183

    public static string nextScene; //�ε��� ���� ��

    [SerializeField]        //������ ����ȭ
    Image progressBar;      //�ε��� ������

    private void Start()
    {
        StartCoroutine(LoadScene());        //�ε����� �ڷ�ƾ Ȱ��ȭ
    }

    public static void LoadScene(string sceneName)
    {
        nextScene=sceneName;                   //������ ����
        Debug.Log(nextScene);
        SceneManager.LoadScene("Loading");      //�ϴ� �ε������� �ҷ���
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op=SceneManager.LoadSceneAsync(nextScene);       //�� �ε��� �س���
        op.allowSceneActivation=false;          //�� �ε��� ������ ���� ������ �ȳѾ

        float timer=0.0f;
        while(!op.isDone)       //�ε��� �������� �ʴٸ� null ��ȯ
        {
            yield return null;
        }

        timer+=Time.deltaTime;      //Ÿ�̸��� �ð��� �ʴ����� ���

        if(op.progress<0.9f)        //���൵�� 0.9������ ��
        {
            progressBar.fillAmount=Mathf.Lerp(progressBar.fillAmount, op.progress, timer);      //������ ��ŭ ����� ���� ����

            if(progressBar.fillAmount>=op.progress)         //����� ���̰� ���� ���൵�� �Ѿ�ٸ�
            {
                timer=0f;       //�ٽ� Ÿ�̸Ӹ� �ʱ�ȭ
            }
            else            //���� �۵� ���̶��
            {
                progressBar.fillAmount=Mathf.Lerp(progressBar.fillAmount, 1f, timer);       //���� ���൵�� ������ �о���
                if(progressBar.fillAmount==1.0f)        //�ε��� ������
                {
                    op.allowSceneActivation=true;       //�� �ε�
                    yield break;            //���� Ż��
                }
            }
        }
    }
}   
