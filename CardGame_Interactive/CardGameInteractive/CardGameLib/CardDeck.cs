namespace CardGameLib;

/// <summary>
/// Implements the card deck as a list of cards
/// </summary>
public class CardDeck
{
    /// <summary>
    /// List of cards in the deck
    /// </summary>
    private List<Card> _cardList;
    
    //define a constant that keeps track of the max number of suits
    private const int MAX_SUIT_COUNT = 4;
    
    //define a constant that keeps track of the max card value
    private const int MAX_VALUE_COUNT = 13;
    
    //define a singleton randomizer object
    private static Random s_randomizer;

    static CardDeck()
    {
        s_randomizer = new Random();
    }
    

    public CardDeck()
    {
        _cardList = new List<Card>();
        
        //create the cards in the deck
        CreateCards();
    }

    private void CreateCards()
    {
        //for each suit in the card deck
        for (int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
        {
            CardSuit suit = (CardSuit)iSuit;
            //for each card  value
            for (byte value = 1; value <= MAX_VALUE_COUNT; value++)
            {
                //create the card object with the given suit and value
                Card card = new Card(value, suit);
                
                //add it to the deck
                _cardList.Add(card);
            }
        }
    }

    public void ShuffleCards()
    {
        //for each car in the deck
        for (int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            //choose a random position in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);
            
            //replace the current card with the card in the random position
            Card crtCard =_cardList[iCard];
            Card randCard = _cardList[randPos];
            _cardList[iCard] = randCard;
            _cardList[randPos] = crtCard;
        }
    }

    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        //check that we have enough cards for the extraction
        if (_cardList.Count >= 2)
        {
            //extract the first card
            int randPos = CardDeck.s_randomizer.Next(_cardList.Count);
            
            //access the card at the random index
            cardOne = _cardList[randPos];
            
            //remove the card from the deck
            _cardList.RemoveAt(randPos);
            
            //access the second card at the random index
            cardTwo = _cardList[randPos];
            
            //remove the second card from the deck
            _cardList.RemoveAt(randPos);
            
            //indicate the success of the extraction
            return true;
        }
        else
        {
            //there are not enough cards, the game must be over
            cardOne = null;
            cardTwo = null;
            return false;
        }
    }
    public int CardCount
    {
        get
        {
            return _cardList.Count;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        //swap both cards using tuple deconstruction
        (cardOne, cardTwo) = (cardTwo, cardOne);
    }
}