using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour
{
    private Button button;

    private Transform rotater;
    private int rightRot;

    [HideIf("alwaysTrue")] public bool twoWay;

    [HideIf("twoWay")] public bool alwaysTrue;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RotateImage);

        rotater = transform.GetChild(0);
    }

    private void RotateImage()
    {
        if (!alwaysTrue)
        {
            rotater.rotation = Quaternion.Euler(new Vector3(0, 0, rotater.rotation.eulerAngles.z + 90));
            GameUI.Instance.Check();
        }
    }

    public bool CheckTrue()
    {
        if (alwaysTrue)
        {
            return true;
        }

        if (twoWay)
        {
            return (int) rotater.rotation.eulerAngles.z == rightRot ||
                   (int) rotater.rotation.eulerAngles.z == rightRot + 180;
        }

        return (int) rotater.rotation.eulerAngles.z == rightRot;
    }

    [Button]
    private void Rotate()
    {
        rotater = transform.GetChild(0);
        rotater.rotation = Quaternion.Euler(new Vector3(0, 0, rotater.rotation.eulerAngles.z + 90));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Rand()
    {
        rotater = transform.GetChild(0);
        rightRot = (int) rotater.rotation.eulerAngles.z;
        rotater.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 4) * 90));
    }

    public void Hint()
    {
        rotater.rotation = Quaternion.Euler(new Vector3(0, 0, rightRot));
        GameUI.Instance.Check();
    }
}