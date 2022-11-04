using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool dialogueActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueActive = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && dialogueActive)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            dialogueActive = false;
        }    
    }
}
