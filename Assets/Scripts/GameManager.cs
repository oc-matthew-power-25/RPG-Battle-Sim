using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayerTurn = true;

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        Debug.Log("Player turn ended. Enemy's turn begins.");
        FindAnyObjectByType<EnemyAttack>().UseAttack();
    }

    public void EndEnemyTurn()
    {
        isPlayerTurn = true;
        Debug.Log("Enemy turn ended. Player's turn begins.");
    }

    public void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
