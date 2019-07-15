using UnityEngine;
using UnityEngine.UI;

using GooglePlayGames.BasicApi;
using GooglePlayGames;



public class PlayServiceScript : MonoBehaviour
{


    public void ShowAchievements()
    {
        GetComponent<AudioSource>().Play();
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }


    public void ShowLeaderboards()
    {
        GetComponent<AudioSource>().Play();
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }


}
