using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
 
    private float _speed = 10f;
   
    public void HandleCoroutine()
    {     
        if(_health.Value!=_slider.value)
            StartCoroutine(EditValue());

        else
            StopCoroutine(EditValue());
    }

    private IEnumerator EditValue()
    {
        while(_health.Value != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value,_health.Value, _speed*Time.deltaTime);
            Debug.Log(_slider.value);

            yield return null;
        }
    }
}
