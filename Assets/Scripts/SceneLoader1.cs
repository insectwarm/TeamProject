using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader1: MonoBehaviour
{
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}