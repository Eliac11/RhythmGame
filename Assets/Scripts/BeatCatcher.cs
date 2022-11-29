using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCatcher : MonoBehaviour
{
    public string SendNumbers() {
        return beatCount.ToString();
    }
    float beatCount = 0f;
    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKey(KeyCode.Space)) {
            
            if(other.gameObject.tag == "BeatMark") {
                beatCount++;
                Destroy(other.gameObject);
                Debug.Log("Well Done!!!" + SendNumbers() + "/" + GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats);
        }
        }
    }
}
