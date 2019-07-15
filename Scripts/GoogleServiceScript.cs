using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class GoogleServiceScript : MonoBehaviour
{
    private Text authStatus;


    // Start is called before the first frame update
    void Start()
    {

        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        GooglePlayGames.PlayGamesPlatform.Activate ();

        // END THE CODE TO PASTE INTO START


        // ADD THESE LINES
        // Get object instances
        //signInButtonText = GameObject.Find("signInButton").GetComponentInChildren<Text>();
        authStatus = GameObject.Find("authStatus").GetComponent<Text>();

        // PASTE THESE LINES AT THE END OF Start()
        // Try silent sign-in (second parameter is isSilent)
        
        //вход
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            //PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            //signInButtonText.text = "Sign In";
            authStatus.text = "";
        }

        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    // Update is called once per frame
    void Update()
    {
        //achButton.SetActive(Social.localUser.authenticated);
    }



    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            //signInButtonText.text = "Sign out";

            // Show the user's name
            authStatus.text = "Signed in as: " + Social.localUser.userName;

            if (Social.localUser.authenticated)
            {
                // Unlock the "welcome" achievement, it is OK to
                // unlock multiple times, only the first time matters.
                PlayGamesPlatform.Instance.ReportProgress(
                GPGSIds.achievement_welcome_to_animebattlearena__onepunchman,
                100.0f, (bool success1) => {
                    Debug.Log("(AnimeQuiz Battle Arena: OnePunchMan) Welcome Unlock: " +
                    success1);
                });
            }

            Invoke("RunMainMenu",2);
        }
        else
        {
            Debug.Log("(AnimeQuiz Battle Arena: OnePunchMan) Sign-in failed...");

            // Show failure message
            //signInButtonText.text = "Sign in";
            authStatus.text = "Sign-in failed";
            Invoke("RunMainMenu",2);
        }
    }


    void RunMainMenu(){
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
