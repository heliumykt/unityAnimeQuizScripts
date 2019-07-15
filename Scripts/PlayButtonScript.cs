using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using GooglePlayGames;

public class PlayButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start(){
        Application.runInBackground = false;
        if(Monetization.isSupported) Monetization.Initialize("3205205", false);
    }

	public void PlayGame(){
        GetComponent<AudioSource>().Play();

        //ShowAds();
        ResetScene();
    }


	void ResetScene(){
		Application.runInBackground = true;
		SceneManager.LoadScene("Scenes/OnePunchManScene");
	}

    public void ResetGame()
    {
        GetComponent<AudioSource>().Play();

        if (Monetization.IsReady("video"))
        {
            ShowAdCallbacks options = new ShowAdCallbacks();
            options.finishCallback = HandleShowResult;
            ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
            ad.Show(options);
        }
        else
        {
            ResetScene();
        }

    }

    
    void HandleShowResult(ShowResult result){
        if(result == ShowResult.Finished){
        ResetScene();
        }
        else if (result == ShowResult.Skipped){
        ResetScene();
        }
        else if (result == ShowResult.Failed){
        ResetScene();
        }
    }

}
