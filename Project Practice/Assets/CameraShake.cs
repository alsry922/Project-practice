using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeIntensity;
    [SerializeField]
    private float shakeTime;

    private static CameraShake mainCamera;
    public static CameraShake MainCamera => mainCamera;

    public CameraShake()
    {
        mainCamera = this;
    }

    public void ShakeCamera()
    {
        shakeTime = 0.5f;
        StopCoroutine(ShakeRoutine());
        StartCoroutine(ShakeRoutine());
    }
    IEnumerator ShakeRoutine()
    {
        Vector3 startRotaion = transform.eulerAngles;

        while (shakeTime > 0.0f)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            transform.rotation = Quaternion.Euler(startRotaion + new Vector3(x, y, z) * shakeIntensity);

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRotaion);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
