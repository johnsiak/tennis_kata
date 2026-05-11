namespace TennisKata.Logic;

public class Set
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _gamesPlayerOne;
    private int _gamesPlayerTwo;
    private IGame _currentGame;
    private bool _isOver;
    private Player? _winner;

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

            if (_currentGame is TiebreakGame)
            {
                _isOver = true;
                _winner = winner;
                return;
            }

            var lead = _gamesPlayerOne - _gamesPlayerTwo;
            if (_gamesPlayerOne >= 6 && lead >= 2)
            {
                _isOver = true;
                _winner = _playerOne;
                return;
            }

            if (_gamesPlayerTwo >= 6 && lead <= -2)
            {
                _isOver = true;
                _winner = _playerTwo;
                return;
            }

            if (_gamesPlayerOne == 6 && _gamesPlayerTwo == 6)
            {
                _currentGame = new TiebreakGame(_playerOne, _playerTwo);
                return;
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
        return _isOver;
    }

    public Player? Winner()
    {
        return _winner;
    }
}