using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetComponent(out PlateKitchenObject plateKitchenObject))
            {
                // Only accepts Plates

                DeliveryManager.Instance.DeliveryRecipe(plateKitchenObject);

                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
