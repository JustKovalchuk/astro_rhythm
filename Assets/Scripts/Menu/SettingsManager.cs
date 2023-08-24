using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public enum RythmKey { Key1, Key2, Key3, Key4 }

public class SettingsManager : MonoBehaviour
{
    private MenuManager menuManager;

    public static bool IsBinding { get; private set; }
    private RythmKey rythmKeyToBind;

    [SerializeField] private TextMeshProUGUI[] keysTexts;

    private static Dictionary<RythmKey, KeyCode> keys = new Dictionary<RythmKey, KeyCode>(4);

    public static KeyCode Key1 => keys[RythmKey.Key1];
    public static KeyCode Key2 => keys[RythmKey.Key2];
    public static KeyCode Key3 => keys[RythmKey.Key3];
    public static KeyCode Key4 => keys[RythmKey.Key4];

    [SerializeField] private AK.Wwise.Event SecretEvent;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();

        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 75);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 75);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 75);

        keys[RythmKey.Key1] = (KeyCode)PlayerPrefs.GetInt(RythmKey.Key1.ToString(), (int)KeyCode.D);
        keys[RythmKey.Key2] = (KeyCode)PlayerPrefs.GetInt(RythmKey.Key2.ToString(), (int)KeyCode.F);
        keys[RythmKey.Key3] = (KeyCode)PlayerPrefs.GetInt(RythmKey.Key3.ToString(), (int)KeyCode.J);
        keys[RythmKey.Key4] = (KeyCode)PlayerPrefs.GetInt(RythmKey.Key4.ToString(), (int)KeyCode.K);

        keysTexts[0].text = keys[RythmKey.Key1].ToString();
        keysTexts[1].text = keys[RythmKey.Key2].ToString();
        keysTexts[2].text = keys[RythmKey.Key3].ToString();
        keysTexts[3].text = keys[RythmKey.Key4].ToString();
    }

    private void OnGUI()
    {
        if (!IsBinding)
            return;

        Event e = Event.current;
        if (e.isKey)
        {
            if (e.keyCode == KeyCode.Escape)
            {
                EndBinding();
                return;
            }

            BindKey(e.keyCode, rythmKeyToBind);
            EndBinding();
        }
    }

    public static KeyCode GetKey(RythmKey key)
    {
        return keys[key];
    }
    public void SetMasterVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void StartBind(RythmKey rythmKeyToBind)
    {
        IsBinding = true;
        menuManager.EnableOverlay();
        this.rythmKeyToBind = rythmKeyToBind;
    }
    public void EndBinding()
    {
        menuManager.DisableOverlay();
        IsBinding = false;
        if ((keys[RythmKey.Key1] == KeyCode.Alpha1 || keys[RythmKey.Key1] == KeyCode.Keypad1) &&
            (keys[RythmKey.Key2] == KeyCode.Alpha9 || keys[RythmKey.Key2] == KeyCode.Keypad9) && 
            (keys[RythmKey.Key3] == KeyCode.Alpha8 || keys[RythmKey.Key3] == KeyCode.Keypad8) && 
            (keys[RythmKey.Key4] == KeyCode.Alpha5 || keys[RythmKey.Key4] == KeyCode.Keypad5))
        {
            Debug.Log("Secret");
            GetComponent<Animator>().Play("Dlorian");
            SecretEvent?.Post(gameObject);
        }
        Debug.Log("0:" + keys[RythmKey.Key1]);
        Debug.Log("1:" + keys[RythmKey.Key2]);
        Debug.Log("2:" + keys[RythmKey.Key3]);
        Debug.Log("3:" + keys[RythmKey.Key4]);
    }
    public void BindKey(KeyCode key, RythmKey rythmKey)
    {
        keys[rythmKey] = key;
        keysTexts[(int)rythmKey].text = key.ToString();

        PlayerPrefs.SetInt(rythmKey.ToString(), (int)key);
        PlayerPrefs.Save();
    }
}
