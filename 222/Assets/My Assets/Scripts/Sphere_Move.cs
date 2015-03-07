using UnityEngine;
using System.Collections;

public class Sphere_Move : MonoBehaviour
{

	private Transform _thisTransform;
	// Use this for initialization
	void Start ()
	{
		_thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
        _thisTransform.Translate(Vector3.right * Time.deltaTime*GameTime.scale);
	}
}
