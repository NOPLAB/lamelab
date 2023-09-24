using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultViewer : MonoBehaviour
{
    [SerializeField] private GameObject _textObject;
    private TMP_Text _scoreText;
    public void ActiveText(string scoreText)
    {
        if(_scoreText == null)
        {
            _scoreText = _textObject.GetComponent<TMP_Text>();
        }
        _textObject.SetActive(true);
        _scoreText.text = scoreText;
    }

    public void DisActiveText()
    {
        _textObject.SetActive(false);
    }
}
