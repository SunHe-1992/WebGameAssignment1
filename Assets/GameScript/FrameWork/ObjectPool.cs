using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Inst;
    public List<GameObject> prefabList;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private List<GameObject> spawnedList;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Inst = this;
        LoadPrefabList(ModelPrefabManager.Inst.prefabList);

    }
    private void OnDestroy()
    {
        Inst = null;
    }
    public void LoadPrefabList(List<GameObject> pList)
    {
        prefabList = new List<GameObject>();
        prefabList.AddRange(pList);
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (GameObject prefab in pList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            poolDictionary.Add(prefab.name, objectPool);
            Debug.Log("add prefab " + prefab.name);
        }
    }
    void Start()
    {


    }

    public GameObject Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefabName))
        {
            Debug.LogWarning("Prefab with name " + prefabName + " doesn't exist in the pool.");
            return null;
        }

        GameObject objectToSpawn;

        if (poolDictionary[prefabName].Count > 0)
        {
            objectToSpawn = poolDictionary[prefabName].Dequeue();
            objectToSpawn.SetActive(true);
        }
        else
        {
            GameObject prefab = prefabList.Find(p => p.name == prefabName);
            if (prefab == null)
            {
                Debug.LogWarning("Prefab with name " + prefabName + " not found in the prefab list.");
                return null;
            }

            objectToSpawn = Instantiate(prefab);
            objectToSpawn.name = "instance_" + prefabName;
        }

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        if (spawnedList == null)
            spawnedList = new List<GameObject>();
        spawnedList.Add(objectToSpawn);
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    public void Unspawn(GameObject objectToUnspawn)
    {
        string prefabName = objectToUnspawn.name.Replace("(Clone)", "").Trim();
        prefabName = objectToUnspawn.name.Replace("instance_", "").Trim();
        if (!poolDictionary.ContainsKey(prefabName))
        {
            Debug.LogWarning("Prefab with name " + prefabName + " doesn't exist in the pool.");
            Destroy(objectToUnspawn);
            return;
        }

        objectToUnspawn.SetActive(false);
        poolDictionary[prefabName].Enqueue(objectToUnspawn);
    }
    public void UnspawnAll()
    {
        foreach (var obj in spawnedList)
        {
            Unspawn(obj);
        }
    }
}
