using UnityEngine;
using TMPro;

public class NameLabel : MonoBehaviour
{
    private TextMeshProUGUI _nameTxtUI;
    private string _playerName = null;

    // Start is called before the first frame update
    void Start()
    {
        _nameTxtUI = (TextMeshProUGUI) GetComponent<TMP_Text>();
        _playerName = PlayerPrefs.GetString("PlayerName", "NN");
        _nameTxtUI.text = _playerName;
    }
}
