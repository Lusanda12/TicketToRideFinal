using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public List<Card> hand;
    public Button[] buttons;
    public Button claimRouteButton;
    public Button drawTrainCardButton;
    public Button drawDestinationTicketButton;
    public GameObject cardPrefab; // Reference to the card prefab
    public GridLayoutGroup gridLayout; // Reference to the grid layout component
    public ScrollRect scrollRect; // Reference to the scroll rect component
    public Sprite locomotiveSprite; // Reference to the locomotive sprite
    public Dictionary<string, Sprite> coloredCardSprites; // Dictionary to hold colored card sprites
    public CardDeck cardDeck;

    // Placeholder sprite variables for different colors
    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;
    public Sprite pinkSprite; // Player 2 card color
    public Sprite orangeSprite;
    public Sprite whiteSprite;
    public Sprite yellowSprite;
    public Sprite blackSprite;
    public Sprite locomotive;

    private int maxHandSize = 4; // Maximum number of cards a player can hold

    private void Start()
    {
        hand = new List<Card>(); // Initialize the hand list

        if (drawTrainCardButton != null)
        {
            drawTrainCardButton.onClick.AddListener(DrawCard);
        }

        // Initialize the coloredCardSprites dictionary
        coloredCardSprites = new Dictionary<string, Sprite>();

        // Add color sprites to the dictionary
        coloredCardSprites.Add("Red", redSprite);
        coloredCardSprites.Add("Blue", blueSprite);
        coloredCardSprites.Add("Green", greenSprite);
        coloredCardSprites.Add("Pink", pinkSprite); // Player 2 card color
        coloredCardSprites.Add("Orange", orangeSprite);
        coloredCardSprites.Add("White", whiteSprite);
        coloredCardSprites.Add("Yellow", yellowSprite);
        coloredCardSprites.Add("Black", blackSprite);
        coloredCardSprites.Add("Locomotive", locomotiveSprite);

        DealInitialCards(maxHandSize);
        ShowCards();
    }

    public void AddToHand(Card card)
    {
        if (hand.Count < maxHandSize)
        {
            hand.Add(card);
            ShowCards();
        }
        else
        {
            Debug.LogWarning("Hand is full. Cannot add more cards.");
        }
    }

    public bool CanDrawCard()
    {
        if (hand.Count < maxHandSize)
        {
            return true;
        }
        return false;
    }

    private void DrawCard()
    {
        if (CanDrawCard())
        {
            // Implement your logic to draw a card from a deck
            Card drawnCard = cardDeck.DrawCard();
            if (drawnCard != null)
            {
                AddToHand(drawnCard);
            }
            else
            {
                Debug.LogWarning("No more cards in the deck!");
            }

            // Increase the max hand size by 1
            IncrementMaxHandSize();

            // Update the draw card button interactivity
            UpdateDrawCardButtonInteractivity();
        }
        else
        {
            Debug.LogWarning("Hand is full. Cannot draw more cards.");
        }
    }

    public void IncrementMaxHandSize()
    {
        maxHandSize++;
    }

    private void UpdateDrawCardButtonInteractivity()
    {
        if (drawTrainCardButton != null)
        {
            drawTrainCardButton.interactable = CanDrawCard();
        }
    }

    public bool HasCards(List<Card> cards)
    {
        foreach (Card card in cards)
        {
            if (!hand.Contains(card))
            {
                return false;
            }
        }
        return true;
    }

    public bool RemoveCards(List<Card> cards)
    {
        foreach (Card card in cards)
        {
            if (!hand.Remove(card))
            {
                return false;
            }
        }
        return true;
    }

    private void DealInitialCards(int numCards)
    {
        List<Card> dealtCards = cardDeck.DealCards(numCards);
        foreach (Card card in dealtCards)
        {
            AddToHand(card);
        }
    }

       public void ShowCards()
    {
        // Clear the existing cards from the hand panel
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate card UI objects for each card in the hand
        foreach (Card card in hand)
        {
            // Create a new GameObject for the card UI object
            GameObject cardObject = Instantiate(cardPrefab);

            // Set the parent of the card object to the hand panel
            cardObject.transform.SetParent(gridLayout.transform);

            // Get the Image component of the card object
            Image cardImage = cardObject.GetComponent<Image>();

            // Set the card sprite based on the card's color
            string color = card.Color;
            if (coloredCardSprites.ContainsKey(color))
            {
                cardImage.sprite = coloredCardSprites[color];
            }
            else
            {
                Debug.LogWarning("Missing sprite for card color: " + color);
            }
        }

        // Update the grid layout and scroll view
        gridLayout.constraintCount = hand.Count;
        LayoutRebuilder.ForceRebuildLayoutImmediate(gridLayout.GetComponent<RectTransform>());
        scrollRect.verticalNormalizedPosition = 1f;
    }

    public void ShowPlayer2Cards()
    {
        // Clear the existing cards from the hand panel
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate card UI objects for each card in the hand
        foreach (Card card in hand)
        {
            // Create a new GameObject for the card UI object
            GameObject cardObject = Instantiate(cardPrefab);

            // Set the parent of the card object to the hand panel
            cardObject.transform.SetParent(gridLayout.transform);

            // Get the Image component of the card object
            Image cardImage = cardObject.GetComponent<Image>();

            // Set the card sprite based on the card's color
            string color = card.Color;
            if (coloredCardSprites.ContainsKey(color))
            {
                cardImage.sprite = coloredCardSprites[color];
            }
            else
            {
                Debug.LogWarning("Missing sprite for card color: " + color);
            }
        }

        // Update the grid layout and scroll view
        gridLayout.constraintCount = hand.Count;
        LayoutRebuilder.ForceRebuildLayoutImmediate(gridLayout.GetComponent<RectTransform>());
        scrollRect.verticalNormalizedPosition = 1f;
    }
}
