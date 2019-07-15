using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int numButton;
    public GamePlay gamePlay;
    public void CheckSelectedButton()
    {
        GetComponent<AudioSource>().Play();
        gamePlay.checkSelectedButton=numButton;
    }

}
