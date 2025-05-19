using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public string sceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadNextStage()
    {
        SceneManager.LoadScene("NextScene"); // ← ここを次のステージ名に
    }
}
