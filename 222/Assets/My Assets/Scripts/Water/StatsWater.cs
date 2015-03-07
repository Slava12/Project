using System.CodeDom;
using UnityEngine;
using System.Collections;

//public static class MyClass
//{
//	public static int l = -1;
//	public static int r = 0;
//}
public class StatsWater : MonoBehaviour {
	
	//// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	
	void Update () {
	    if (PlayerWater._stats)
	    {
	        var target = Quaternion.Euler(180, 0, 0);
	        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
			//Water.m_ReflectLayers = 0;
			//Water.m_RefractLayers = -1;
			//MyClass.l = 0;
			//MyClass.r = -1;
	    }
	    else
	    {
            var target = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
			//Water.m_ReflectLayers = -1;
			//Water.m_RefractLayers = 0;
			//MyClass.l = -1;
			//MyClass.r = 0;
	    }
	}
}
