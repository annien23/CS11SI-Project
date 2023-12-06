using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class puzzle1Pad : MonoBehaviour
{
    public UnityEvent correctDestroy = new UnityEvent();
    public UnityEvent incorrectDestroy = new UnityEvent();
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
        if (other.gameObject.tag == this.gameObject.tag)
        {
            correctDestroy.Invoke();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag != this.gameObject.tag)
        {
            incorrectDestroy.Invoke();
            Destroy(other.gameObject);
        }
    }
}
