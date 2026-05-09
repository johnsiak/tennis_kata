namespace TennisKata.Logic;

public class Game
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _pointsPlayerOne;
    private int _pointsPlayerTwo;

    public Game(Player playerOne, Player playerTwo)
    {
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public string GetScore()
    {
        if (_pointsPlayerOne == 1)
        {
            return "Fifteen-Love";
        }

        if (_pointsPlayerTwo == 1)
        {
            return "Love-Fifteen";
        }

        return "Love-All";
    }

    public void PointWonBy(Player player)
    {
        if (player == _playerOne)
        {
            _pointsPlayerOne++;
            return;
        }

        if (player == _playerTwo)
        {
            _pointsPlayerTwo++;
        }
    }
}
