using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private int liveGame;
    int saveLive, saveLv;

    public Text textLive;
    public Text textTarget;
    public int targetCoint;
    public int cointCollect;
    public GameObject AlertUI;
    public GameObject PanelUI;
    public GameObject pauseUI;
    public GameObject confirmExit;
    public GameObject confirmExitGameComplete;
    public GameObject panelGameComple;
    public GameObject panelGameOver;
    public GameObject Player;

    public bool Aler;
    public bool pause;

	// Use this for initialization
	void Start () {

        liveGame = SaveManager.instance.state.live;

    }
	
	// Update is called once per frame
	void Update () {
        textLive.text = ": "+ SaveManager.instance.state.live.ToString();
        textTarget.text = cointCollect + " / " + targetCoint;
        alertClearGame();
        gameOver();
        
	}

    public void gameOver()
    {
        if (SaveManager.instance.state.live <= 0)
        {
            PanelUI.SetActive(true);
            panelGameOver.SetActive(true);
            Player.SetActive(false);
            SaveManager.instance.LevelReset();
        } 
    }

    public void gameComplete()
    {
        PanelUI.SetActive(true);
        panelGameComple.SetActive(true);
    }

    public void gameOverUI()
    {
        PanelUI.SetActive(true);
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void btnRestar(int index)
    {
        
        StartCoroutine(LoadAsynchronously(index));
    }

    public void btnPause()
    {
        pause = !pause;
        if (pause)
        {
            PanelUI.SetActive(true);
            pauseUI.SetActive(true);
            Time.timeScale = 0;

        } else
        {
            PanelUI.SetActive(false);
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void btnPlay()
    {
        PanelUI.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void btnNextLevel()
    {
        int index = SaveManager.instance.state.level+1;
        PanelUI.SetActive(false);
        panelGameComple.SetActive(false);
        StartCoroutine(LoadAsynchronously(index));
        Time.timeScale = 1;
    }

    public void btnExit()
    {
        pauseUI.SetActive(false);
        panelGameComple.SetActive(false);
        panelGameOver.SetActive(false);
        confirmExit.SetActive(true);
    }

    public void btnExitGameComplete()
    {
        panelGameComple.SetActive(false);
        confirmExitGameComplete.SetActive(true);
    }

    public void btnNoExitGameComplete()
    {
        confirmExitGameComplete.SetActive(false);
        panelGameComple.SetActive(true);
    }

    public void btnYesExit(int index)
    {
        PanelUI.SetActive(false);
        confirmExit.SetActive(false);
        StartCoroutine(LoadAsynchronously(index));
        Time.timeScale = 1;
        SaveManager.instance.state.live = liveGame;
        SaveManager.instance.Save();
    }

    public void btnExitGameOver(int index)
    {
        PanelUI.SetActive(false);
        panelGameOver.SetActive(false);
        StartCoroutine(LoadAsynchronously(index));
        Time.timeScale = 1;
    }

    public void btnNoExit()
    {
        confirmExit.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void alertClearGame()
    {
        if(Aler == true)
        {
            AlertUI.SetActive(true);

        } else
        {
            AlertUI.SetActive(false);
        }
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
