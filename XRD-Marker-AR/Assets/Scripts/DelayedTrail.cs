using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedTrail : MonoBehaviour
{
    [SerializeField] public int delayTrailSeconds = 2;
    // Start is called before the first frame update
    private TrailRenderer _tRenderer;
    void Start()
    {
        _tRenderer = GetComponent<TrailRenderer>();
        _tRenderer.enabled = false;
        StartCoroutine(StartTrail(delayTrailSeconds));
    }


    private IEnumerator StartTrail(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _tRenderer.enabled = true;
    }
}
