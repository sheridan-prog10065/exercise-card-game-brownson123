using System.Diagnostics;

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
       _cardDeck.ShuffleCards();
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
 public sbyte PlayRound()
    {
       //determine the card ranks for the player and house cards
       byte houseRank = DetermineCardRank(_houseCard);
       byte playerRank = DetermineCardRank(_playerCard);
       
       //check which class has the higher rank to determine the winner
       if (playerRank > houseRank)
       {
          //The player won the round
          return 1;
       }else if (playerRank < houseRank)
       {
          //The house won the round
          return -1;
       }
       else
       {
          //There was a tie
          return 0;
       }
    }
 
 /// <summary>
 /// Deals the cards to the player and house when a new round starts
 /// </summary>
    public void DealCards()
    {
       //extract two cards from the deck, and assign them to the player and the house
       bool cardsDealt = _cardDeck.GetPairOfCards(out _playerCard, out _houseCard);
       Debug.Assert(cardsDealt, "Cards could not be dealt, check the game is not over");
    }

    public void SwitchCards()
    {
       //ask the deck of cards to swap the player and house cards
       _cardDeck.ExchangeCards(ref _playerCard, ref _houseCard);
    }

    /// <summary>
    /// Determines the rank of the card as used in the game. The ace is the highest card
    /// </summary>
    /// <returns>The rank of the card</returns>
    private byte DetermineCardRank(Card card)
    {
       return (card.Value == 1) ? (byte)14 : card.Value;
    }

   
    private void ShowRoundResult()
    {
    }

    private void ShowGameOver()
    {
       
    }
    #endregion
}