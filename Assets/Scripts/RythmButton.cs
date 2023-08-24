using UnityEngine;
using TMPro;

public class RythmButton : MonoBehaviour
{
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private RythmKey rythmKey;

    private void Awake()
    {
        keyText.text = SettingsManager.GetKey(rythmKey).ToString();
    }
}
