using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SoundGroup
{
    public string GroupID;
    public AudioClip[] Sounds;
}


public class SoundLibrary : ExtendedMonoBehaviour
{
    public AudioClip[] Sounds;
    public SoundGroup[] SoundGroups;

    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip[]> soundGroupDictionary = new Dictionary<string, AudioClip[]>();


    private void Awake()
    {
        foreach (AudioClip sound in Sounds)
        {
            soundDictionary.Add(sound.name, sound);
        }

        foreach (SoundGroup group in SoundGroups)
        {
            soundGroupDictionary.Add(group.GroupID, group.Sounds);
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            return soundDictionary[name];
        }

        return null;
    }

    public AudioClip GetClipFromGroup(string groupId)
    {
        if (soundGroupDictionary.ContainsKey(groupId))
        {
            AudioClip[] sounds = soundGroupDictionary[groupId];
            return sounds[UnityEngine.Random.Range(0, sounds.Length)];
        }

        return null;
    }
}
