using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAround : MonoBehaviour
{
	[SerializeField] Transform m_target;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(m_target.position, Vector3.up, 20 * Time.deltaTime);
	}
}
