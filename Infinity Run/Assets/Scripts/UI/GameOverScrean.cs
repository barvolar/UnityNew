using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScrean : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;
    [SerializeField] private HeartBar _heartBar;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDiePlayer;
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDiePlayer;
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnDiePlayer()
    {
        _heartBar.ShowHearts();
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
