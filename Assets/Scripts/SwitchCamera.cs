using UnityEngine;
using Cinemachine;
using StarterAssets;

public class SwitchCamera : MonoBehaviour
{
    [Header("Cinemachine Cameras")]
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;
    public int camPriorityMax = 10;
    public int camPriorityMin = 1;

    private FirstPersonController _firstPersonController;
    private ThirdPersonController _thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        _firstPersonController = GetComponent<FirstPersonController>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (firstPersonCamera.Priority == camPriorityMax)
            {

                SwitchCam(thirdPersonCamera, firstPersonCamera);
                _firstPersonController.enabled = false;
                _thirdPersonController.enabled = true;
            }
            else
            {
                SwitchCam(firstPersonCamera, thirdPersonCamera);
                _firstPersonController.enabled = true;
                _thirdPersonController.enabled = false;
            }
        }
    }

    private void SwitchCam(CinemachineVirtualCamera cameraOn, CinemachineVirtualCamera cameraOff)
    {
        cameraOff.Priority = camPriorityMin;
        cameraOn.Priority = camPriorityMax;
    }
}
