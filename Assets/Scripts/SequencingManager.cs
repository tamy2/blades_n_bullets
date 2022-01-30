using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SequencingManager : MonoBehaviour
{
    public static SequencingManager instance;

    public Transform menuCameraTransform, gameCameraTransform;
    public static bool isGameRunning;
    public Animator menuAnimator;
    public Animator gameUIAnimator;
    public Transform camera;
    public float cameraSpeed;
    public float timeAlive;
    public TextMeshProUGUI timerReadout;
    public TextMeshProUGUI finalTimerReadout;
    private bool died;

    void Awake()
    {
        instance = this;

    }
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
        if (Vector3.Distance(target.position, camera.position) > 0.3f)
        {
            camera.position = Vector3.Lerp(camera.position, target.position, Time.deltaTime * cameraSpeed);
            camera.rotation = Quaternion.Lerp(camera.rotation, target.rotation, Time.deltaTime * cameraSpeed);
        }

        if (isGameRunning)
        {
            timeAlive += Time.deltaTime;
            timerReadout.text = timeAlive.ToString("F2");
            finalTimerReadout.text = timeAlive.ToString("F2");
        }

        if (died && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    void StartGame()
    {
        isGameRunning = true;
        menuAnimator.SetTrigger("Hide");
        gameUIAnimator.SetTrigger("Show");
    }

    public void End()
    {
        if (died)
        {
            return;
        }
        isGameRunning = false;
        gameUIAnimator.SetTrigger("Game Over");
        died = true;
    }
}
