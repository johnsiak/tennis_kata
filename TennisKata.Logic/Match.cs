namespace TennisKata.Logic;

public class Match
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private Set _currentSet;
    private readonly List<string> _completedSetScores = new();
    private int _setsPlayerOne;
    private int _setsPlayerTwo;
    private Player? _winner;

    public Match(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _currentSet = new Set(_playerOne, _playerTwo);
    }

    public void PointWonBy(Player player)
    {
        if (IsOver())
        {
            return;
        }

        _currentSet.PointWonBy(player);

        if (_currentSet.IsOver())
        {
            HandleSetCompletion();
        }
    }

    public string GetScore()
    {
        if (_completedSetScores.Count == 0)
        {
            return _currentSet.GetScore();
        }

        var scores = new List<string>(_completedSetScores);
        if (_currentSet.GetScore() != "0-0")
        {
            scores.Add(_currentSet.GetScore());
        }

        return string.Join(", ", scores);
    }

    public bool IsOver()
    {
        return Winner() is not null;
    }

    public Player? Winner()
    {
        return _winner;
    }

    private void HandleSetCompletion()
    {
        var setWinner = _currentSet.Winner();
        if (setWinner == _playerOne)
        {
            _setsPlayerOne++;
        }

        if (setWinner == _playerTwo)
        {
            _setsPlayerTwo++;
        }

        if (_setsPlayerOne == 2)
        {
            _winner = _playerOne;
            return;
        }

        if (_setsPlayerTwo == 2)
        {
            _winner = _playerTwo;
            return;
        }

        _completedSetScores.Add(_currentSet.GetScore());
        _currentSet = new Set(_playerOne, _playerTwo);
    }
}