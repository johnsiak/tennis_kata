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
            if (_currentGame.Winner() == _playerOne)
            {
                _gamesPlayerOne++;
                _currentGame = new Game(_playerOne, _playerTwo);
            }
        }
    }

    public string GetScore()
    {
        return $"{_gamesPlayerOne}-{_gamesPlayerTwo}";
    }
}