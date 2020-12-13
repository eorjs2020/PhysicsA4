using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager current;
    public GameObject poolObject;
    public int poolAmount;
    public bool willGrow;

    private List<GameObject> active;

    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        active = new List<GameObject>();
        for (int i = 0; i < poolAmount; ++i)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            active.Add(obj);
        }
    }
    public GameObject GetActiveObject()
    {
        for(int i = 0; i < active.Count; ++i)
        {
            if(!active[i].activeInHierarchy)
            {
                return active[i];
            }
        }

        return null;
    }

}
