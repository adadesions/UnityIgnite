using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
	[SerializeField] GameObject m_itemPrefab;
	[SerializeField] GameObject m_openBoxEffectPrefab;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player")) {
			GameObject effectClone = Instantiate(
				m_openBoxEffectPrefab,
				transform.position,
				Quaternion.identity
			);


			Instantiate(
				m_itemPrefab,
				transform.position,
				Quaternion.identity
			);

			Destroy(effectClone, 1f);
			Destroy(gameObject);
		}
	}
}
