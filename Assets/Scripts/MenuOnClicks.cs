using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOnClicks : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void LessonsMenuScene() {
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }
    public void SettingsScene() {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
    public void Exit() {
        Application.Quit();
    }
    public void LessonLoader(int LessonNum) {
        SceneManager.LoadScene("Lesson" + LessonNum.ToString(), LoadSceneMode.Single);
        PlayerPrefs.SetInt("Lesson" + LessonNum.ToString() + "Stars", 0);
        PlayerPrefs.SetInt("Lesson" + LessonNum.ToString() + "Number", LessonNum);
        PlayerPrefs.Save();
    }
}
