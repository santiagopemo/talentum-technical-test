using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Image fadeOutImage;

    private bool _startFadeOut = false;
    
    // Update is called once per frame
    void Update()
    {
        if (_startFadeOut)
        {
            Color imageColor = fadeOutImage.color;
            imageColor.a += 0.02f;
            fadeOutImage.color = imageColor;
        }
        if (fadeOutImage.color.a >= 2)
        {
            SceneManager.LoadScene("Scenario");
        }
    }

    public void DoLogIn()
    {
        if (!_startFadeOut) 
        {
            PlayerPrefs.SetString("PlayerName", playerNameInput.text);
            _startFadeOut = true;
        }
    }
}
