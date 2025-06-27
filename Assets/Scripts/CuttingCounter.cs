using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
 
    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // 계산대가 현재 비어있는 상태
        {
            if (player.HasKitchenObject()) // 플레이어가 재료를 가지고 있는 경우
            {
                player.GetKitchenObject().SetKitchenObjectParent(this); // 플레어의 재료를 현재 테이블로 옮김
            }
            else // 계산대도 플레이어도 재료가 없을 때
            {

            }
        }
        else // 계산대에 재료가 있는 경우
        {
            if (player.HasKitchenObject()) // 플레이어와 계산대 모두 재료가 있을 때
            {

            }
            else // 플레이어가 아무것도 없을 때
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject()) // 재료가 있을 때
        {
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
