namespace CardGameLib;
/// <summary>
/// Defines the score of the game
/// </summary>
public struct Score
{
    /// <summary>
    /// The number if rounds won by the player
    /// </summary>
    private int _playerScore;
    
    /// <summary>
    /// The nunmber of rounds won by the house
    /// </summary>
    private int _houseScore;

    public int PlayerScore
    {
        get
        {
            return _playerScore;
        }
    }

    public int HouseScore
    {
        get
        {
            return _houseScore;
        }
    }
}