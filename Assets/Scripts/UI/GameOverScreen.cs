using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        Player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        Player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnDied()
    {
        Time.timeScale = 0f;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
}
