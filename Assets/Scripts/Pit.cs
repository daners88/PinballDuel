﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PinBall temp = other.gameObject.GetComponent<PinBall>();

        if(temp != null)
        {
            temp.ResetPosition();
            GameManager.Instance.AdjustScores(temp.GetLastTouch());
        }
    }
}