using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Goods", menuName = "Goods", order = 51)]
public class Goods : ScriptableObject
{
    [SerializeField] private string _label;
    [SerializeField] private string _description;
    [SerializeField] private int _price;

    public void ShowInfo()
    {
        Debug.Log($"{_label}, цена: {_price}\nОписание: {_description}");
    }
}
