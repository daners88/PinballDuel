using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    System.Random rand = new System.Random();
    [SerializeField]
    private GameObject countDownTimer = null;
    [SerializeField]
    private GameObject score1 = null;
    int score1Num = 0;
    [SerializeField]
    private GameObject score2 = null;
    int score2Num = 0;
    [SerializeField]
    private GameObject bumper1 = null;
    [SerializeField]
    private GameObject bumper2 = null;
    [SerializeField]
    private GameObject invisibleWall = null;
    bool wallUp = false;
    float wallTimer = 0f;

    private bool running = false;


    [SerializeField]
    private float gameTimeLeft = 120.0f;
    public static GameManager Instance;
    public bool gameover = false;

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
        score1.GetComponent<UnityEngine.UI.Text>().text = score1Num.ToString();
        score2.GetComponent<UnityEngine.UI.Text>().text = score2Num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            gameTimeLeft -= Time.deltaTime;
            countDownTimer.GetComponent<UnityEngine.UI.Text>().text = ((int)gameTimeLeft).ToString();
            if(wallUp)
            {
                wallTimer += Time.deltaTime;
                if(wallTimer > 15f)
                {
                    invisibleWall.SetActive(false);
                    invisibleWall.GetComponent<InvisibleWall>().idToBenefit = 0;
                    wallUp = false;
                    wallTimer = 0f;
                }
            }
        }
        else
        {

        }
    }

    public int GetRand(int low, int high)
    {
        return rand.Next(low, high);
    }

    public void PowerUpPlayer(PowerUpType pt, int lastTouchId)
    {
        if(pt == PowerUpType.MoreTime)
        {
            gameTimeLeft += 30f;
        }
        else if (bumper1.GetComponent<Player>().GetID() == lastTouchId)
        {
            if(pt == PowerUpType.InvisibleWall)
            {
                invisibleWall.SetActive(true);
                invisibleWall.GetComponent<InvisibleWall>().idToBenefit = lastTouchId;
                wallUp = true;
            }
            else if(pt == PowerUpType.MoveFast)
            {
                bumper1.GetComponent<Player>().ispoweredUp = true;
            }
            else
            {
                score1Num += 2;
            }
        }
        else
        {
            if (pt == PowerUpType.InvisibleWall)
            {
                invisibleWall.SetActive(true);
                invisibleWall.GetComponent<InvisibleWall>().idToBenefit = lastTouchId;
                wallUp = true;
            }
            else if (pt == PowerUpType.MoveFast)
            {
                bumper2.GetComponent<Player>().ispoweredUp = true;
            }
            else
            {
                score2Num += 2;
            }
        }
    }

    public void StartGame()
    {
        running = true;
    }

    public void DeselectOtherBumper(int selectedID)
    {
        if(bumper1.GetComponent<Player>().GetID() == selectedID)
        {
            bumper2.GetComponent<Player>().isSelected = false;
        }
        else
        {
            bumper1.GetComponent<Player>().isSelected = false;
        }
    }

    public void MoveBumper(Vector3 pos)
    {
        if (bumper1.GetComponent<Player>().isSelected)
        {
            bumper1.GetComponent<Player>().MoveBumper(pos);
        }
        else if(bumper2.GetComponent<Player>().isSelected)
        {
            bumper2.GetComponent<Player>().MoveBumper(pos);
        }
    }

    public void ResetGame()
    {
        gameover = false;
        gameTimeLeft = 120.0f;
        running = false;
        score1Num = 0;
        score2Num = 0;
    }

    public void AdjustScores(int lasthitID)
    {
        if(bumper1.GetComponent<Player>().GetID() == lasthitID)
        {
            score1Num -= 1;
        }
        else if (bumper2.GetComponent<Player>().GetID() == lasthitID)
        {
            score2Num -= 1;
        }
        else
        {
            score1Num -= 1;
            score2Num -= 1;
        }

        score1.GetComponent<UnityEngine.UI.Text>().text = score1Num.ToString();
        score2.GetComponent<UnityEngine.UI.Text>().text = score2Num.ToString();
    }

    public void GainPoints(int scoringID)
    {
        if (bumper1.GetComponent<Player>().GetID() != scoringID)
        {
            score2Num += 1;
        }
        else
        {
            score1Num += 1;
        }

        score1.GetComponent<UnityEngine.UI.Text>().text = score1Num.ToString();
        score2.GetComponent<UnityEngine.UI.Text>().text = score2Num.ToString();
    }


    public bool IsRunning()
    {
        return running;
    }
}
