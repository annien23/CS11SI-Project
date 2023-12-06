using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cameOverHereEvent : MonoBehaviour
{
    public UnityEvent cameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameOver.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
