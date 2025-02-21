namespace CardGameInteractive;

/// <summary>
/// Implements the card deck as a list of cards
/// </summary>
public class CardDeck
{
    /// <summary>
    /// List of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    public CardDeck()
    {
        _cardList = new List<Card>();
    }

    public int CardCount
    {
        get
        {
            return _cardList.Count;
        }
    }
}