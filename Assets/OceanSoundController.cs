using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using TMPro;
using UnityEngine;

public class OceanSoundController : MonoBehaviour
{
    [SerializeReference]
    Transform playerTransform;

    [SerializeReference]
    TextMeshProUGUI debugText;
    
    public float radius = 3.0f;
    
    EventInstance windInstance;
    EventInstance birdCawsInstance;
    EventInstance mainSongInstance;
    
    // Start is called before the first frame update
    void Start() {
        windInstance = AudioManager.Instance.CreateEventInstance(AudioManager.Instance.seaWind);
        windInstance.start();
        birdCawsInstance = AudioManager.Instance.CreateEventInstance(AudioManager.Instance.birdCaws);
        birdCawsInstance.start();
        mainSongInstance = AudioManager.Instance.CreateEventInstance(AudioManager.Instance.mainSong);
        mainSongInstance.start();
    }

    // Update is called once per frame
    void Update() {
        float d = Vector3.Distance(transform.position, playerTransform.position);
        float oceanAmount = Mathf.Clamp(d/radius, 0, 1);
        
        //Debug.Log(d);
        //Debug.Log(oceanAmount);
        debugText.text = oceanAmount.ToString();

        AudioManager.Instance.SetGlobalParameter("OceanAmount", oceanAmount);
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
