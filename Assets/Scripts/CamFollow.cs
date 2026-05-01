using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Vector3 CamOffset = new(4.7f, 2.8f , 0f);
    private Vector3 camRot = new(10f, 270f, 0f);
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = player.TransformPoint(CamOffset);
        
        Quaternion offsetRot = Quaternion.Euler(camRot);

        this.transform.rotation = offsetRot;

    }

}
