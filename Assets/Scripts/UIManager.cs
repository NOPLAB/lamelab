using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_Text _volumeValueText;
    [SerializeField] private TMP_Text _volumeIsMuteText;

    [SerializeField] private AudioMixer _audioMixer;

    void Start()
    {
        _startButton.onClick.AddListener(OnClickStartButton);

        _volumeIsMuteText.enabled = false;
        _volumeSlider.onValueChanged.AddListener(OnValueChangedVolumeSlider);
}

    private void OnClickStartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void OnValueChangedVolumeSlider(float value)
    {
        _volumeValueText.text = value.ToString();
        _volumeIsMuteText.enabled = value == 0;
        
        // Normalize
        value /= 100;
        //-80~0に変換
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f,-80f,0f);

        _audioMixer.SetFloat("Master", volume);
    }
}
