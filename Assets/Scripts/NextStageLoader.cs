using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageLoader : MonoBehaviour
{
    public string nextSceneName;

    public void LoadNextStage()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}