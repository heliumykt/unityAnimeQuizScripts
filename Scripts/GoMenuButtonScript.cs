using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public class GoMenuButtonScript : MonoBehaviour
{
	void Start(){
		if(Monetization.isSupported) Monetization.Initialize("3205205", false);
	}
	public void GoMenu(){
        GetComponent<AudioSource>().Play();
		if(Monetization.IsReady("video")){
			ShowAdCallbacks options = new ShowAdCallbacks();
			//options.finishCallback = HandleShowResult;
			ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
			ad.Show(options);
		}
		SceneManager.LoadScene("Scenes/SampleScene");
	}
}
