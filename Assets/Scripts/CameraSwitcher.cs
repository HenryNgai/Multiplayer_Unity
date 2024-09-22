using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera headCamera; // Reference to the head camera
    public Camera mainCamera; // Reference to the main camera

    void Start()
    {
        // Start with only the main camera active
        SetActiveCamera(mainCamera);
    }

    void Update()
    {
        // Check for Insert key press to switch to head camera
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            SetActiveCamera(headCamera);
        }

        // Check for Delete key press to switch to main camera
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SetActiveCamera(mainCamera);
        }
    }

    void SetActiveCamera(Camera activeCamera)
    {
        // Deactivate both cameras
        headCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);

        // Activate the selected camera
        activeCamera.gameObject.SetActive(true);
    }
}
