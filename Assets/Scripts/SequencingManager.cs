using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencingManager : MonoBehaviour
{
    public Transform menuCameraTransform, gameCameraTransform;
    public static bool isGameRunning;
    public Animator menuAnimator;
    public Animator gameUIAnimator;
    public Transform camera;
    public float cameraSpeed;

    void Start()
    {
        isGameRunning = false;
        camera.position = menuCameraTransform.position;
        camera.rotation = menuCameraTransform.rotation;
    }

    void Update()
    {
        if (!isGameRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        Transform target = isGameRunning ? gameCameraTransform : menuCameraTransform;
        camera.position = Vector3.Lerp(camera.position, target.position, Time.deltaTime * cameraSpeed);
        camera.rotation = Quaternion.Lerp(camera.rotation, target.rotation, Time.deltaTime * cameraSpeed);
    }

    void StartGame()
    {
        isGameRunning = true;
        menuAnimator.SetTrigger("Hide");
        gameUIAnimator.SetTrigger("Show");
    }
}
