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
    public void LessonLoader(string LessonNum) {
        SceneManager.LoadScene("Lesson" + LessonNum, LoadSceneMode.Single);
    }
}
