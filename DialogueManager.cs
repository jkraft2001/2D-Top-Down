using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator dialogueAnimator;

    bool hasStartedDialogue = false;

    public PlayerController2D playerCon;
    private float originalPlayerSpeed;



    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        if(playerCon == null)
        {
            playerCon = GameObject.Find("Player").GetComponent<PlayerController2D>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(hasStartedDialogue) DisplayNextSentence();
        }

    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnimator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        hasStartedDialogue = true;

        // set playercontrooler speed to 0
        originalPlayerSpeed = playerCon.speed;
        playerCon.speed = 0;

        // also set the animator to "dialogue"
        playerCon.GetComponent<Animator>().SetBool("InDialogue", true);

    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;   
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueAnimator.SetBool("IsOpen", false);
        hasStartedDialogue = false;

        // reset player speed
        playerCon.speed = originalPlayerSpeed;

        playerCon.GetComponent<Animator>().SetBool("InDialogue", false);

    }
}
