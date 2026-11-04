using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void LeaveGame()
    {
        Debug.Log("Game is exiting...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
