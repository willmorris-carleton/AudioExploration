using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class AudioManager : Singleton<AudioManager>
{
    public EventReference footsteps;

    List<EventInstance> eventInstances = new List<EventInstance>();

    public EventInstance CreateEventInstance(EventReference eventReference) {
        EventInstance e = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(e);
        return e;
    }

    void OnDestroy() {
        foreach (EventInstance eventInstance in eventInstances) {
            eventInstance.release();
        }
    }

    public void SetGlobalLabelParameter(string name, string label) {
        RuntimeManager.StudioSystem.setParameterByNameWithLabel(name, label);
    }
}
