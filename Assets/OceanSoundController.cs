using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class OceanSoundController : MonoBehaviour
{
    [SerializeReference]
    Transform playerTransform;

    public float radius = 3.0f;
    
    EventInstance windInstance;
    
    // Start is called before the first frame update
    void Start() {
        windInstance = AudioManager.Instance.CreateEventInstance(AudioManager.Instance.seaWind);
        windInstance.start();
    }

    // Update is called once per frame
    void Update() {
        float d = Vector3.Distance(transform.position, playerTransform.position);
        float oceanAmount = Mathf.Clamp(d/radius, 0, 1);
        
        Debug.Log(d);
        Debug.Log(oceanAmount);

        AudioManager.Instance.SetGlobalParameter("OceanAmount", oceanAmount);
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
