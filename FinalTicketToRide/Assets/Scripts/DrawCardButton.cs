using UnityEngine;
using UnityEngine.UI;

public class DrawCardButton : MonoBehaviour
{
    public Button drawCardButtonPlayer1;
    public Button drawCardButtonPlayer2;
    public CardDeck cardDeck;
    public Player player1;
    public Player player2;

    private void Start()
    {
        if (drawCardButtonPlayer1 != null)
        {
            drawCardButtonPlayer1.onClick.AddListener(() => DrawCardForPlayer(player1));
        }

        if (drawCardButtonPlayer2 != null)
        {
            drawCardButtonPlayer2.onClick.AddListener(() => DrawCardForPlayer(player2));
        }
    }

    private void DrawCardForPlayer(Player player)
    {
        if (CanDrawCard(player))
        {
            Card drawnCard = cardDeck.DrawCard();
            if (drawnCard != null)
            {
                player.AddToHand(drawnCard);
            }
            else
            {
                Debug.LogWarning("No more cards in the deck!");
            }

            player.IncrementMaxHandSize();
            UpdateDrawCardButtonInteractivity();
        }
        else
        {
            Debug.LogWarning("Hand is full. Cannot draw more cards.");
        }
    }

    private bool CanDrawCard(Player player)
    {
        return player.CanDrawCard();
    }

    private void UpdateDrawCardButtonInteractivity()
    {
        if (drawCardButtonPlayer1 != null)
        {
            drawCardButtonPlayer1.interactable = CanDrawCard(player1);
        }

        if (drawCardButtonPlayer2 != null)
        {
            drawCardButtonPlayer2.interactable = CanDrawCard(player2);
        }
    }
}
