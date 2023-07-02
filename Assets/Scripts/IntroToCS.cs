using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToCS : MonoBehaviour
{
	// Instance variables (OOP Theory)
	// Fields --> States of object
	private int m_hp;

	// Decoration
	[SerializeField] int m_curHp;
	[SerializeField] int m_steps = 1;
	[SerializeField] float m_duration = 1.0f;
	[SerializeField] Transform m_enemies;

	private float lastUpdateHPTime = 0.0f;

	// Properties
	public int CurHp { get => m_curHp; set => m_curHp = value; }

	// Start is called before the first frame update
	void Start()
	{
		m_hp = 200;
		m_curHp = m_hp;
		LoopNameEnemies();
	}

	private void LoopNameEnemies()
	{
		foreach (Transform enemy in m_enemies) {
			print(enemy.name);
			print(enemy.position);
		}
	}

	// Update is called once per frame
	void Update()
	{
		int newHP = UpdateHP(m_steps, m_duration);
	}

	private int UpdateHP(int steps, float duration)
	{
		if (lastUpdateHPTime + duration < Time.time) {
			lastUpdateHPTime = Time.time;
			m_curHp += steps;
			print("Update: " + m_curHp.ToString());
		}

		return m_curHp;
	}
}
