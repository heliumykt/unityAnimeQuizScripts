using UnityEngine;


public class SettingsButtonScript : MonoBehaviour
{
	public GameObject SettingsPanel;


    public void SettingsButton(){
        GetComponent<AudioSource>().Play();
	    SettingsPanel.SetActive (true);
	}
}
