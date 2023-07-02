using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Net.NetworkInformation;


// Singleton Design Pattern

public class UIManager : MonoBehaviour
{
	private static UIManager m_instance;
	[SerializeField] TextMeshProUGUI m_questProgressText;
	[SerializeField] GameObject m_questCompletedPanel;

	public static UIManager Instance { get => m_instance; set => m_instance = value; }

	private void Awake()
	{
		if (m_instance != null && m_instance != this) {
			Destroy(this);
			return;
		}

		m_instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{
		m_questCompletedPanel.SetActive(false);
	}

	public void UpdateQuestProgressUI(String numCollected, String numCapacity)
	{
		string questProgessFormat = String.Format("{0} / {1}", numCollected, numCapacity);
		m_questProgressText.text = questProgessFormat;
	}

	public void QuestComplete()
	{
		m_questProgressText.text = "Done";
		StartCoroutine(ShowQuestCompletedPanel(3f));
	}

	private IEnumerator ShowQuestCompletedPanel(float delay)
	{
		m_questCompletedPanel.SetActive(true);
		yield return new WaitForSeconds(delay);
		m_questCompletedPanel.SetActive(false);
	}
}
