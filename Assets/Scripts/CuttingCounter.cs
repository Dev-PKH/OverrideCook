using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingKitchenObjectSOArray;
 
    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) // 계산대가 현재 비어있는 상태
        {
            if (player.HasKitchenObject()) // 플레이어가 재료를 가지고 있는 경우
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){ // Slice가 가능한 재료인지를 파악
                    player.GetKitchenObject().SetKitchenObjectParent(this); // 플레어의 재료를 현재 테이블로 옮김
                }
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
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) // 재료가 있고 해당 재료가 레시피에 해당될 경우(kitchenSO == input)
        {
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingKitchenObjectSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingKitchenObjectSOArray)
        {
            if(cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }

        return null;
    }
}
