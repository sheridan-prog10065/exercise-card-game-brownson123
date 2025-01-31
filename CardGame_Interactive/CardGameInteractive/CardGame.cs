namespace CardGameInteractive;

/// <summary>
/// Defines the card game that implements the game logic anf holds the card deck
/// </summary>
public class CardGame
{
 /// <summary>
 /// Repersents the deck of cards the game is using
 /// </summary>
    private CardDeck _cardDeck;
 
 /// <summary>
 /// The score of the game
 /// </summary>
    private Score _score;
 
 /// <summary>
 /// This is the last card played by the user
 /// </summary>
    private Card _playedCard;

 /// <summary>
 /// The last card played by the house
 /// </summary>
    private Card _houseCard;
}