using UnityEngine;

public class PlatSpawn : MonoBehaviour
{
    public GameObject platform;
    public static PlatSpawn instance;

    public float platformLength = 20f;

    private GameObject lastPlatform;

    void Awake()
    {
        instance = this;
    }

    public void NewPlatSpawn()
    {
        if (lastPlatform == null)
        {
            lastPlatform = GameObject.FindGameObjectWithTag("Ground");
        }

        float newX = lastPlatform.transform.position.x - platformLength;

        Vector3 spawnPos = new Vector3(newX, 0, 0);
        GameObject newPlat = Instantiate(platform, spawnPos, Quaternion.identity);

        lastPlatform = newPlat;
    }
}