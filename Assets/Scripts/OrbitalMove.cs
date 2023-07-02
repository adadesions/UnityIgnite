using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMove : MonoBehaviour
{
	[SerializeField] Transform m_target;
	[SerializeField] float m_angle = 5f;
	[SerializeField] GameObject m_pathObj;
	[SerializeField] float m_cooldown = 1.0f;
	private float lastTimeCreatePath = 0.0f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(m_target.position, Vector3.up, m_angle * Time.deltaTime);
		CreatePath(m_cooldown);
	}

	private void CreatePath(float cooldown)
	{
		if (Time.time > lastTimeCreatePath + cooldown) {
			lastTimeCreatePath = Time.time;
			GameObject clone = Instantiate(m_pathObj, transform.position, Quaternion.identity);
			Destroy(clone, 5.0f);

			Vector3 newHeight = transform.position;
			newHeight.y += Mathf.Sin(Time.time);
			transform.position = newHeight;
		}
	}
}
