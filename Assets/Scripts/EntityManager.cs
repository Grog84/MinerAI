using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This singleton implementation is not multitheread safe
public class EntityManager {

    private static EntityManager instance;
    private List<GameObject> entitiesList = new List<GameObject>();

    private EntityManager() { }

    public static EntityManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EntityManager();
            }
            return instance;
        }
    }

    public void RegisterEntity() { }

    public void RemoveEntityByID() { }

    public GameObject GetEntityByID(int id) { return entitiesList[id]; }

}
