using UnityEngine;

public class CardColorAssigner : MonoBehaviour
{
    public CardColor[] coloredCardColors; // Array of colors for the colored cards
    public Card[] allCards; // Reference to all the cards Scriptable Objects

    private void AssignColorsToCards()
    {
        int coloredCardIndex = 0;

        for (int i = 0; i < allCards.Length; i++)
        {
            if (allCards[i] is Card)
            {
                Card card = allCards[i] as Card;

                if (card.color == CardColor.Grey && coloredCardIndex < coloredCardColors.Length)
                {
                    card.color = coloredCardColors[coloredCardIndex];
                    UnityEditor.EditorUtility.SetDirty(card); // Mark the Scriptable Object as dirty to save changes
                    coloredCardIndex++;
                }
            }
        }
    }

    private void Start()
    {
        AssignColorsToCards();
    }
}
