using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLevel : MonoBehaviour
{
    public TextMeshProUGUI high;

    void OnEnable()
    {
        high?.SetText($"LEVEL {GameDataManager.Instance.Level}");
    }
}
