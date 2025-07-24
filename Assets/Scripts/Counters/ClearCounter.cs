using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 정리된 계산대
public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject()) // 계산대가 현재 비어있는 상태
        {
            if(player.HasKitchenObject()) // 플레이어가 재료를 가지고 있는 경우
            {
                player.GetKitchenObject().SetKitchenObjectParent(this); // 플레어의 재료를 현재 테이블로 옮김
            }
            else // 계산대도 플레이어도 재료가 없을 때
            {
                
            }
        }
        else // 계산대에 재료가 있는 경우
        {
            if(player.HasKitchenObject()) // 플레이어와 계산대 모두 재료가 있을 때
            {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) // 현재 들고 있는게 그릇이라면
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) // 플레이팅 재료라면 삭제
                    {
                        KitchenObject.DestroyKitchenObject(GetKitchenObject());
                    }
                }
                else // 플레이어가 그릇이 아닌 다른걸 들고 있다면
                {// 위에서 out PlateKitchenObject plateKitchenObject로 선언했기 때문에 밑에는 그대로 해당 변수를 가져다 쓸 수 있음
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) // 테이블에 있는게 그릇일 때
                    {
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) // 플레이어가 플레이팅 재료를 들고 있다면
                        {
                            KitchenObject.DestroyKitchenObject(player.GetKitchenObject()); // 플레이어 재료 삭제
                        }
                    }
                }
            }
            else // 플레이어가 아무것도 없을 때
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
