using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOnClicks : MonoBehaviour
{
    public GameObject nmsWindow;
    public Transform ButtonPrefab;
    private int buttonCount;

    private string[] midis = { "beat2-1", "AllNote120", "AllNote60" };

    // void Start() {
    //     buttonCount = 1;

    //     foreach (var midi in midis)
    //     {
    //         Instantiate(ButtonPrefab, new Vector3(0f, -0.2f-(0.125f * buttonCount), 1.95f), Quaternion.identity).transform.parent = this.transform;
    //         buttonCount = buttonCount + 1;
    //     }
    // }

    public void LessonsMenuScene() {
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }
    public void SettingsScene() {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
    public void Exit() {
        Application.Quit();
    }
    public void LessonLoader(string MidiName) {
        if(MidiName != "beat2-1") {
            if (PlayerPrefs.GetInt("StarsFor" + MidiName) < 3 ) {
                nmsWindow.SetActive(true);
            } else {
                PlayerPrefs.SetString("LessonName", MidiName);
                PlayerPrefs.Save();
                SceneManager.LoadScene("LessonPrototype", LoadSceneMode.Single);
            }
            
        } else {
            PlayerPrefs.SetString("LessonName", "beat2-1");
            PlayerPrefs.Save();
            SceneManager.LoadScene("LessonPrototype", LoadSceneMode.Single);
        } 
        if(!PlayerPrefs.HasKey("Lesson" + MidiName + "Stars")) {
            PlayerPrefs.SetInt("Lesson" + MidiName + "Stars", 0);
            PlayerPrefs.Save();
        }
    }
}
