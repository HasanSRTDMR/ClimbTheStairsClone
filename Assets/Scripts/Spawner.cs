using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]float posY=0.2f;
    [SerializeField]float rotY=15f;

    float stairPosY;
    float stairRotY=-10;
    float targetPosY;



    void OnEnable()
    {
        EventManager.MousePressEvent += SpawnStairs;
    }  

   
    // Start is called before the first frame update
    void Start()
    {
        stairPosY = transform.position.y;
        stairRotY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 StairsTransform(float posY)
    {
        stairPosY += posY;
        return new Vector3(transform.position.x, stairPosY, transform.position.z);
    } 
    public Vector3 TargetTransform(float posY)
    {
        targetPosY += posY;
        return new Vector3(transform.position.x, stairPosY, transform.position.z);
    }

    public Quaternion Direction(float rotY)
    {
        stairRotY += rotY;
        return Quaternion.AngleAxis(stairRotY, Vector3.up);
    }
    private void SpawnStairs()
    {
        ObjectPooler.Instance.GetPoolObject(0,StairsTransform(posY), Direction(rotY));
        ObjectPooler.Instance.GetPoolObject(1,TargetTransform(0.1f), Direction(0));
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= SpawnStairs;
    }
}
