using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitOnBackPress : MonoBehaviour
{
    private float backPressTime = 0f; // �ڷ� ���� ��ư�� ���� �ð�
    private bool backPressedOnce = false; // �ڷ� ���� ��ư�� �� �� �������� ����
    public TMP_Text messageText; // �޽����� ǥ���� UI Text ������Ʈ

    void Update()
    {
        // ����Ʈ�� �ڷΰ��� ��ư�̳� ESC Ű ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backPressedOnce)
            {
                // 2��° �ڷ� ���� ��ư ������ ����
                ExitGame();
                Debug.Log("������ �����մϴ�.");
            }
            else
            {
                // ó�� �ڷ� ���� ��ư�� ������ �޽��� ���
                backPressedOnce = true;
                messageText.text = "�ڷ� ���⸦ �ѹ� �� ������ ����˴ϴ�.";
                backPressTime = Time.time; // �ڷΰ��� ��ư�� ���� �ð� ���
            }
        }

        // 3�� �̳��� �ٽ� ������ �����ϰ�, 3�ʰ� ������ �޽����� �ʱ�ȭ
        if (backPressedOnce && Time.time - backPressTime > 1f)
        {
            backPressedOnce = false; // 3�ʰ� ������ �޽��� ����
            messageText.text = ""; // �޽��� �����
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
