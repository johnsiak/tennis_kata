namespace TennisKata.Logic;

public class Match
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private Set _currentSet;
    private readonly List<string> _completedSetScores = new();

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
            _completedSetScores.Add(_currentSet.GetScore());
            _currentSet = new Set(_playerOne, _playerTwo);
        }
    }

    public string GetScore()
    {
        if (_completedSetScores.Count == 0)
        {
            return _currentSet.GetScore();
        }

        return string.Join(", ", _completedSetScores);
    }
}