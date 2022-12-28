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
    
    public void ReturnToLessons() {
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }

    void Start() {
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
        }
    }
}
