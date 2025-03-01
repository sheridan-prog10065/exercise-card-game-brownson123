namespace CardGameInteractive;

/// <summary>
/// Defines the card game that implements the game logic anf holds the card deck
/// </summary>
public class CardGame
{
   #region fields
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
    private Card _playerCard;

 /// <summary>
 /// The last card played by the house
 /// </summary>
    private Card _houseCard;
    #endregion
   #region constructors
 /// <summary>
 /// The constructor of the card game class
 /// </summary>
    public CardGame()
    {
       _cardDeck = new CardDeck();
       _score = new Score();
       _playerCard = null;
       _houseCard = null;
    }
   #endregion
   #region properties
   public Score Score
   {
      get
      {
         return _score;
      }

      set
      {
         _score = value;
      }
   }

   public Card PlayerCard
   {
      get
      {
         return _playerCard;
      }
   }

   public Card HouseCard
   {
      get
      {
         return _houseCard;
      }
   }

   public bool IsOver
   {
      get
      {
         return (_cardDeck.CardCount < 2);
      }
   }

   public bool playerWins
   {
      get
      {
         return this.IsOver && _score.PlayerScore > _score.HouseScore;
      }
   }

   public bool HouseWins
   {
      get
      {
         return this.IsOver && _score.HouseScore > _score.PlayerScore;
      }
   }
   #endregion
   #region methods
   
 /// <summary>
 /// Plays the game
 /// </summary>
    public void Play()
    {
       //TODO: implement play
    }

 /// <summary>
 /// play a round of the game
 /// </summary>
 /// <returns>
 ///     +1: The user won the round
 ///     0: There was a tie
 ///     -1: The house won the round
 /// </returns>
    private sbyte PlayRound()
    {
       //TODO: implement play round
       return 0;
    }
 
 /// <summary>
 /// Deals the cards to the player and house when a new round starts
 /// </summary>
    private void DealCards()
    {
       
    }

    private void SwitchCards()
    {
       
    }

    /// <summary>
    /// Determines the rank of the card as used in the game. The ace is the highest card
    /// </summary>
    /// <returns>The rank of the card</returns>
    private byte DetermineCardRank(Card card)
    {
       //check of the value of the card is an ace
       if (card.Value == 1)
       {
          return 14;
       }
       return card.Value;
    }

    private void ShowRoundResult()
    {
       
    }

    private void ShowGameOver()
    {
       
    }
    #endregion
}