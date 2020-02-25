using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    [SerializeField]
    private bool bigBounce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PinBall temp = collision.transform.gameObject.GetComponentInChildren<PinBall>();
        if (temp != null)
        {
            Vector3 dir = temp.transform.position - transform.position;
            float dist = dir.magnitude;
            Vector3 direction = dir / dist;
            temp.SetDir(direction, bigBounce);
        }
        
    }
}
