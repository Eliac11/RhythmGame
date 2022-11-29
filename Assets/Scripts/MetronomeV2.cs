using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetronomeV2 : MonoBehaviour
{
    public float bpm = 120f;
    float beatTempo;
    public bool hasStarted = false;
    public Text words;
    public BeatCatcher bc;
    public float speed = 100f;
    public int allBeats;
    // Start is called before the first frame update
    void Start()
    {
        allBeats = GameObject.Find("NoteList").transform.childCount;
        bc = GameObject.Find("CatchZone").GetComponent<BeatCatcher>();
        beatTempo = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("NoteList").transform.childCount == 0) {
           words.text = (bc.SendNumbers() + "/" + allBeats).ToString(); 
        }
       if(!hasStarted) {
        if(Input.anyKeyDown) {
            hasStarted = true;
            words.text = "";
        }
       } else {
            transform.position -= new Vector3(beatTempo * Time.deltaTime* speed, 0f, 0f);
       }
    }
}
