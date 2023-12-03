using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelObjectData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public string prefebName;
    public GameObject instantiatedObject;

    public LevelObjectData(Vector3 position, Quaternion rotation, Vector3 scale, string prefebName)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
        this.prefebName = prefebName;
    }
}

public class Proto_LevelGenerator : MonoBehaviour
{





    [SerializeField] private GameObject[] avaliableObjects;
    [SerializeField] private LayerMask groundLayer;
    private Dictionary<string, GameObject> objToNameMap = new Dictionary<string, GameObject>();




    public LayerMask GroundLayer => groundLayer;
    public GameObject[] AvaliableObjects => avaliableObjects;





    void Start()
    {
        CreateObjMap();
    }

    private void CreateObjMap()
    {
        objToNameMap = new Dictionary<string, GameObject>();
        foreach (var obj in avaliableObjects)
        {
            objToNameMap.Add(obj.name, obj);
        }
    }


    public GameObject CreateNewObject(LevelObjectData data)
    {
        return CreateObject(data);
    }

    private GameObject CreateObject(LevelObjectData data)
    {
        var prefab = GetPrefab(data.prefebName);
        if (prefab == null)
            return null;
        var instance = Instantiate(prefab);
        instance.transform.position = data.position;
        instance.transform.rotation = data.rotation;
        instance.transform.localScale = data.scale;

        data.instantiatedObject = instance;
        return instance;
    }

    private GameObject GetPrefab(string prefebName)
    {
        if (objToNameMap.TryGetValue(prefebName, out GameObject prefab))
            return prefab;
        Debug.LogError($"Prefab {prefebName} is not avaliable. Check the level generator inspector");
        return null;
    }
}
