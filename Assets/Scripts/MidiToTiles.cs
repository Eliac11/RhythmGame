using System;
using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;

public class MidiToTiles : MonoBehaviour
{
    public string MidiName;
    public Transform notePrefab;
    public CompleteMenu CompleteMenu;
    private float notePos;

    void Start()
    {
        if (MidiName == "AutoMidi") {
            MidiName = PlayerPrefs.GetString("LessonName", "nothing");
        }

        Debug.Log(Application.dataPath);

        var midiFile = MidiFile.Read("Assets/StreamingAssets/" + MidiName + ".mid");

        CompleteMenu.allBeats = midiFile.GetNotes().Count;

        foreach (var note in midiFile.GetNotes())
        {
            notePos = Convert.ToSingle(Convert.ToDouble(note.Time) / 60);

            switch (note.NoteNumber)
            {
                case 36:
                    Instantiate(notePrefab, new Vector3(-2.1f, notePos, 0), Quaternion.identity).transform.parent = this.transform;
                    break;
                case 38:
                    Instantiate(notePrefab, new Vector3(-0.7f, notePos, 0), Quaternion.identity).transform.parent = this.transform;
                    break;
                case 40:
                    Instantiate(notePrefab, new Vector3(0.7f, notePos, 0), Quaternion.identity).transform.parent = this.transform;
                    break;
                case 41:
                    Instantiate(notePrefab, new Vector3(2.1f, notePos, 0), Quaternion.identity).transform.parent = this.transform;
                    break;
                default:
                    Debug.Log("А почему в midi файле есть нота " + note);
                    break;
            }

            Debug.Log($@"
                note {note} (note number = {note.NoteNumber})
                time = {note.Time}
                length = {note.Length}
                velocity = {note.Velocity}
                off velocity = {note.OffVelocity}");
        }
    }

    void Update()
    {
        
    }
}
