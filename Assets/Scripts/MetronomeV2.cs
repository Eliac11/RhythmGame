using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MetronomeV2 : MonoBehaviour
{
    public string MusicName;

    public double bpm = 120;
    float beatTempo;
    public GameObject metronome;
    public GameObject CompleteWindow;
    public float allCatchedBeats = 0f;
    public bool hasStarted = false;
    public Text words;
    public Text startWords;
    public string musicFileName;
    // Для звука
    public AudioSource audioSource;
    public AudioClip clip;
    public bool hasLoaded = false;
    public bool isPlaying = false;

    // Для сообщения
    public string message1 = "Ты просто посмотри! Я набрал ";
    public string message2 = " очков в In Valid Rhythm! А ты сможешь также?! ";
    public string url = "*ссылка на In Valid Rhythm*";


    // public BeatCatcher bc;
    public int allBeats;
    void PlayMusic(bool isPlaying) {
        if (!isPlaying) {
            audioSource.PlayOneShot(clip, 0.25f);
        }
    }  
    // Start is called before the first frame update
    void Start()
    {
        if (MusicName == "AutoMidi") {
            MusicName = PlayerPrefs.GetString("LessonName", "nothing");
        }

        CompleteWindow.SetActive(false);
        allBeats = GameObject.Find("NoteList").transform.childCount;
        // bc = GameObject.Find("CatchZone").GetComponent<BeatCatcher>();
        beatTempo = Convert.ToSingle(bpm) / 60f;
        // Слава пути тут делай, ес чо
        // Я пометку сделал, я умничка :3
        
        // Спасибо, милый <3
        StartCoroutine(GetAudioClip(Application.streamingAssetsPath  + "/Music/" + MusicName + ".mp3"));
        audioSource.clip = clip;
        hasLoaded = true;
    }
    IEnumerator waiter(int secs) {
        CompleteWindow.SetActive(true);
        yield return new WaitForSecondsRealtime(secs);
    }
    void Update(){
        if(GameObject.Find("NoteList").transform.childCount == 0) {
           StartCoroutine(waiter(3));
        }
        if(!hasStarted) {
            if(Input.anyKeyDown) {
                beatTempo = Convert.ToSingle(bpm) / 60f;
                hasStarted = true;
                startWords.text = "";
                PlayMusic(isPlaying);
                isPlaying = true;
                Instantiate(metronome, new Vector3(0, -6, 0), Quaternion.identity);
            }
        } else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
    IEnumerator GetAudioClip(string fullPath) {
        if (!hasLoaded) {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(fullPath, AudioType.MPEG)) {
                yield return www.SendWebRequest();
                if (www.isNetworkError || www.isHttpError) {
                    Debug.Log(www.error);
                } else {
                    clip = DownloadHandlerAudioClip.GetContent(www);  
                    Debug.Log("Loaded Clip uwu");
                }
            }
        } 
    }

    public void Share()
    {
        StartCoroutine(ShareRoutine());
    }

    private IEnumerator ShareRoutine()
    {
        yield return new WaitForEndOfFrame();

        string shareText = message1 + CompleteWindow.GetComponent<CompleteMenu>().allCatchedBeats + "/" + CompleteWindow.GetComponent<CompleteMenu>().allBeats + message2 + url;
        new NativeShare().SetText(shareText).Share();
    }
}
