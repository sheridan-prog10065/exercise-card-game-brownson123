
using System.Diagnostics;

namespace CardGameInteractive;

/// <summary>
/// Defines the cards in the card game with its value and suit
/// </summary>
public class Card
{
    /// <summary>
    /// The value of the playing card
    /// </summary>
    private byte _value;
    
    /// <summary>
    /// The suit of the Player card
    /// </summary>
    private CardSuit _suit;

    public Card(byte value, CardSuit suit)
    {
        _value = value;
        _suit = suit;
    }

    public byte Value
    {
        get
        {
            return _value;
        }
    }

    public CardSuit Suit
    {
        get
        {
            return _suit;
        }
        set
        {
            _suit = value;
        }
    }

    public string CardName
    {
        get
        {
            switch (_value)
            {
                case 1: 
                    return "Ace";
                
                case 13 :
                    return "King";
                
                case 12: 
                    return "Queen";
                
                case 11: 
                    return "Jack";
                
                default:
                    //convert the numeric value into a string. We cannot cast integers into strings
                    return _value.ToString();
            }
        }
    }

    public string SuitName
    {
        get
        {
            switch (_suit)
            {
                case CardSuit.Clubs:
                    return "Clubs";
                case CardSuit.Diamonds:
                    return "Diamonds";
                case CardSuit.Hearts:
                    return "Hearts";
                case CardSuit.Spades:
                    return "Spades";
                default:
                    Debug.Assert(false, "Unknown suit value, cannot return suit name");
                    return _suit.ToString();
            }
        }
    }
}