using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextStageLoader1 : MonoBehaviour
{
    public float waitTime = 3f;

    [SerializeField]
    private string _nextSceneName = "NextStage"; // フィールド名を _つきにして区別！

    void Start()
    {
        StartCoroutine(LoadNextStageAfterDelay());
    }

    IEnumerator LoadNextStageAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(_nextSceneName);
    }
}