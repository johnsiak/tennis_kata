namespace TennisKata.Logic;

public interface IGame
{
    void PointWonBy(Player player);
    string GetScore();
    bool IsOver();
    Player? Winner();
}