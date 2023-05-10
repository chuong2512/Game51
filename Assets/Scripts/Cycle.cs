using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private GameDataManager _dataManager;
    
    private void Start()
    {
        _dataManager = GameDataManager.Instance;
        SetSkin();
    }

    private void SetSkin()
    {
    }
}
