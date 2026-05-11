namespace TennisKata.Logic;

public class Match
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private Set _currentSet;

    public Match(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _currentSet = new Set(_playerOne, _playerTwo);
    }

    public void PointWonBy(Player player)
    {
        _currentSet.PointWonBy(player);

        if (_currentSet.IsOver())
        {
            _currentSet = new Set(_playerOne, _playerTwo);
        }
    }

    public string GetScore()
    {
        return _currentSet.GetScore();
    }
}