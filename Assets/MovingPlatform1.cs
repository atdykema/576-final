using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{

    [SerializeField]
    private MovingPlatformPath _path;

    [SerializeField]
    private float _speed;

    private int _currentMarkIndex;

    private Transform _prevMark;
    private Transform _currentMark;

    private float _timeToMark;
    private float _elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        TargetNextMark();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        float _elapsedPercentage = _elapsedTime/ _timeToMark; 
        transform.position = Vector3.Lerp(_prevMark.position, _currentMark.position, _elapsedPercentage);
        if(_elapsedPercentage >= 1){
            TargetNextMark();
        }
    }

    private void TargetNextMark(){
        _prevMark = _path.GetWaypointPath(_currentMarkIndex);
        _currentMarkIndex = _path.GetNextIndex(_currentMarkIndex);
        _currentMark = _path.GetWaypointPath(_currentMarkIndex);
        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_prevMark.position, _currentMark.position);
        _timeToMark = distanceToWaypoint/_speed;
    }
}
