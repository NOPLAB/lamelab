using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    
    [SerializeField] private Button _rankingButton;
    
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_Text _volumeValueText;
    [SerializeField] private TMP_Text _volumeIsMuteText;

    void Start()
    {
        _startButton.onClick.AddListener(OnClickStartButton);

        _rankingButton.onClick.AddListener(OnClickRankingButton);

        _volumeIsMuteText.enabled = false;
        _volumeSlider.onValueChanged.AddListener(value =>
        {
            _volumeValueText.text = value.ToString();
            _volumeIsMuteText.enabled = value == 0;
        });
}

    private void OnClickStartButton(){}
    
    private void OnClickRankingButton(){}
}
