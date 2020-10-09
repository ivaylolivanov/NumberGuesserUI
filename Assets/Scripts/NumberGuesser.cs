using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberGuesser : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI guessDisplay;
    [SerializeField] TextMeshProUGUI myGuessIsText;

    private int guess;
    private const string detectLies = @"You are trying to cheat! Tell me if i
    guessed correctly!";

    void Start()
    {
	GameStart();
    }

    void GameStart()
    {
        myGuessIsText.text = @"I shall attempt to hack into your mind and guess
        the number you are thinking about!";
        DoGuess();
    }

    public void OnPressHigher() {
        min = guess + 1;
        DoGuess();
    }

    public void OnPressLower() {
        max = guess - 1;
        DoGuess();
    }

    private void DoGuess()
    {
        guess = Random.Range(min, max + 1);
        if(min <= max) {
            guessDisplay.text = guess.ToString();
        }
        else if(myGuessIsText.text.CompareTo(detectLies) != 0) {
            myGuessIsText.text = detectLies;
            myGuessIsText.color = new Color32(255, 0, 62, 255);
        }
        else if(myGuessIsText.text.CompareTo(detectLies) == 0) {
            LoadLoseScene();
        }
        else {
            return;
        }
    }

    private void LoadLoseScene() {
        SceneManager.LoadScene(3);
    }
}
