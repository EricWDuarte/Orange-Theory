using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFunctions {

	public static int RandomSign ()
    {
        return Random.value < .5 ? -1 : 1;
    }

    public static Vector3 FindDirectionWithAngle(float angle)
    {
        angle *= Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
    }
}
