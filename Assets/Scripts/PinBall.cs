using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb = null;
    Vector3 startPos = Vector3.zero;
    private int lastTouchId = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsRunning())
        {
            if (transform.position.y != startPos.y)
            {
                transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPos;
        lastTouchId = 0;
    }

    public int GetLastTouch()
    {
        return lastTouchId;
    }

    public void SetLastTouch(int pid)
    {
        lastTouchId = pid;
    }

    public void SetDir(Vector3 dir, bool bigBounce)
    {
        dir += new Vector3(0, -dir.y, 0);
        if(bigBounce)
        {
            dir *= 1500f;
            rb.AddForce(dir);
        }
        else
        {
            dir *= 0f;
        }

        
    }

}
