using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour
{

    public BlurEffect bf;
    public float distance = 100f;
	////////////////////////////////////////////
	public GlobalFog gf;
	public static float health;
	public static float oxygen;

	public static bool _stats;
	////////////////////////////////////
	// Use this for initialization
	void Start ()
	{
		health = 100;
		oxygen = 100;
		gf.enabled = false;
		bf.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    var ray = new Ray(transform.position, transform.up);
	    RaycastHit hit;

	    if (Physics.Raycast(ray, out hit, distance))
	    {
	        if (hit.collider.tag == "Water")
	        {
		        gf.enabled = true;
	            bf.enabled = true;
	            _stats = true;
		        oxygen -= Time.deltaTime * 6 * GameTime.scale;
	        }
	    }
        else
	    {
		    gf.enabled = false;
	        bf.enabled = false;
            _stats = false;
			oxygen += Time.deltaTime * 6 * GameTime.scale;
        }
		if (oxygen >= 100)
		{
			oxygen = 100;
		}
		if (oxygen <= 0)
		{
			oxygen = 0;
			health -= Time.deltaTime * 6 * GameTime.scale;
		}
		if (health <= 0)
		{
			health = 0;
		}
	}

	//public  static class Global
	//{
	//	public static bool stats;
	//}
}
