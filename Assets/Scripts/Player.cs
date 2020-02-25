using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int playerId = 1;

    float speed = 5f;

    public bool isSelected = false;
    bool moving = false;
    Vector3 targetPos;
    float timer = 0f;
    public bool ispoweredUp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
            if(transform.position.Equals(targetPos))
            {
                moving = false;
            }
        }

        if(ispoweredUp)
        {
            timer += Time.deltaTime;
            speed = 15f;
            if(timer > 10f)
            {
                timer = 0f;
                ispoweredUp = false;
            }
        }
    }

    public void MoveBumper(Vector3 pos)
    {
        moving = true;
        Vector3 temp = transform.position;
        temp.x = pos.x;
        temp.z = pos.z;
        targetPos = temp;
    }

    public int GetID()
    {
        return playerId;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsRunning())
        {
            isSelected = true;
            GameManager.Instance.DeselectOtherBumper(playerId);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PinBall temp = collision.transform.gameObject.GetComponent<PinBall>();
        if (temp != null)
        {
            temp.SetLastTouch(playerId);
        }
    }
}
