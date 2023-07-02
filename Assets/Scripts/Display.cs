using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
	private IntroToCS m_intro;

	// Start is called before the first frame update
	void Start()
	{
		m_intro = GetComponent<IntroToCS>();
		m_intro.CurHp = 9999;
	}

	// Update is called once per frame
	void Update()
	{
		print("Display: " + m_intro.CurHp.ToString());
	}
}
