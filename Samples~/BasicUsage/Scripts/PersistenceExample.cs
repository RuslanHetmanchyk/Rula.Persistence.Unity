using System.Threading.Tasks;
using Rula.Persistence.Core;
using Rula.Persistence.Unity.Extensions;
using UnityEngine;
using UnityEngine.UI;

public sealed class PersistenceExample : MonoBehaviour
{
    [SerializeField] private Button increaseButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Text goldLabel;

    private SaveManager _saveManager;
    private PlayerSave _playerSave;

    private const string SaveSlot = "player";

    private void Awake()
    {
        increaseButton.onClick.AddListener(OnIncrease);
        saveButton.onClick.AddListener(OnSave);
    }

    private async void Start()
    {
        await Initialize();
    }

    private void OnDestroy()
    {
        increaseButton.onClick.RemoveListener(OnIncrease);
        saveButton.onClick.RemoveListener(OnSave);
    }

    private async Task Initialize()
    {
        _saveManager = SaveManagerFactory.CreateDefault();

        _playerSave = new PlayerSave(
            new PlayerData
            {
                Gold = 0
            });

        _saveManager.Register(_playerSave);

        if (_saveManager.SaveExists(SaveSlot))
        {
            await _saveManager.LoadAsync(SaveSlot);
        }
        else
        {
            await _saveManager.SaveAsync(SaveSlot);
        }

        RefreshLabel();
    }

    private void OnIncrease()
    {
        _playerSave.AddGold();

        RefreshLabel();
    }

    private async void OnSave()
    {
        await _saveManager.SaveAsync(SaveSlot);
    }

    private void RefreshLabel()
    {
        goldLabel.text = _playerSave.Gold.ToString();
    }
}