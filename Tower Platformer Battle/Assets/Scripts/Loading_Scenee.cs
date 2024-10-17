using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Loading_Scenee : MonoBehaviour
{
    //로딩 구현 (씬 교체방식)
    //참고링크 = https://wergia.tistory.com/183

    public static string nextScene; //로딩할 다음 씬

    [SerializeField]        //변수의 전역화
    Image progressBar;      //로딩바 오브제

    private void Start()
    {
        StartCoroutine(LoadScene());        //로딩씬의 코루틴 활성화
    }

    public static void LoadScene(string sceneName)
    {
        nextScene=sceneName;                   //목적지 설정
        Debug.Log(nextScene);
        SceneManager.LoadScene("Loading");      //일단 로딩씬부터 불러옴
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op=SceneManager.LoadSceneAsync(nextScene);       //씬 로딩을 해놓음
        op.allowSceneActivation=false;          //씬 로딩이 끝나도 다음 씬으로 안넘어감

        float timer=0.0f;
        while(!op.isDone)       //로딩이 끝나있지 않다면 null 반환
        {
            yield return null;
        }

        timer+=Time.deltaTime;      //타이머의 시간은 초단위로 상승

        if(op.progress<0.9f)        //진행도가 0.9이하일 때
        {
            progressBar.fillAmount=Mathf.Lerp(progressBar.fillAmount, op.progress, timer);      //진행한 만큼 진행바 길이 조정

            if(progressBar.fillAmount>=op.progress)         //진행바 길이가 실제 진행도를 넘어섰다면
            {
                timer=0f;       //다시 타이머를 초기화
            }
            else            //정상 작동 중이라면
            {
                progressBar.fillAmount=Mathf.Lerp(progressBar.fillAmount, 1f, timer);       //바의 진행도를 끝까지 밀어줌
                if(progressBar.fillAmount==1.0f)        //로딩이 끝나면
                {
                    op.allowSceneActivation=true;       //씬 로딩
                    yield break;            //루프 탈출
                }
            }
        }
    }
}   
