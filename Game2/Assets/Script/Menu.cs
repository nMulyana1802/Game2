using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    // Use this for initialization
    void Start () {

        //Debug.Log(SaveManager.instance.state.live.ToString());
        //Debug.Log(SaveManager.instance.state.level.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void LvUp()
    //{
    //    SaveManager.instance.LevelUP();
    //}


    public void btnPlayGame()
    {
        int index = SaveManager.instance.state.level +1;
        print(index);
        StartCoroutine(LoadAsynchronously(index));
    }

    public void btnSetting()
    {

    }

    public void btnExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

}
