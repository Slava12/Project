using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
	    if (Input.GetKey(KeyCode.W))
	    {
		    transform.Translate(0, 0, 0.1f);
	    }
    }

}
