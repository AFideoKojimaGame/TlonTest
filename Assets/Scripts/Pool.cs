using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    //prefab to pool
    [SerializeField] private GameObject prefab;
    //amount to pool
    [SerializeField] private int count;

    //list of pooled objects
    private List<PoolObject> objects = new List<PoolObject>();


    void Awake() {

        //pool objects at the beginning of scene
        for (int i = 0; i < count; i++) {
            PoolObject po = Create();
            //deactivate pooled object after creation
            po.gameObject.SetActive(false);
            objects.Add(po);
        }
    }

    public PoolObject Create() {

        GameObject go = Instantiate(prefab, transform);

        if (go) {
            PoolObject po = go.AddComponent<PoolObject>();
            po.SetPool(this);
            return po;
        }

        return null;
    }

    public PoolObject Spawn() {

        PoolObject po = null;

        if (objects.Count > 0) {
            po = objects[0];

            if (po != null) {
                //activate object & remove from pooled list

                po.gameObject.SetActive(true);
                objects.Remove(po);

            }else {
                //in case pooled object was previously destroyed

                objects.RemoveAt(0);
                po = Create();
            }
        }else {
            //if the number of requested objects exceeds initially pooled objs, create more

            po = Create();
            po.gameObject.SetActive(true);
        }

        return po;
    }

    public void Recycl(PoolObject po) {

        if (po != null && !objects.Contains(po)) {

            po.gameObject.SetActive(false);
            objects.Add(po);

        }
    }
}
