using UnityEngine;

[CreateAssetMenu(fileName = "New Destination", menuName = "Ticket to Ride/Destination")]
public class DestinationTicket : ScriptableObject
{
    public string startCity;
    public string endCity;
    public int pointValue;

    public int GetPoints()
    {
        // Calculate and return the point value of the destination ticket
        // Replace this with your actual implementation based on your game's scoring logic
        return pointValue; // Placeholder; replace with your actual implementation
    }
}
