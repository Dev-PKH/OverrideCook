using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부엌 오브젝트 ScriptableObject
[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
