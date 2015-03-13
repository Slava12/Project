using System.CodeDom;
using UnityEngine;
using System.Collections;

//public static class MyClass
//{
//	public static int l = -1;
//	public static int r = 0;
//}
public class StatsWater : MonoBehaviour
{
	private GameObject _render;
	private GameObject _render1;
	Vector3 ptr = new Vector3(0, 1, 0);
	//// Use this for initialization
	void Start () {
		_render = GameObject.Find("water0");
		_render1 = GameObject.Find("water01");
	}
	
	// Update is called once per frame
	
	void Update () {
	    if (PlayerWater._stats)
	    {
	       // var target = Quaternion.Euler(180, 0, 0);
	        //transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
			//Water.m_ReflectLayers = 0;
			//Water.m_RefractLayers = -1;
			//MyClass.l = 0;
			//MyClass.r = -1;
		    
			//Destroy(_render);
		    _render.renderer.enabled = false;
			_render1.renderer.enabled = true;
			//_render.transform.position = _render.transform.position + ptr;
	    }
	    else
	    {
           // var target = Quaternion.Euler(0, 0, 0);
           // transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
			//Water.m_ReflectLayers = -1;
			//Water.m_RefractLayers = 0;
			//MyClass.l = -1;
			//MyClass.r = 0;
			_render.renderer.enabled = true;
			_render1.renderer.enabled = false;
	    }
	}
}
