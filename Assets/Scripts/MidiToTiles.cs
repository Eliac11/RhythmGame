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

    void Start()
    {
        var midiFile = MidiFile.Read("./Assets/MIDIs/" + MidiName + ".mid");
        Debug.Log(midiFile.GetNotes());

        foreach (var note in midiFile.GetNotes())
        {
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
