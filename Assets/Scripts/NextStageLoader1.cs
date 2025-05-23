using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextStageLoader1 : MonoBehaviour
{
    public float waitTime = 3f;

    [SerializeField]
    private string _nextSceneName = "NextStage"; // �t�B�[���h���� _���ɂ��ċ�ʁI

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