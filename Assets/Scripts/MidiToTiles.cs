using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;
using UnityEngine.Networking;

public class MidiToTiles : MonoBehaviour
{
    public string MidiName;

    public Transform notePrefab;

    public RectTransform CZ1;
    public RectTransform CZ2;
    public RectTransform CZ3;
    public RectTransform CZ4;

    public CompleteMenu CompleteMenu;
    public MetronomeV2 Metronome;

    private float notePos;

    void Start()
    {
        if (MidiName == "AutoMidi") {
            MidiName = PlayerPrefs.GetString("LessonName", "nothing");
        }
        
        string filePath = System.IO.Path.Combine("file://" + Application.streamingAssetsPath, MidiName + ".mid");
        LoadMidiFile(filePath);
    }

    void LoadMidiFile(string filePath)
    {
        UnityWebRequest www = UnityWebRequest.Get(filePath);
        Debug.Log(filePath);
        www.SendWebRequest();

        while (!www.isDone) {}

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error loading MIDI file: " + www.error);
        }
        else
        {
            byte[] midiData = www.downloadHandler.data;
            MemoryStream stream = new MemoryStream(midiData);
            MidiFile midiFile = MidiFile.Read(stream);
            TempoMap tempoMap = midiFile.GetTempoMap();

            CompleteMenu.allBeats = midiFile.GetNotes().Count;

            Metronome.bpm = tempoMap.GetTempoAtTime((MidiTimeSpan)0).BeatsPerMinute;

            string MfilePath = Application.dataPath + "/Resources/" + MidiName + ".mp3";
            Metronome.musicFileName = MfilePath;
                var audioSource = GetComponent<AudioSource>();
                AudioClip musicClip = Resources.Load<AudioClip>(Metronome.musicFileName);
                if (musicClip != null)
                {
                    audioSource.clip = musicClip;
                }
                else
                {
                    Debug.LogError("Failed to load music clip: " + Metronome.musicFileName);
                }

            foreach (var note in midiFile.GetNotes())
            {
                notePos = Convert.ToSingle(Convert.ToDouble(note.Time) / 60);

                switch (note.NoteNumber)
                {
                    case 36:
                        Instantiate(notePrefab, new Vector2(CZ1.position.x, notePos), Quaternion.identity).transform.parent = this.transform;
                        break;
                    case 38:
                        Instantiate(notePrefab, new Vector2(CZ2.position.x, notePos), Quaternion.identity).transform.parent = this.transform;
                        break;
                    case 40:
                        Instantiate(notePrefab, new Vector2(CZ3.position.x, notePos), Quaternion.identity).transform.parent = this.transform;
                        break;
                    case 41:
                        Instantiate(notePrefab, new Vector2(CZ4.position.x, notePos), Quaternion.identity).transform.parent = this.transform;
                        break;
                    default:
                        Debug.Log("А почему в midi файле есть нота " + note + "?");
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
    }
}
