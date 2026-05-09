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
        if (_pointsPlayerOne == _pointsPlayerTwo)
        {
            if (_pointsPlayerOne == 1)
            {
                return "Fifteen-All";
            }

            if (_pointsPlayerOne == 3)
            {
                return "Deuce";
            }
        }

        if (_pointsPlayerOne == 2 && _pointsPlayerTwo == 1)
        {
            return "Thirty-Fifteen";
        }

        if (_pointsPlayerOne == 1)
        {
            return "Fifteen-Love";
        }

        if (_pointsPlayerTwo == 1)
        {
            return "Love-Fifteen";
        }

        if (_pointsPlayerOne == 3 && _pointsPlayerTwo == 0)
        {
            return "Forty-Love";
        }

        if (_pointsPlayerOne == 4 && _pointsPlayerTwo == 3)
        {
            return $"Advantage {_playerOne.Name}";
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
