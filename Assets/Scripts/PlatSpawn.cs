using UnityEngine;

public class PlatSpawn : MonoBehaviour
{       
    public GameObject platform;
    public static PlatSpawn instance;

    void Awake()
    {
        instance = this;
    }

    public void NewPlatSpawn()
    {
        Vector3 spawnPosPlat = new Vector3(-30.1f,0,0);
        Instantiate(platform, spawnPosPlat, Quaternion.identity);
    }
}
