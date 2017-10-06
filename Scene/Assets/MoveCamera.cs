using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

    public GameObject target;
    public float rotateSpeed = 6;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //float both = Input.GetAxis("Mouse Z") * rotateSpeed;
        target.transform.Rotate(vertical, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        //float desiredUp = target.transform.eulerAngles.x;
        //float desiredBoth = target.transform.eulerAngles.z;
        Quaternion rotation = Quaternion.Euler(60, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset); ;
      
        transform.LookAt(target.transform);

    }
}