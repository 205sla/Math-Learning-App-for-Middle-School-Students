using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitOnBackPress : MonoBehaviour
{
    private float backPressTime = 0f; // 뒤로 가기 버튼을 누른 시간
    private bool backPressedOnce = false; // 뒤로 가기 버튼을 한 번 눌렀는지 여부
    public TMP_Text messageText; // 메시지를 표시할 UI Text 컴포넌트

    void Update()
    {
        // 스마트폰 뒤로가기 버튼이나 ESC 키 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backPressedOnce)
            {
                // 2번째 뒤로 가기 버튼 누르면 종료
                ExitGame();
                Debug.Log("게임을 종료합니다.");
            }
            else
            {
                // 처음 뒤로 가기 버튼을 누르면 메시지 출력
                backPressedOnce = true;
                messageText.text = "뒤로 가기를 한번 더 누르면 종료됩니다.";
                backPressTime = Time.time; // 뒤로가기 버튼을 누른 시간 기록
            }
        }

        // 3초 이내에 다시 누르면 종료하고, 3초가 지나면 메시지를 초기화
        if (backPressedOnce && Time.time - backPressTime > 1f)
        {
            backPressedOnce = false; // 3초가 지나면 메시지 리셋
            messageText.text = ""; // 메시지 지우기
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
