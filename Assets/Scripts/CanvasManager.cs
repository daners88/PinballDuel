using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public UnityEngine.UI.Toggle musicToggle = null;
    public GameObject titleScreen = null;
    public GameObject gamePlay = null;
    public GameObject introSlide = null;
    public GameObject resultsSlide = null;
    AudioSource music;
    public GameObject player = null;
    public static CanvasManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicToggle.isOn)
        {
            music.enabled = false;
        }
        else if (!music.enabled)
        {
            music.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToTitle();
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AdvanceToResults();
        }
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        gamePlay.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void AdvanceToTitle()
    {
        introSlide.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void AdvanceToResults()
    {
        resultsSlide.SetActive(true);
        gamePlay.SetActive(false);
        introSlide.SetActive(false);
        titleScreen.SetActive(false);
        GameManager.Instance.ResetGame();
    }

    public void BackToTitle()
    {
        titleScreen.SetActive(true);
        gamePlay.SetActive(false);
        resultsSlide.SetActive(false);
        introSlide.SetActive(false);
        GameManager.Instance.ResetGame();
    }
}
