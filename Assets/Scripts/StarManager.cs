using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int stars;
    public string MidiName;
    public Sprite activestar;

    public Transform Star1;
    public Transform Star2;
    public Transform Star3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stars = PlayerPrefs.GetInt("Lesson" + MidiName + "Stars");
        // Debug.Log(stars);
        switch (stars) {
            case 1:
                Star1.GetComponent<SpriteRenderer>().sprite = activestar;
                break;

            case 2:
                Star1.GetComponent<SpriteRenderer>().sprite = activestar;
                Star2.GetComponent<SpriteRenderer>().sprite = activestar;
                break;

            case 3:
                Star1.GetComponent<SpriteRenderer>().sprite = activestar;
                Star2.GetComponent<SpriteRenderer>().sprite = activestar;
                Star3.GetComponent<SpriteRenderer>().sprite = activestar;
                break;
        }
    }
}
