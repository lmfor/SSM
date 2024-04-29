using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopButtonCanvasManager : MonoBehaviour
{
    [Header("Button Tree")]
    public GameObject SkillButtonTree;
    public GameObject StatsButtonTree;

    [Header("Main Buttons")]
    public Button buyButton;
    public Button backButton;
    public Button deselectButton;

    [Header("Power Buttons")]
    public Button pulseButton;
    public Button waveformButton;
    public Button sparkButton;
    public Button crossedButton;
    public Button chargedButton;

    [Header("Stats Buttons")]
    public Button VigorButton;
    public Button SpeedButton;
    public Button CooldownButton;
    public Button DamageButton;
    

    [Header("Cosmetics Buttons")]

    [Header("Price Text")]
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI balanceText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip tooPoorSound;
    public AudioClip chaChingSound;

    List<Button> miscellaneousButtons;
    List<Button> selectedButtons;
    int balance = 100;


    


    public void SwitchSceneBackToGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SwitchSceneBackToTitle()
    {
        SceneManager.LoadScene(0);
    }


    private void Start()
    {
        //PULL balance amount from SOMEWHERE
        //titleScreenButton.onClick.AddListener(() => OnButtonClick(titleScreenButton));
        buyButton.onClick.AddListener(() => OnButtonClick(buyButton));
        deselectButton.onClick.AddListener(() => OnButtonClick(deselectButton));

        //SKILL TREE BUTTONS / POWER BUTTONS
        pulseButton.onClick.AddListener(() => OnButtonClick(pulseButton));
        waveformButton.onClick.AddListener(() => OnButtonClick(waveformButton));
        sparkButton.onClick.AddListener(() => OnButtonClick(sparkButton));
        crossedButton.onClick.AddListener(() => OnButtonClick(crossedButton));
        chargedButton.onClick.AddListener(() => OnButtonClick(chargedButton));

        //STATS BUTTONS
        VigorButton.onClick.AddListener(() => OnButtonClick(VigorButton));
        SpeedButton.onClick.AddListener(() => OnButtonClick(SpeedButton));
        CooldownButton.onClick.AddListener(() => OnButtonClick(CooldownButton));
        DamageButton.onClick.AddListener(() => OnButtonClick(DamageButton));


        miscellaneousButtons = new List<Button> { buyButton, backButton };
        selectedButtons = new List<Button>();

    }

    private void Update()
    {
        balanceText.text = ( "Balance : " + Convert.ToString(balance) );
    }


    public void ShowSkillButtonTree()
    {
        if (SkillButtonTree != null)
        {
            if (!SkillButtonTree.activeSelf)
            {
                SkillButtonTree.SetActive(true);
            } else
            {
                SkillButtonTree.SetActive(false);
            }
        }

    }

    public void ShowStatsButtonTree()
    {
        if (StatsButtonTree != null)
        {
            if (!StatsButtonTree.activeSelf)
            {
                StatsButtonTree.SetActive(true);
            }
            else
            {
                StatsButtonTree.SetActive(false);
            }
        }
    }

    
    public void OnButtonClick(Button clickedButton)
    {
        if(clickedButton != null)
        {
            //AUDIO EFFECT FOR CLICKED BUTTON
            if(clickedButton != buyButton)
            {
                audioSource.PlayOneShot(clickSound);
            } 

            //DESELECT BUTTON
            if(clickedButton == deselectButton)
            {
                foreach (Button b in selectedButtons)
                {
                    b.enabled = true;
                    b.gameObject.SetActive(true);
                }
                priceText.text = "0";
                selectedButtons.Clear();
            }

            



            // ADD SELECTED BUTTONS TO SHOP QUEUE
            if (!miscellaneousButtons.Contains(clickedButton))
            {
                selectedButtons.Add(clickedButton);
            }
        


            /*
             * SKILL TREE BUTTONS
             * SKILL TREE BUTTONS
             */

            if(clickedButton == buyButton)
            {
                if (balance > int.Parse(priceText.text))
                {
                    balance -= (int.Parse(priceText.text));
                    priceText.text = "0";
                    Debug.Log("balance" + balance);

                    selectedButtons.Clear();
                    audioSource.PlayOneShot(chaChingSound);

                } else
                {
                    //Debug.Log("Too poor!");
                    foreach(Button b in selectedButtons)
                    {
                        b.enabled = true;
                        b.gameObject.SetActive(true);
                    }
                    priceText.text = "0";
                    audioSource.PlayOneShot(tooPoorSound);
                }



            }

            if(clickedButton == pulseButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 20));
                pulseButton.gameObject.SetActive(false);
                pulseButton.enabled = false;
            }
            if(clickedButton == waveformButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 30));
                waveformButton.gameObject.SetActive(false);
                waveformButton.enabled = false;
            }
            if(clickedButton == sparkButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 40));
                sparkButton.gameObject.SetActive(false);
                sparkButton.enabled = false;
            }
            if(clickedButton == crossedButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 50));
                crossedButton.gameObject.SetActive(false);
                crossedButton.enabled = false;
            }
            if (clickedButton == chargedButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 60));
                chargedButton.gameObject.SetActive(false);
                chargedButton.enabled = false;
            }

            /*
             * STATS TREE BUTTONS
             * STATS TREE BUTTONS
             */

            if(clickedButton == VigorButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 10));
                VigorButton.gameObject.SetActive(false);
                VigorButton.enabled = false;
            }
            if(clickedButton == SpeedButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 10));
                SpeedButton.gameObject.SetActive(false);
                SpeedButton.enabled = false;
            }
            if(clickedButton == CooldownButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 10));
                CooldownButton.gameObject.SetActive(false);
                CooldownButton.enabled = false;
            }
            if(clickedButton == DamageButton)
            {
                priceText.text = Convert.ToString((int.Parse(priceText.text) + 10));
                DamageButton.gameObject.SetActive(false);
                DamageButton.enabled = false;
            }






        }

    }
}
