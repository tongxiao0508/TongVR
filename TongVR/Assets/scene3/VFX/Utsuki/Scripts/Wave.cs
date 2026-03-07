using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    Renderer waterMaterial;

    public Transform origin;
    public Transform max;
    Vector3 originPos;
    Vector3 maxPos;
    float width;
    float length;
    float xPos = -1f;
    float zPos = -1f;
    // Use this for initialization
    void Start()
    {
        waterMaterial = GetComponent<Renderer>();
        originPos = origin.position;
        maxPos = max.position;
        width = Mathf.Abs(maxPos.x - originPos.x);
        length = Mathf.Abs(maxPos.z - originPos.z);

    }



    private void OnTriggerStay(Collider other)
    {
        xPos = Mathf.Abs(other.transform.position.x - originPos.x) / width;
        zPos = Mathf.Abs(other.transform.position.z - originPos.z) / length;
        waterMaterial.material.SetVector("_Pos", new Vector4(xPos, zPos, 0, 0));

    }
}