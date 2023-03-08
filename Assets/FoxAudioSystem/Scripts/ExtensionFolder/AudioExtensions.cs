using System.Collections;
using FoxAudioSystem.Scripts.DataFolder;
using UnityEngine;

namespace FoxAudioSystem.Scripts.ExtensionFolder
{
  public static class AudioExtensions
  {
    public static void GenerateAudioSource(this AudioData audioData, GameObject gameObject)
    {
      AudioSource source = gameObject.GetComponent<AudioSource>();

      if (source == null)
        source = gameObject.AddComponent<AudioSource>();

      source.tag = "Audio";
      source.clip = audioData.clip;
      source.outputAudioMixerGroup = audioData.outputAudioMixerGroup;
      source.playOnAwake = audioData.playOnAwake;
      source.loop = audioData.loop;
      source.volume = audioData.volume;
      source.spatialBlend = audioData.spacialBlend;
      source.pitch = audioData.pitch;
      source.minDistance = audioData.minDistance;
      source.maxDistance = audioData.maxDistance;
      source.rolloffMode = audioData.rolloffMode;
    }

    public static IEnumerator FadeIn(this AudioSource audioSource, float duration)
    {
      float currentTime = 0f;
      float start = 0f;
      float volume = audioSource.volume;
      audioSource.Play();
      while (currentTime < duration)
      {
        currentTime += Time.unscaledDeltaTime;
        audioSource.volume = Mathf.Lerp(start, volume, currentTime / duration);
        yield return null;
      }
    }

    public static IEnumerator FadeOut(this AudioSource audioSource, float duration)
    {
      float currentTime = 0f;
      float volume = audioSource.volume;
      float start = volume;
      while (currentTime < duration)
      {
        currentTime += Time.unscaledDeltaTime;
        audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
        yield return null;
      }
      audioSource.Stop();
      audioSource.volume = volume;
    }
  }
}