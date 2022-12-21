using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformPath : MonoBehaviour
{
    public Transform GetWaypointPath(int index){
        return transform.GetChild(index);
    }

    public int GetNextIndex(int index){
        int nextIndex = index + 1;

        if(nextIndex == transform.childCount){
            nextIndex = 0;
        }

        return nextIndex;
    }
}
