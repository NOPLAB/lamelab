using UnityEngine;
using unityroom.Api;

public class GameManager: MonoBehaviour
{
    [SerializeField] private TargetSpawner _targetSpawner;
    [SerializeField] private SoundEffector _soundEffector;

    private bool _isPlayingGame = false;

    [SerializeField] private float _timer;
    
    private int _hitCount;

    [SerializeField] private int _boardNo = 1;
    [SerializeField] private float _missTime = 1;
    [SerializeField] ResultViewer _resultViewer;
    
    public void OnClickStart()
    {
        _resultViewer.DisActiveText();
        _timer = 0;
        _hitCount = 0;
        _soundEffector.ResetSelector();
        _targetSpawner.Spawn15Target();
        _isPlayingGame = true;
    }
    
    public void MissTarget()
    {
        if (!_isPlayingGame)
        {
            return;
        }
        
        _timer += _missTime;
    }
    
    public void HitTarget()
    {
        if (!_isPlayingGame)
        {
            return;
        }
        
        _soundEffector.Play();
        
        _hitCount++;

        if (_hitCount == 15)
        {
            EndGame();
            SendScoreToServer();
        }
    }

    private void EndGame()
    {
        _resultViewer.ActiveText(_timer.ToString("f3"));
        _isPlayingGame = false;
    }

    private void SendScoreToServer()
    {
        UnityroomApiClient.Instance.SendScore(_boardNo, _timer, ScoreboardWriteMode.HighScoreAsc);
    }

    private void Update()
    {
        if (_isPlayingGame)
        {
            _timer += Time.deltaTime;
        }
    }
}