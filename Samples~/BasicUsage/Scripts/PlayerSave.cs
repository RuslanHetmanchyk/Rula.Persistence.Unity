using Rula.Persistence.Abstractions;

public sealed class PlayerSave : ISaveable<PlayerData>
{
    private const string Key = "player";

    public int Gold { get; private set; }

    public string SaveKey => Key;

    public PlayerSave(PlayerData data)
    {
        Gold = data.Gold;
    }

    public PlayerData CaptureState()
    {
        return new PlayerData
        {
            Gold = Gold
        };
    }

    public void RestoreState(PlayerData state)
    {
        Gold = state.Gold;
    }

    public void AddGold()
    {
        Gold++;
    }
}