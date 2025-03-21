using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents an NPC.
/// </summary>
public class NPC
{
    public string location;

    public string[] Greeting;
    public bool inDialogue = false;
    public int ID;
    public string Name;
    public string Job;
    public string Description;
    public List<string> Personality;
    public List<ScheduleEntry> Schedule;
    public List<Message> messages;
    public string CurrentLocation { get; set; }
    public Vector2 CurrentCoordinates { get; set; }

    /// <summary>
    /// NavMesh Stuff
    /// </summary
    [SerializeField] Transform target;
    public NavMeshAgent agent;

    /// <summary>
    /// Prints the NPC's data to the debug log.
    /// </summary>
    public void printData()
    {
        Debug.Log($"Printing data about this NPC...\n" +
                  $"Greeting: {Greeting}\n" +
                  $"Name: {Name}\n" +
                  $"Job: {Job}\n" +
                  $"Description: {Description}\n" +
                  $"Personality: {string.Join(", ", Personality)}\n" +
                  $"Current Location: {CurrentLocation}\n" +
                  $"Current Coordinates: {CurrentCoordinates}\n" +
                  $"Is in Dialogue: {inDialogue}");
        Debug.Log("Printing NPC's messages...");
        foreach (Message message in messages)
        {
            Debug.Log($"Role: {message.role}\n" + $"Content: {message.content}");
        }
    }
}

/// <summary>
/// Represents a schedule entry for an NPC.
/// </summary>
public class ScheduleEntry
{
    public string waypoint;
    public int time;
    public string location;
}

/// <summary>
/// Represents a message in the GPT API conversation.
/// </summary>
[System.Serializable]
public class Message
{
    public string role;    // The role of the message (e.g., "user" or "system").
    public string content; // The content of the message.
}
