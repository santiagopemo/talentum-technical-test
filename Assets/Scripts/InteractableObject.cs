using UnityEngine;
using Cinemachine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Cinemachine Camera")]
    public CinemachineFreeLook freeLookCamera;

    [Header("Text UI Objects")]
    public GameObject interactionKeyText;
    public TextMeshProUGUI objectInfoTextUI;

    [Header("Object Description")]
    [TextArea]
    public string objectInfoText;

    [Header("Audio")]
    public AudioClip audioClip;

    private bool _isInteracting = false;
    private bool _isAvailableToInteract = false;
    private GameObject _player = null;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAvailableToInteract && Input.GetKeyDown(KeyCode.F) && !_isInteracting)
        {
            interactionKeyText.SetActive(false);
            freeLookCamera.Priority = 15;
            _player.SetActive(false);
            _isInteracting = true;
            objectInfoTextUI.text = objectInfoText;
            objectInfoTextUI.gameObject.SetActive(true);
        }
        else if (_player != null && Input.GetKeyDown(KeyCode.F) && _isInteracting)
        {
            interactionKeyText.SetActive(true);
            _player.SetActive(true);
            freeLookCamera.Priority = 1;
            _isInteracting = false;
            objectInfoTextUI.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactionKeyText.SetActive(true);
            _isAvailableToInteract = true;
            _player = other.gameObject;

            if (audioClip)
            {
                _audioSource.PlayOneShot(audioClip);
            }
        }
        
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactionKeyText.SetActive(false);
            _isAvailableToInteract = false;
            _player = null;
        }
    }
}
