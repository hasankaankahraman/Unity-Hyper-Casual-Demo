using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWall : MonoBehaviour
{
    public Transform LeftVector;
    public Transform RightVector;
    public Transform FrontVector;
    public Transform BackVector;

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, BackVector.transform.position.z, FrontVector.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, LeftVector.transform.position.x, RightVector.transform.position.x);
        transform.position = viewPos;
    }
}
