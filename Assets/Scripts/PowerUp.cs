using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerUpType
{
    Points = 0,
    InvisibleWall = 1,
    MoveFast = 2,
    MoreTime = 3
}
public class PowerUp : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField]
    private bool permanent = false;
    float reactivateTime = 10f;
    float timer = 3f;
    bool triggered = false;
    [SerializeField]
    private PowerUpType t;
    int lastTouchId;

    void Start()
    {
        t = (PowerUpType)GameManager.Instance.GetRand(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                t = (PowerUpType)GameManager.Instance.GetRand(0, 3);
                triggered = false;
                timer = 3f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PinBall temp = other.gameObject.GetComponent<PinBall>();

        if (temp != null)
        {
            triggered = true;
            lastTouchId = temp.GetLastTouch();
            GameManager.Instance.PowerUpPlayer(t, lastTouchId);
        }
    }
}
