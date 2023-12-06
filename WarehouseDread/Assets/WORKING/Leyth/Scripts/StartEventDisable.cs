using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEventDisable : MonoBehaviour
{
    public UnityEvent startState;
    // Start is called before the first frame update
    void Start()
    {
        startState.Invoke();
    }
}
