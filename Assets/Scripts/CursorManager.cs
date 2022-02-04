using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    // Start is called before the first frame update
    void Start()
    {
        SetCursorState(cursorLocked);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
