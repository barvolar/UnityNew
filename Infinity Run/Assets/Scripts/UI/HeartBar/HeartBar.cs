using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    [SerializeField] private List<Heart> _hearts = new List<Heart>();
    [SerializeField] private Heart _template;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHearts;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHearts;
    }

    private void ChangeHearts(int hpValue)
    {

        if (hpValue < _hearts.Count)
        {
            int countHearts = _hearts.Count - hpValue;

            for (int i = 0; i < countHearts; i++)
            {              
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }



        else if (hpValue > _hearts.Count)
        {
            int countHearts = hpValue - _hearts.Count;

            for (int i = 0; i < countHearts; i++)
            {
                CreateHeart();
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        heart.ToDestroy();
        _hearts.Remove(heart);
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_template, transform);
        _hearts.Add(heart.GetComponent<Heart>());
        heart.ToFill();
    }

    public void ShowHearts()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].FadeIn();
            Debug.Log($"Сердце {i} спрятано");
        }
    }
}
