using System;
using TMPro;
using UnityEngine;

namespace Game.FirstGame.Scripts
{
    public class QuestManager : MonoBehaviour
    {
        private static QuestManager _instance;
        private int _numDroidItem;
        [SerializeField] private int _maxDriodItem = 3;
        [SerializeField] private TextMeshProUGUI _uiDroidItem;

        public static QuestManager Instance
        {
            get => _instance;
            set => _instance = value;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public void UpdateDroidItem()
        {
            if (_numDroidItem >= _maxDriodItem) return;
            _numDroidItem++;
            _uiDroidItem.text = _numDroidItem.ToString() + " / " + _maxDriodItem.ToString();
            CheckQuestComplete();
        }

        private void CheckQuestComplete()
        {
            if (_numDroidItem >= _maxDriodItem)
            {
                print("Quest 'Droid Items' Completed");
            }
        }
    }    
}

