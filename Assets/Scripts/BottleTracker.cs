using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BottleTracker : MonoBehaviour
{

    public GameObject waterBottle;
    public Vector2 areaXSize = new Vector2(-30,80);
    public Vector2 areaZSize = new Vector2(-80,40);
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("WaterBottle").Length <= 3)
        {
            SpawnMoreWater();
        }
    }

    void SpawnMoreWater()
    {
        Debug.Log("More Water Spawned!");
        for (int i = 0; i < 5; i++) //spawn 5 more water bottles
        {
            float xCor = Random.Range(areaXSize.x, areaXSize.y);
            float zCor = Random.Range(areaZSize.x, areaZSize.y);

            Instantiate(waterBottle , new Vector3(xCor , 0 , zCor), quaternion.identity);
        }
    }
}
