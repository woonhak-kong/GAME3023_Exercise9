using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class CustomAudio
{
    public AudioClip audioClip;
    public string name;

}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    //public Sound[] sounds;
    public CustomAudio[] backgroundSoundClips;
    public CustomAudio[] effectSoundClips;

    public AudioSource bgm1;
    public AudioSource bgm2;
    //public AudioSource[] sounds;
    public List<AudioSource> soundSources;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        bgm1 = gameObject.AddComponent<AudioSource>();
        bgm2 = gameObject.AddComponent<AudioSource>();
        bgm1.volume = 0.0f;
        bgm2.volume = 0.0f;
        //foreach(var sound in sounds)
        //{
        //    sound.source = gameObject.AddComponent<AudioSource>();
        //    sound.source.clip = sound.clip;
        //    sound.source.volume = sound.volume;
        //    sound.source.pitch = sound.pitch;
        //    sound.source.loop = sound.loop;
        //}
        // master volume
        //AudioListener.volume = 0.02f;


    }


    public void Play(string name)
    {
        //AudioClip sound = Array.Find(soundClips, sound => sound.name == name);

        //if (sound == null)
        //{
        //    Debug.Log("Sound " + name + " is missing");
        //    return;
        //}
        //sound.source.Play();
    }

    public void PlayBgm(string audioName, float fadeDuration = 0.1f)
    {
        if (fadeDuration == 0.0f)
        {
            return;
        }
        StopAllCoroutines();
        CustomAudio sound = Array.Find(backgroundSoundClips, source => source.name == audioName);

        if(bgm1.isPlaying)
        {
            bgm2.clip = sound.audioClip;
            StartCoroutine(PlaySoundFadeIn(bgm2, fadeDuration));
            StartCoroutine(StopSoundFadeIn(bgm1, fadeDuration));

        }
        else if(bgm2.isPlaying)
        {
            bgm1.clip = sound.audioClip;
            StartCoroutine(PlaySoundFadeIn(bgm1, fadeDuration));
            StartCoroutine(StopSoundFadeIn(bgm2, fadeDuration));
        }
        else
        {
            bgm1.clip = sound.audioClip;
            StartCoroutine(PlaySoundFadeIn(bgm1, fadeDuration));
        }

        // play clip by fade in
        


        // stop clip if there audio is playing.

        
        
    }

    private IEnumerator PlaySoundFadeIn(AudioSource source, float duration)
    {
        //float cofactor = 1.0f / (duration * 100.0f);
        //float cofactor = 1.0f * Time.deltaTime / duration;
        //source.volume = 0.0f;
        source.loop = true;
        source.Play();

        float factor = 0.01f / (duration * 2.0f);

        float tmpVolume = source.volume;
        while(true)
        {
            yield return new WaitForSeconds(factor);
            tmpVolume += factor;
            source.volume = tmpVolume;
            if (source.volume >= 1.0f)
            {
                break;
            }
        }
    }

    private IEnumerator StopSoundFadeIn(AudioSource source, float duration)
    {
        //float cofactor = 1.0f / (duration * 100.0f);
        //float cofactor = 1.0f * Time.deltaTime / duration;
        //source.Play();
        //source.volume = 1.0f;

        float factor = 0.01f / (duration * 2.0f);

        float tmpVolume = source.volume;
        while (true)
        {
            yield return new WaitForSeconds(factor);
            tmpVolume -= factor;
            source.volume = tmpVolume;
            if (source.volume <= 0.0f)
            {
                source.Stop();
                break;
            }
        }
    }

    //public void StopAllSounds()
    //{
    //    foreach(var sound in sounds)
    //    {
    //        sound.source.Stop();
    //    }
    //}


}
