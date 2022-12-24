using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchZone : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float SendNumbers() {
        return beatCount;
    }
    float beatCount = 0f;
    public KeyCode keyToPress;

    void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKeyDown(keyToPress)) {
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
