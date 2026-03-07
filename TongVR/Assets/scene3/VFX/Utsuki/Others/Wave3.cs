using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
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

    [Header("Target Object (Assign camera or headset PLZ)")]
    public GameObject target;

    void Start()
    {
        waterMaterial = GetComponent<Renderer>();
        originPos = origin.position;
        maxPos = max.position;
        width = Mathf.Abs(maxPos.x - originPos.x);
        length = Mathf.Abs(maxPos.z - originPos.z);

    }

    private void Update()
    {
        if (target != null)
        {
            xPos = Mathf.Abs(target.transform.position.x - originPos.x) / width;
            zPos = Mathf.Abs(target.transform.position.z - originPos.z) / length;
            waterMaterial.material.SetVector("_Pos", new Vector4(xPos, zPos, 0, 0));
        }
    }
}