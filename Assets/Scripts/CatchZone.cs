using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CatchZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public AudioSource audioSource;
    public Animator animator;
    public AudioClip clip;
    public bool btnClick;
    SpriteRenderer renderer; 
    
    void Start () {
        renderer = gameObject.GetComponent<SpriteRenderer>(); 
    }

    public void OnPointerDown(PointerEventData eventData){
        btnClick = true;
        renderer.color = new Color(0.78f, 0.78f, 0.78f, 1f);
    }
    public void OnPointerUp(PointerEventData eventData){
        btnClick = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
    public float SendNumbers() {
        return beatCount;
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
                animator.SetTrigger("ButtonPressed");
                // Debug.Log("Well Done!!!" + SendNumbers() + "/" + GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats);
            }
        }
    }
}
