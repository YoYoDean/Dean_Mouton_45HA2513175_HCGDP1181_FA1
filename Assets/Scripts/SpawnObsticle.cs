using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnObsticle : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    private BoxCollider boxCollider;
    private GameObject ground;

    private float lastZ = 999f; // space control
    private float minZSpacing = 1.2f;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boxCollider.enabled = false; // prevent multiple triggers

            Spawn();
            PlatSpawn.instance.NewPlatSpawn();

            Debug.Log("Spawned");
        }
    }

    void OnTriggerExit(Collider other)
    {
            boxCollider.enabled = true;
        
    }

    void Spawn()
    {
        for (int i = 0, j = -2; i < 18; i++, j--)
        {
            // Decide if this row should have a gap
            if (Random.value < 0.25f)
                continue;

            //Pick a Z position with spacing control
            float zcor;
            int attempts = 0;

            do
            {
                zcor = Random.Range(-3f, 3f);
                attempts++;
            }
            while (Mathf.Abs(zcor - lastZ) < minZSpacing && attempts < 10);

            lastZ = zcor;

            //Randomly decide obstacle type
            int randObj = Random.Range(0, objects.Count);

            //Spawn chance controls densit
            if (Random.value < 0.7f)
            {
                Vector3 spawnCoor = new(j, 0f, zcor);

                GameObject obj = Instantiate(
                    objects[randObj],
                    spawnCoor,
                    Quaternion.identity,
                    ground.transform
                );

                // OPTIONAL: Random height (jump mechanic)
                // some obstacles require jumping
                if (Random.value < 0.4f)
                {
                    obj.transform.position += Vector3.up * Random.Range(0.5f, 1.5f);
                }
            }
        }
    }
}