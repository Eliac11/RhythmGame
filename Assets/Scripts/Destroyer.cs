using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool del;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "BeatMark"){
            if (del){
                Destroy(other.gameObject);
            } else {
                GameObject.Find("NoteList").GetComponent<MetronomeV2>().words.text = "Miss :(";
            }
        }
    }
}
