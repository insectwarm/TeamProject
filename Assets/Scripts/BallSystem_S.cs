using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using Unity.Collections;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using System.Collections;

public class BallSystem_S : MonoBehaviour
{
    private List<GameObject> list;
    private Dictionary<string, int> amount = new Dictionary<string, int>()
    {
        { "RANK1", 3 },
        { "RANK2", 3 },
        { "RANK3", 3 },
        { "RANK4", 3 },
        { "RANK5", 2 },
        { "RANK6", 2 },
        { "RANK7", 2 },
        { "RANK8", 2 },
        { "RANK9", 1 },
        { "RANK10", 1 },
    };
    private int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        list = new List<GameObject>();
        StartCoroutine(LoadPrefabs());
    }

    private IEnumerator LoadPrefabs()
    {
        AsyncOperationHandle<IList<GameObject>> opHandle = Addressables.LoadAssetsAsync<GameObject>("PlayerPrefabs", null);
        yield return opHandle;

        if(opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (GameObject prefab in opHandle.Result)
            {
                int copies = 0;

                if (amount.ContainsKey(prefab.name))
                {
                    copies = amount[prefab.name];
                }

                for (int i = 0; i < copies; i++)
                {
                    list.Add(prefab);
                }
            }

            Shuffle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    private void Shuffle()
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp;
            temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    private void Draw()
    {
        GameObject gameObject = GameObject.FindWithTag("Player");
        Shooting_S Shooting = FindFirstObjectByType<Shooting_S>();
        if (gameObject == null)
        {
            if (count < list.Count && list[count] != null && Shooting.spawnCheck)
            {
                GameObject prefab = list[count];
                GameObject instance = Instantiate(prefab, GameObject.Find("Start Point").transform.position, Quaternion.identity);
                instance.tag = "Player";
                count++;
            }
            else return;
        }
    }
}
