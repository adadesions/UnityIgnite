using UnityEngine;

namespace Game.FirstGame.Scripts
{
    public class DroidItem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            QuestManager.Instance.UpdateDroidItem();
            Destroy(transform.parent.gameObject);
        }
    }
}
