using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SampleSceneManager : MonoBehaviour
{

    List<Dropdown.OptionData> optionDataList;

    void Start()
    {
        optionDataList = new List<Dropdown.OptionData>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; ++i) {
            string name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            optionDataList.Add(new Dropdown.OptionData(name));
        }

        GetComponentInChildren<Dropdown>().ClearOptions();
        GetComponentInChildren<Dropdown>().AddOptions(optionDataList);

        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;

        SceneManager.LoadScene(1, LoadSceneMode.Additive);

    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode) {

        if (mode == LoadSceneMode.Additive) {
            SceneManager.SetActiveScene(nextScene);
        }
    }

    public void LoadScene(int index) {
        Debug.Log("sceneName to load: " + index);
        //DontDestroyOnLoad(gameObject);
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(index, LoadSceneMode.Additive);

    }


    public void BackToMenu() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

}
