using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        //ResetSave();
        DontDestroyOnLoad(gameObject);
        instance = this;
        Load();

    }


    public void Save()
    {
        PlayerPrefs.SetString("Save", Helper.Serialize<SaveState>(state));
    }



    public void Load()
    {
        // apakah sudah ada data yg tersimpan ? atau mengecek data
        if (PlayerPrefs.HasKey("Save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save, create new One!");
        }
    }

    public void LiveMinus()
    {
        state.live--;
        Save();
    }

    public void LivePlus()
    {
        state.live++;
        Save();
    }

    public void LevelUP()
    {
        state.level++;
        Save();
    }

    public void LevelReset()
    {
            state.live = 3;
            state.level = 1;
            Save();
    }

    // Reset the whole save file
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("Save");
    }

}
