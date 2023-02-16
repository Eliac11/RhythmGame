using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class CompleteMenu : MonoBehaviour {

    public Text percentage;
    public Text result;
    public Text tiles;
    public MidiToTiles MidiToTiles;
    public int allBeats;
    public float allCatchedBeats = 0f;
    public Sprite activestar;
    public Image memeWindow;
    public int stars;
    public int starsNew;
    public string LessonNum;
    public string PathToMemes; 
    public bool memeSet = false;

    private string[] midis = { "TestRoad", "AllNote120", "AllNote60" };
    
    public void ReturnToLessons() {
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }

    void Start() {
        stars = PlayerPrefs.GetInt("Lesson" + MidiToTiles.MidiName + "Stars");
        //Debug.Log(stars);
        LessonNum = SceneManager.GetActiveScene().name.Remove(0, 6);
    }


    void Update() {
        allCatchedBeats = GameObject.Find("CatchZone1").GetComponent<CatchZone>().SendNumbers() +  
                            GameObject.Find("CatchZone2").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone3").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone4").GetComponent<CatchZone>().SendNumbers();
        if(GameObject.Find("NoteList").transform.childCount == 0) {
            tiles.text = "Tiles Tapped: " + allCatchedBeats.ToString() + "/" + allBeats.ToString();
            percentage.text = "Complete Percent: " + Mathf.RoundToInt((allCatchedBeats/allBeats)*100);
            // Тута пиши
            if( Mathf.RoundToInt((allCatchedBeats/allBeats)*100) > 66) {
                for (int i = 1; i < 4; i++) {
                    GameObject.Find("Star" + i.ToString()).GetComponent<SpriteRenderer>().sprite = activestar;
                    starsNew = 3;
                }
                StartCoroutine(LoadImageFromURL(Application.streamingAssetsPath  + "/Memes/goodmeme" + UnityEngine.Random.Range(1,6).ToString() + ".png"));
                memeSet = true;
            } else if(Mathf.RoundToInt((allCatchedBeats/allBeats)*100) > 33 && Mathf.RoundToInt((allCatchedBeats/allBeats)*100) < 66) {
                for (int i = 1; i < 3; i++) {
                    GameObject.Find("Star" + i.ToString()).GetComponent<SpriteRenderer>().sprite = activestar;
                    starsNew = 2;
                }
                StartCoroutine(LoadImageFromURL(Application.streamingAssetsPath  + "/Memes/normalmeme" + UnityEngine.Random.Range(1,6).ToString() + ".png"));
                memeSet = true;
            } else if(Mathf.RoundToInt((allCatchedBeats/allBeats)*100) < 33) {
                GameObject.Find("Star1").GetComponent<SpriteRenderer>().sprite = activestar;
                starsNew = 1;
                StartCoroutine(LoadImageFromURL(Application.streamingAssetsPath  + "/Memes/badmeme" + UnityEngine.Random.Range(1,6).ToString() + ".png"));
                memeSet = true;
            }
        }
        if (stars < starsNew) {
            PlayerPrefs.SetInt("Lesson" + MidiToTiles.MidiName + "Stars", starsNew);
            PlayerPrefs.SetInt("StarsFor" + midis[Array.IndexOf(midis, MidiToTiles.MidiName) + 1], starsNew);
            PlayerPrefs.Save();
            // Debug.Log(MidiName);
        }
        // Debug.Log(PathToMemes);
    }
    public IEnumerator LoadImageFromURL(string url) {
        if (!memeSet) {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
            memeWindow.sprite = sprite;  
            Debug.Log("Ive loaded a picture");
        }
    }
}

