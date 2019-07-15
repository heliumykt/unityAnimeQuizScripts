using UnityEngine;
using GooglePlayGames;

public class LoggedScript : MonoBehaviour
{
    public GameObject notLoggedInText;

    void Start()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            notLoggedInText.SetActive(true);
        }
    }

 
}
