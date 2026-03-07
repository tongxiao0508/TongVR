using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_test : MonoBehaviour {
    Renderer waterMaterial;

    public Transform origin;
    public Transform max;
    Vector3 originPos;
    Vector3 maxPos;
    float width;
    float length;
    float xPos = -1f;
    float zPos = -1f;


	void Start () {
        waterMaterial = GetComponent<Renderer>();
        originPos = origin.position;
        maxPos = max.position;
        width = Mathf.Abs(maxPos.x - originPos.x);
        length = Mathf.Abs(maxPos.z - originPos.z);


    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 objectPos = other.transform.position;

        xPos = Mathf.Abs(objectPos.x - originPos.x) / width;
        zPos = Mathf.Abs(objectPos.z - originPos.z) / length;
        waterMaterial.material.SetFloat("_xPos",xPos);
        waterMaterial.material.SetFloat("_zPos", zPos);

    }
}
