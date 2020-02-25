using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // Start is called before the first frame update
    public int idToBenefit = 0;
    bool hit = false;
    float timer = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                hit = false;
                timer = 3f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PinBall temp = collision.transform.gameObject.GetComponentInChildren<PinBall>();
        if (temp != null)
        {
            if(!hit)
            {
                GameManager.Instance.GainPoints(idToBenefit);
                hit = true;
            }
        }
    }
}
