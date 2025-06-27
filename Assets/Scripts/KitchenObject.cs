using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부엌 오브젝트 스크립트
public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectso;

    private IKitchenObjectParent kitchenObjectParent; // 현재 위치한 계산대

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectso;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        // 계산대에 이미 오브젝트가 위치한 경우
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject(); // 오브젝트를 비운다.
        }
        this.kitchenObjectParent = kitchenObjectParent; // 현재 계산대로 수정

        if(kitchenObjectParent.HasKitchenObject()) // 오브젝트를 지웠는데 남아있는 경우
        {
            Debug.LogError("이미 물건이 있다.");
        }

        kitchenObjectParent.SetKitchenObject(this); // 현재 계산대에 이 오브젝트를 추가

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform(); // 부모 변경
        transform.localPosition = Vector3.zero; // 위치 이동
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
