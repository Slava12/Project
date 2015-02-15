using UnityEngine;
using System.Collections;

public class Sphere_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        transform.Translate(Vector3.right * Time.deltaTime);
	}

    void Awake()
    {
        renderer.material.color = Color.green;
    }
}
