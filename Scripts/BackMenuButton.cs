using UnityEngine;

public class BackMenuButton : MonoBehaviour
{
    public GameObject SettingsPanel;
    public void BackButton()
    {
        GetComponent<AudioSource>().Play();
        SettingsPanel.SetActive (false);
    }

}
