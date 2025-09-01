using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerInput playerInput;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private PlayerController playerController;

    private InputAction upMove;
    private InputAction downMove;
    private InputAction shoot;
    private InputAction restart;
    private InputAction quit;

    private bool isMovingUp;
    private bool isMovingDown;
    private bool isShooting;

    private int lives;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upMove = playerInput.currentActionMap.FindAction("UpMovement");
        downMove = playerInput.currentActionMap.FindAction("DownMovement");
        shoot = playerInput.currentActionMap.FindAction("Attack");
        quit = playerInput.currentActionMap.FindAction("Quit");
        restart = playerInput.currentActionMap.FindAction("Restart");

        upMove.started += UpMove_started;
        upMove.canceled += UpMove_canceled;
        downMove.started += DownMove_started;
        downMove.canceled += DownMove_canceled;
        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
        restart.started += Restart_started;
        quit.started += Quit_started;
    }
    #region Input Actions
    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        isShooting = false;
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        isShooting = true;
    }

    private void DownMove_canceled(InputAction.CallbackContext obj)
    {
        isMovingDown = false;
    }

    private void DownMove_started(InputAction.CallbackContext context)
    {
        isMovingDown = true;
    }

    private void UpMove_canceled(InputAction.CallbackContext obj)
    {
        isMovingUp = false;
    }

    private void UpMove_started(InputAction.CallbackContext obj)
    {
        isMovingUp = true;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
