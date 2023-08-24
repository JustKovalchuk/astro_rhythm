using UnityEngine;

public class RythmKeyBind : MonoBehaviour
{
    [SerializeField] private RythmKey keyToBind;

    private SettingsManager settingsManager;

    private void Awake()
    {
        settingsManager = GetComponentInParent<SettingsManager>();
    }

    public void StartBind()
    {
        settingsManager.StartBind(keyToBind);
    }
}
