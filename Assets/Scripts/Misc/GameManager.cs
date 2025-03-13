using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const string ENEMIES_REMAINING = "Enemies:";

    [SerializeField] TMP_Text enemiesRemainingText;
    [SerializeField] GameObject youWinText;

    private int enemiesLeft = 0;

    public void AdjustRemainingEnemies(int amount)
    {
        enemiesLeft += amount;
        enemiesRemainingText.text = $"{ENEMIES_REMAINING} {enemiesLeft}";
        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
