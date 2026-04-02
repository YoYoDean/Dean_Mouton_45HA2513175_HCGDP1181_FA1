using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticle : MonoBehaviour
{
    private int xcor ;
    private int zcor ;
    private int randObj;
    public List<GameObject> objects = new List<GameObject>();
    private BoxCollider boxCollider;
    private GameObject ground;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    void OnTriggerEnter(Collider other)
    {
        boxCollider.enabled = false;
        if (other.CompareTag("Player"))
        {
            Spawn();
            Debug.Log("Spawned");
        }
    }

    void Spawn()
    {
        for(int i = 0 , j = 0; i < 20 ; i++)
        {
            randObj = Random.Range(0, objects.Count);
            xcor = j;
            int x = Random.Range(0,3);
            if(x == 0) zcor = -2;
            if(x == 1) zcor = 0;
            if(x == 2) zcor = 2;
            Vector3 spwanCoor = new Vector3(xcor , .5f, zcor);
            Instantiate(objects[randObj],spwanCoor, Quaternion.identity, ground.transform);
            j--;

        }
    }


}
