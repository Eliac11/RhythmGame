using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteMenu : MonoBehaviour {

    public Text percentage;
    public Text result;
    public Text tiles;
    public int allBeats;
    public float allCatchedBeats = 0f;
    public Sprite activestar;
    public int stars;
    public int starsNew;
    public string LessonNum;
    
    public void ReturnToLessons() {
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }

    void Start() {
        stars = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "Stars");
        LessonNum = SceneManager.GetActiveScene().name.Remove(0, 6);
        allBeats = GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats; 
    }


    void Update() {
        allCatchedBeats = GameObject.Find("CatchZone1").GetComponent<CatchZone>().SendNumbers() +  
                            GameObject.Find("CatchZone2").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone3").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone4").GetComponent<CatchZone>().SendNumbers();
        if(GameObject.Find("NoteList").transform.childCount == 0) {
           tiles.text = "Tiles Tapped: " + allCatchedBeats.ToString() + "/" + allBeats.ToString();
           percentage.text = "Complete Percent: " + Mathf.RoundToInt((allCatchedBeats/allBeats)*100);
           if( Mathf.RoundToInt((allCatchedBeats/allBeats))*100 >= 66) {
                for (int i = 1; i < 4; i++) {
                    GameObject.Find("Star" + i.ToString()).GetComponent<SpriteRenderer>().sprite = activestar;
                    starsNew = 3;
                }
           } else if(Mathf.RoundToInt((allCatchedBeats/allBeats))*100 >= 33 && Mathf.RoundToInt((allCatchedBeats/allBeats))*100 < 66) {
                for (int i = 1; i < 3; i++) {
                    GameObject.Find("Star" + i.ToString()).GetComponent<SpriteRenderer>().sprite = activestar;
                    starsNew = 2;
                }
           } else if(Mathf.RoundToInt((allCatchedBeats/allBeats))*100 < 33) {
                    GameObject.Find("Star1").GetComponent<SpriteRenderer>().sprite = activestar;
                    starsNew = 1;
            }
        }
        if (PlayerPrefs.GetInt("Lesson" + LessonNum + "Stars") <= starsNew)
        {
            PlayerPrefs.SetInt("Lesson" + LessonNum + "Stars", starsNew);

            Debug.Log(LessonNum);
        }
    }
}
