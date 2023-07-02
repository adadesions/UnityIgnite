using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	private static QuestManager m_instance;

	[SerializeField] int m_numHealthItemCollected = 0;
	[SerializeField] int m_questGoalHealthItemCollection = 10;

	private UIManager m_uiManager;

	public static QuestManager Instance { get => m_instance; set => m_instance = value; }

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
		m_uiManager = UIManager.Instance;
		UpdateQuestProgress();
	}

	private void UpdateQuestProgress()
	{
		string numCollected = m_numHealthItemCollected.ToString();
		string numQuestGoal = m_questGoalHealthItemCollection.ToString();
		m_uiManager.UpdateQuestProgressUI(numCollected, numQuestGoal);
	}

	public void CollectedItem()
	{
		m_numHealthItemCollected++;

		if (m_numHealthItemCollected >= m_questGoalHealthItemCollection) {
			m_numHealthItemCollected = m_questGoalHealthItemCollection;
			m_uiManager.QuestComplete();
			return;
		}

		UpdateQuestProgress();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
