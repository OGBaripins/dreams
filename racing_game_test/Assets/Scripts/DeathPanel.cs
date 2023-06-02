using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{

    private bool mFaded = false;

    [SerializeField] float duration = .4f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        HealthController.DeathTrigger += Fade;

        print("Yes very set");
    }

    public void Fade()
    {
        var canvaGroup = GetComponent<CanvasGroup>();

        StartCoroutine(DoFade(canvaGroup, canvaGroup.alpha, mFaded ? 1 : 0));
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }

        Time.timeScale = 0f;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }
}
