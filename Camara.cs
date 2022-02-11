using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    [SerializeField] public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
