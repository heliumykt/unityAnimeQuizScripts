using UnityEngine;

public class MusicSettingsButton : MonoBehaviour
{
    public int volumeMusic;

    public void MusicSettings()
    {
        GetComponent<AudioSource>().Play();
        AudioListener.volume = volumeMusic;
    }
}
