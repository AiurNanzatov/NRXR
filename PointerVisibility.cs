using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerVisibility : MonoBehaviour
{
    [SerializeField] GameObject mainLogic;
    public float duration;

    private MainLogic mainLogicScript;
    private Image pointer;
    private bool timing = false;
    private Coroutine countdown = null;
    void Start()
    {
        mainLogicScript = mainLogic.GetComponent<MainLogic>();
        pointer = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainLogicScript.Pressed) {
            if (timing) {
                StopCoroutine(countdown);
            }
            pointer.enabled = true;
            timing = false;
        } else if (pointer.enabled && !timing) {
            countdown = StartCoroutine(Countdown());
            timing = true;
        }
    }

    private IEnumerator Countdown() {
        if (timing) yield break;
        float elapsedTime = 0;
        while (elapsedTime <= duration) {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }
        timing = false;
        pointer.enabled = false;
    }
}
