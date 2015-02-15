using UnityEngine;
using System.Collections;

public class StatsWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (PlayerWater.Global.stats)
	    {
	        Quaternion target = Quaternion.Euler(180, 0, 0);
	        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
	    }
	    else
	    {
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
	    }
	}
}
