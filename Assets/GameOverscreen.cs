using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverscreen : MonoBehaviour
{
    public void Setup(int score)
    {
        gameObject.SetActive(true); // ✅ ใช้ g เล็ก + O ใหญ่
        // TODO: สามารถอัปเดตข้อความคะแนนหรือ UI ได้ตรงนี้
    }

        public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
