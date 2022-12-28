using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MetronomeV2 : MonoBehaviour
{
    public float bpm = 120f;
    float beatTempo;
    public GameObject metronome;
    public GameObject CompleteWindow;
    public float allCatchedBeats = 0f;
    public bool hasStarted = false;
    public Text words;
    public Text startWords;

    // public BeatCatcher bc;
    public int allBeats;
    // Start is called before the first frame update
    void Start()
    {
        CompleteWindow.SetActive(false);
        allBeats = GameObject.Find("NoteList").transform.childCount;
        // bc = GameObject.Find("CatchZone").GetComponent<BeatCatcher>();
        beatTempo = bpm / 60f;
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
                hasStarted = true;
                startWords.text = "";
                Instantiate(metronome, new Vector3(0, -6, 0), Quaternion.identity);
            }
        } else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
