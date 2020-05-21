using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Shake (float duration, float magnitude){
        Vector3 originalPos = transform.localPosition;

        float timePassed = 0.0f;
        while (timePassed < duration)
        {
            float xDisplacement = Random.Range(-1f,1f)*magnitude;
            float yDisplacement = Random.Range(-1f,1f)*magnitude;

            transform.localPosition = new Vector3(xDisplacement , yDisplacement , originalPos.z);

            timePassed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
