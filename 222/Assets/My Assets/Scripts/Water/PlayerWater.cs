using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour
{

    public BlurEffect bf;
    public float distance = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Ray ray = new Ray(transform.position, transform.up);
	    RaycastHit hit;

	    if (Physics.Raycast(ray, out hit, distance))
	    {
	        if (hit.collider.name == "water")
	        {
	            bf.enabled = true;
	            Global.stats = true;
	        }
	        if (hit.collider.name != "water")
	        {
	            bf.enabled = false;
	            Global.stats = false;
	        }
	    }
        else
	    {
	        bf.enabled = false;
            Global.stats = false;
        }
	}

    public  static class Global
    {
        public static bool stats;
    }
}
