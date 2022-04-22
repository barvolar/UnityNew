using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Goods> _goods;
    void Start()
    {
        foreach (var item in _goods)
            item.ShowInfo();
    }

  
}
