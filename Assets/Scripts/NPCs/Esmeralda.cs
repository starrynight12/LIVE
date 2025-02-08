using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Triggers a dialogue interaction when the player stays within a collider and presses the designated button.
/// </summary>
public class Esmeralda_Pharmacist : MonoBehaviour
{
    /// <summary>
    /// The NPC instance representing Esmeralda.
    /// </summary>
    public NPC Esmeralda;

    /// <summary>
    /// List of messages associated with the NPC.
    /// </summary>
    public List<Message> messages = new List<Message>();

    /// <summary>
    /// Initializes the NPC instance and adds it to the NPC manager.
    /// </summary>
    private void Start()
    {
        Debug.Log("Esmeralda script started");
        Esmeralda = new NPC
        {
            Greeting = "You seek knowledge� or perhaps something more? Hmm� interesting.",
            inDialogue = false,
            ID = 11,
            Name = "Esmeralda",
            Job = "Pharmacist",
            Description = "Esmeralda is the town�s enigmatic pharmacist, known for her deep knowledge of both modern medicine and mysterious herbal remedies. " +
            "Rumors persist that she might be a witch, but she neither confirms nor denies them. " +
            "She speaks in cryptic riddles and often knows things she was never told, adding to her air of mystery." +
            "She takes care of her nephew Ace who was sent to Babel to overcome behavioral issues",
            Personality = new List<string> { "Mysterious", "Aloof", "Intelligent", "Cryptic" },
            Schedule = new ScheduleEntry[]
            {
                new ScheduleEntry
                {
                    Coordinates = new Vector2(2, 2),
                    Location = "Pharmacy"
                },
                new ScheduleEntry
                {
                    Coordinates = new Vector2(8, 8),
                    Location = "Overworld"
                }
            },
            messages = new List<Message>(),
            CurrentLocation = "Pharmacy",
            CurrentCoordinates = new Vector2(2, 2)
        };
        NPCManager.Instance.AddNPC(Esmeralda);
    }

    /// <summary>
    /// Triggers the dialogue interaction when the player stays within the collider and presses the designated button.
    /// </summary>
    /// <param name="collision">The collider that the player is interacting with.</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetButton("Jump") && !MenuManager.Instance.isPaused && !DialogueManager.Instance.isTalking)
        {
            Esmeralda.inDialogue = true;
            Debug.Log("Esmeralda in dialogue");
            DialogueManager.Instance.StartDialogue(Esmeralda);
        }
    }
}

