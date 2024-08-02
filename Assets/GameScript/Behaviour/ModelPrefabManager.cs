using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPrefabManager : MonoBehaviour
{
    public List<GameObject> prefabList;
    public static ModelPrefabManager Inst;
    private void Awake()
    {
        Inst = this;
    }
}
