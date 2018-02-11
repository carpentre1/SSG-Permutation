using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text explanation;
    public Text results;

    public GameObject resultsPanel;

    public GameObject setGreen;
    public GameObject setYellow;

    public GameObject order1;
    public GameObject order2;

    public Button answerA; public Text AnswerAText;
    public Button answerB; public Text AnswerBText;
    public Button answerC; public Text AnswerCText;

    public Button continueButton;

    public GameObject bejeweledImage; public Text bejeweledText;

    int currentScene = 0;

    public void NextScene()
    {
        currentScene++;
        if(currentScene == 1)//change explanation to factorials
        {
            explanation.text = @"The maximum possible permutations of a set can be found using n!, read ""n factorial"".
A factorial is the product of an integer and all integers below it.
This set's n! is 2!:
 2 x 1 = 2";
        }

        if(currentScene == 2)//add third block to set, change explanation to "total permutations" question, show possible answer buttons, hide order1
        {
            continueButton.gameObject.SetActive(false);

            order1.SetActive(false);
            setGreen.SetActive(true);
            explanation.text = @"What are the total permutations of this new set?

Count the total number of objects in the set and then factorialize that number. For example, 2! was 2 x 1.";

            ToggleAnswerVisibility(true);
            AnswerAText.text = "6";
            AnswerBText.text = "9";
            AnswerCText.text = "12";
            SetAnswerType(answerA, true);
            SetAnswerType(answerB, false);
            SetAnswerType(answerC, false);

        }

        if(currentScene == 3)//confirm correct answer, show order 2, add continue
        {
            resultsPanel.SetActive(true);
            results.text = "Correct!\nThere are three items in this set.\n3! = 3 x 2 x 1 = 6.";

            order1.SetActive(false);
            order2.SetActive(true);

            ToggleAnswerVisibility(false);
            continueButton.gameObject.SetActive(true);
        }
        if(currentScene == 4)//hide results, update explanation to permutation in games, show image
        {
            resultsPanel.SetActive(true);
            results.text = "";

            explanation.text = "Permutations are often used in video games such as Bejeweled. The player is required to move the colored gems around to obtain the desired permutation.";
            bejeweledImage.SetActive(true);
            bejeweledText.gameObject.SetActive(true);

        }
        if(currentScene == 5)//show final set, hide image, show final question
        {
            bejeweledImage.SetActive(false);
            bejeweledText.gameObject.SetActive(false);
            resultsPanel.SetActive(false);

            GameObject orders = GameObject.Find("Orders");
            orders.SetActive(false);

            GameObject orderPanel = GameObject.Find("OrderPanel");
            orderPanel.SetActive(false);

            continueButton.gameObject.SetActive(false);

            explanation.text = "What are the total permutations of this new set?";

            setYellow.SetActive(true);

            ToggleAnswerVisibility(true);
            AnswerAText.text = "15";
            AnswerBText.text = "18";
            AnswerCText.text = "24";
            SetAnswerType(answerA, false);
            SetAnswerType(answerB, false);
            SetAnswerType(answerC, true);
        }
        if(currentScene == 6)//final scene, confirm correct answer and congratulate
        {
            resultsPanel.SetActive(true);
            results.text = "Correct!\nThere are four items in this set.\n4! = 4 x 3 x 2 x 1 = 24.";

            ToggleAnswerVisibility(false);

            explanation.text = "Congratulations! You understand permutations and how to find the total number of possible permutations in a set.";
        }
    }

    public void WrongAnswer()
    {
        Debug.Log(currentScene);
        resultsPanel.SetActive(true);
        results.text = "Try again.";
    }

    public void SetAnswerType(Button button, bool answer)
    {
        button.onClick.RemoveAllListeners();
        if (answer)
        {
            button.onClick.AddListener(NextScene);
        }
        else if(!answer)
        {
            button.onClick.AddListener(WrongAnswer);
        }
        Debug.Log(button + " " + answer);
    }

    public void ToggleAnswerVisibility(bool visible)
    {
        if(visible)
        {
            answerA.gameObject.SetActive(true);
            answerB.gameObject.SetActive(true);
            answerC.gameObject.SetActive(true);
        }
        else
        {
            answerA.gameObject.SetActive(false);
            answerB.gameObject.SetActive(false);
            answerC.gameObject.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
