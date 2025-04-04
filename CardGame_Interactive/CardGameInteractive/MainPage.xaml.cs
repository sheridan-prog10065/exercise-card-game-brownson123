namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
    private CardGame _cardGame;
    
    public MainPage()
    {
        InitializeComponent();
        
        //Initialize the card game
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        //ask the game object to deal cards to the player and house
        _cardGame.DealCards();
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
 