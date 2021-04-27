using System.Collections;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;      // 플레이어 색
    private Color halfAlpha;                    // 반투명
    private Color fullAlpha;                    // 원 색
    private bool blinkMode = false;             // blink mode 값
    private GameObject trainer;
    private TrainerControl trainerControl;
    private PlayerController playerController;
    private float trainerStep;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
        halfAlpha = new Color(1, 1, 1, 0.4f);
        fullAlpha = new Color(1, 1, 1, 1);
        trainer = GameObject.Find("Trainer");
        trainerControl = trainer.GetComponent<TrainerControl>();
        trainerStep = (transform.position.x - trainer.transform.position.x) / 3; // 3번 피격 시 따라잡힘

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!blinkMode)
        {
            blinkMode = true;
            EnterblinkMode();
            TrainerMove();
            CameraShake.MainCamera.ShakeCamera();
        }
    }

    private void EnterblinkMode()
    {
        StartCoroutine(BlinkModeRoutine());
        StartCoroutine(Blink());
    }

    private void TrainerMove()
    {
        if (trainerControl.transform.position.x == playerController.OriginPosX) return;
        float trainerMoveSpeed = 2f;
        StartCoroutine(TrainerMoveRoutine(trainerMoveSpeed));
    }

    IEnumerator TrainerMoveRoutine(float trainerMoveSpeed)
    {
        float destPosX = trainerControl.StartPosX + trainerStep;
        Debug.Log(trainerControl.StartPosX + ", " + destPosX + ", " + trainerStep);
        
        Vector3 trainerPos = trainerControl.transform.position;
        while (trainerControl.transform.position.x <= destPosX)
        {
            trainerControl.transform.position += new Vector3(trainerStep, 0, 0) * Time.deltaTime * trainerMoveSpeed;
            yield return null;
        }
        trainerControl.StartPosX = trainerControl.transform.position.x;
    }

    IEnumerator BlinkModeRoutine()
    {
        yield return new WaitForSeconds(3f);

        blinkMode = false;
    }
    IEnumerator Blink()
    {
        while (blinkMode)
        {
            spriteRenderer.color = halfAlpha;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = fullAlpha;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
