using System.Diagnostics;

namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private static readonly ImageSource s_imageSourceCardback;
    private CardGame _cardGame;
    
    public MainPage()
    {
        InitializeComponent();
        
        //Initialize the card game
        _cardGame = new CardGame();
    }

    static MainPage()
    {
        s_imageSourceCardback = ImageSource.FromFile("playing_card_back.jpg");
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        //Ensure the cards being dealt are face down
        _imgPlayerCard.Source = s_imageSourceCardback;
        _imgHouseCard.Source = s_imageSourceCardback;
        
        //ask the game object to deal cards to the player and house
        _cardGame.DealCards();
        
        //inform the user what they can do next: switch or play the cards
        _txtGameBoard.Text = "You can play the round or swap cards with the house";

        //allow the user to play
        _btnDealCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = true;
        _btnPlayCards.IsEnabled = true;
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
        //ask the game object to deal cards to the player and house
        _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
        //ask the game to play a round
        sbyte roundResult = _cardGame.PlayRound();
        
        //show the results of the round
        ShowRoundResult(roundResult);
        
        //disable the play commands and allow the user to deal another card
        _btnDealCards.IsEnabled = true;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;
        
        //check whether the game is over
        if (_cardGame.IsOver)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        if (_cardGame.playerWins)
        {
            _txtGameBoard.Text = "The player wins the game!";
        }else if (_cardGame.HouseWins)
        {
            _txtGameBoard.Text = "The house wins the game!";
        }
        else
        {
            _txtGameBoard.Text = "The game ended in a tie";
        }
        
        //disallow all buttons
        _btnDealCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;
    }

    private void ShowRoundResult(sbyte roundResult)
    {
        //Update the scoreboard
        _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
        _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();
        
        //Show the cards that have been played
        ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
        ShowCard(_imgHouseCard, _cardGame.HouseCard);
        
        //Display who won the round, the player or the house
        switch (roundResult)
        {
            case 1:
                _txtGameBoard.Text = "Player wins the round!";
                break;
            case -1:
                _txtGameBoard.Text = "House wins the round!";
                break;
            case 0:
                _txtGameBoard.Text = "Draw!";
                break;
            default:
                Debug.Assert(false, "Unknown round result");
                break;
        }
    }

    private void ShowCard(Image imgControl, Card card)
    {
        //determine the image source for the image control based on the card value ans suit
        char suitId = card.Suit.ToString()[0];
        string filename = $"{suitId}{card.Value.ToString(format: "00")}.png";
        
        //set the image source
        imgControl.Source = ImageSource.FromFile(filename);
    }
}
 