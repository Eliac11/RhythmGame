using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int stars;
    public int LessonNumb;
    public Sprite activestar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stars = PlayerPrefs.GetInt("Lesson" + LessonNumb.ToString() + "Stars");
        // Debug.Log(stars);
        for (int i = 1; i < stars+1; i++) {
            GameObject.Find("Lvl" + LessonNumb.ToString() + "Star" + i.ToString()).GetComponent<SpriteRenderer>().sprite = activestar;
        }
    }
}
