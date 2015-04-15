using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour
{

    public BlurEffect bf;
    public float distance = 100f;
	////////////////////////////////////////////
	public GlobalFog gf;
	private float _speed;
	public static bool _stats;
	////////////////////////////////////
	// Use this for initialization
	void Start ()
	{
		gf.enabled = false;
		bf.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		_speed = Time.deltaTime * 6 * GameTime.scale;
	    var ray = new Ray(transform.position, transform.up);
	    RaycastHit hit;

	    if (Physics.Raycast(ray, out hit, distance))
	    {
	        if (hit.collider.tag == "Water")
	        {
		        gf.enabled = true;
	            bf.enabled = true;
	            _stats = true;
		        Character.oxygen -= _speed;
	        }
	    }
        else
	    {
		    gf.enabled = false;
	        bf.enabled = false;
            _stats = false;
			Character.oxygen += _speed;
        }
		if (Character.oxygen >= 100)
		{
			Character.oxygen = 100;
		}
		if (Character.oxygen <= 0)
		{
			Character.oxygen = 0;
			Character.health -= _speed;
		}
		if (Character.health <= 0)
		{
			Character.health = 0;
		}
	}

	//public  static class Global
	//{
	//	public static bool stats;
	//}
}
