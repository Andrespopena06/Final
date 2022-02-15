using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private Vector3 Min;
    public GameObject enemigo;
    private  Vector3 Max;
    private  float _xAxis;
    private  float _yAxis;
    private  float _zAxis; //If you need this, use it
    private Vector3 _randomPosition ;
    public bool _canInstantiate;
    private void Start()
    {
        SetRanges();
    }
    private void Update()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis );
    }
    //Here put the ranges where your object will appear, or put it in the inspector.
    private void SetRanges()
    {
        Min = new Vector3(45, 1, 47);
        Max = new Vector3(-43, 1, -43);
    }
    private void InstantiateRandomObjects()
    {
        if (_canInstantiate)
        {
            Instantiate(enemigo, _randomPosition , Quaternion.identity);
        }
        
    }
}
