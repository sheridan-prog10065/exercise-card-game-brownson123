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
        _cardGame.PlayRound();
    }
}
 