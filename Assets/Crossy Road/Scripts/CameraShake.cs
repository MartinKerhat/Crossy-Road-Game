using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float jumpIter = 8f;

    public void Shake ()
    {
        float height = Mathf.PerlinNoise(jumpIter, 0f) * 5;
        height = height * height * 0.2f;

        float shakeAmt = height;        // degrees to shake camera
        float shakePeriodTime = 0.25f;  // period of each shake
        float dropOffTime = 1.25f;      // time to settle down shake

        LTDescr shakeTween = LeanTween.rotateAroundLocal(gameObject, Vector3.right, shakeAmt, shakePeriodTime).setEase(LeanTweenType.easeShake).setLoopClamp().setRepeat(-1);

        LeanTween.value(gameObject, shakeAmt, 0, dropOffTime).setOnUpdate((float val) => { shakeTween.setTo(Vector3.right * val); }).setEase (LeanTweenType.easeInOutQuad);
    }
}
