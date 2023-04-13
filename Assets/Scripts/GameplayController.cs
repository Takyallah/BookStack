using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    public BookSpawner bookSpawner;

    [HideInInspector]
    public BookScript currentBook;

    public CameraFollow cameraScript;
    public int moveCount;

    void Awake()
    {

        if (instance == null) instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {

        bookSpawner.SpawnBook();
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
        
    }

    void DetectInput() {

        if (Input.GetMouseButtonDown(0))
        {
            currentBook.DropBook();
        }

    }

    public void SpawnNewBook()
    {
        Invoke("NewBook", 1f);
    }

    void NewBook()
    {
        bookSpawner.SpawnBook();
    }

    public void MoveCamera()
    {
        moveCount++;

        if (moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 300f;
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
