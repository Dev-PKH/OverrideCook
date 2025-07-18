using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()] // 1개 만들어놓고 비활성화하면 유일한 레시피리스트SO가 됨
public class RecipeListSO : ScriptableObject
{
    public List<RecipeSO> recipeSOList;
}
