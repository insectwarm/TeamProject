using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageLoader : MonoBehaviour
{
    public string loadingSceneName = "LoadingScene";
    public string nextSceneName;

    public static string sceneToLoad;  // ���[�h�ΏۃV�[����ۑ�

    public void LoadNextStage()
    {
        sceneToLoad = nextSceneName;
        SceneManager.LoadScene(nextSceneName);
    }
    public void LoadLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}