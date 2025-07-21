using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 선택된 객체를 시각적으로 보여주도록 관리하는 스크립트
public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray; // 선택 표시 메테리얼을 가진 객체

    // Awake로하면 Player가 더 늦게 생성될 때 문제가 생김
    // Default Time으로 모든 스크립트가 동일한 시간에 생성함수 시간을 가지므로
    private void Start()
    {
        // 이벤트 등록
        //Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        // 이벤트에 등록된 객체가 같은 객체면 활성화, 아니면 비활성화
        if(e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach(GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
