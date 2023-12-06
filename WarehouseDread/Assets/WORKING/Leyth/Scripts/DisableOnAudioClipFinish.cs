using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DisableOnAudioClipFinish : MonoBehaviour
{
    public UnityEvent<string> thingDisabled;
    public string thingName;
    public bool actuallyDisable = true;

    private AudioSource src;
    private bool started = false;
    
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (src.isPlaying && !started)
        {
            started = true;
        }
        if (!src.isPlaying && started)
        {
            thingDisabled.Invoke(thingName);
            if (actuallyDisable)
            {
                src.gameObject.SetActive(false);
            }
        }
    }
}
