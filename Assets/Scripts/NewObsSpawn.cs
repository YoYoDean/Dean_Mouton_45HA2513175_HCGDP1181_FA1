using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewObsSpawn : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public Vector2 areaXSize = new Vector2(-35,91);
    public Vector2 areaZSize = new Vector2(-90,51);
    public int numberOfObjects = 300;
    


    void Start()
    {
        

        for (int i = 0; i < numberOfObjects; i++)
        {
            float xCor = Random.Range(areaXSize.x, areaXSize.y);
            float zCor = Random.Range(areaZSize.x, areaZSize.y);

            GameObject objToSpawn = objects[Random.Range(0, objects.Count - 1)];
            //Debug.Log(xCor + "" + zCor + "" + objToSpawn);

            Instantiate(objToSpawn, new Vector3(xCor, 0, zCor), quaternion.identity);
        }

    }
}
