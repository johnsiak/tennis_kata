namespace TennisKata.Logic;

public class Set
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _gamesPlayerOne;
    private int _gamesPlayerTwo;
    private IGame _currentGame;

    public Set(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _currentGame = new Game(_playerOne, _playerTwo);
    }

    public void PointWonBy(Player player)
    {
        _currentGame.PointWonBy(player);

        if (_currentGame.IsOver())
        {
            var winner = _currentGame.Winner();
            if (winner == _playerOne)
            {
                _gamesPlayerOne++;
            }

            if (winner == _playerTwo)
            {
                _gamesPlayerTwo++;
            }

            _currentGame = new Game(_playerOne, _playerTwo);
        }
    }

    public string GetScore()
    {
        return $"{_gamesPlayerOne}-{_gamesPlayerTwo}";
    }

    public bool IsOver()
    {
        return false;
    }

    public Player? Winner()
    {
        return null;
    }
}