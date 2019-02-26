using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newRotate : MonoBehaviour
{
    public float rotateRate = 20f;
    public float lastYPosition = 0f;
    public float lastXPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.
        lastXPosition += 0.5f;
        lastYPosition += 0.5f;
        cube.transform.position = new Vector3(lastXPosition, lastYPosition, 0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, rotateRate * Time.deltaTime);
    }
}
