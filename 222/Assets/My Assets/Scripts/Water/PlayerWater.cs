using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour
{

    public BlurEffect bf;
    public float distance = 100f;
	////////////////////////////////////////////
	public GlobalFog gf;
	public static float health = 100;
	public static float oxygen = 100;
	////////////////////////////////////
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Ray ray = new Ray(transform.position, transform.up);
	    RaycastHit hit;

	    if (Physics.Raycast(ray, out hit, distance))
	    {
	        if (hit.collider.tag == "Water")
	        {
		        gf.enabled = true;
	            bf.enabled = true;
	            Global.stats = true;
		        oxygen -= Time.deltaTime * 6;
	        }
	    }
        else
	    {
		    gf.enabled = false;
	        bf.enabled = false;
            Global.stats = false;
			oxygen += Time.deltaTime * 6;
        }
		if (oxygen >= 100)
		{
			oxygen = 100;
		}
		if (oxygen <= 0)
		{
			oxygen = 0;
			health -= Time.deltaTime * 6;
		}
		if (health <= 0)
		{
			health = 0;
		}
	}

    public  static class Global
    {
        public static bool stats;
    }
}
