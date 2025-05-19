using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneLoader : MonoBehaviour
{
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("Stage Select");
    }
}