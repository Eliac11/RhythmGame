using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchZone4 : MonoBehaviour
{
    public float SendNumbers() {
        return beatCount;
    }
    float beatCount = 0f;
    public KeyCode keyToPress;
    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKey(keyToPress)) {
            
            if(other.gameObject.tag == "BeatMark") {
                beatCount++;
                Destroy(other.gameObject);
                Debug.Log("Well Done!!!" + SendNumbers() + "/" + GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats);
        }
        }
    }
}