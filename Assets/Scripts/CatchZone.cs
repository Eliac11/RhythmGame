using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CatchZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip clip;
    public bool btnClick;
    public void OnPointerDown(PointerEventData eventData){
        btnClick = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        btnClick = false;
    }
    public float SendNumbers() {
        return beatCount;
    }
    void BeatMaker(Collider2D other) {
    }
    float beatCount = 0f;
    public KeyCode keyToPress;
    void OnTriggerStay2D(Collider2D other) {
        if(btnClick || Input.GetKeyDown(keyToPress)) {
            audioSource.PlayOneShot(clip, 0.5f);
            if(other.gameObject.tag == "BeatMark") {
                beatCount++;
                Destroy(other.gameObject);
                GameObject.Find("NoteList").GetComponent<MetronomeV2>().words.text = "Well Done!";
                // Debug.Log("Well Done!!!" + SendNumbers() + "/" + GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats);
            }
        }
    }
}
