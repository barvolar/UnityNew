using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nexValuel;

        while (elapsed < duration)
        {
            nexValuel = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nexValuel;
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    public void ToDestroy()
    {
        StartCoroutine(Filling(1, 0, 0.2f, Destroy));
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, 0.2f, Fill));
    }

    public void FadeIn()
    {
        _image.fillAmount = 0;
    }
}
