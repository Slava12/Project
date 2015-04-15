using UnityEngine;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update()
	{
		if (Character.health <= 0)
		{
			Application.LoadLevel(2);
		}
	}
}
