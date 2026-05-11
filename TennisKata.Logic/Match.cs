namespace TennisKata.Logic;

public class Match
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private Set _currentSet;
    private string _completedSetScore = "";    

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
            _completedSetScore = _currentSet.GetScore();
            _currentSet = new Set(_playerOne, _playerTwo);
        }
    }

    public string GetScore()
    {
        if (string.IsNullOrEmpty(_completedSetScore))
        {
            return _currentSet.GetScore();
        }

        return _completedSetScore;
    }
}