using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueController : MonoBehaviour
{
    private String[] fullDialogue = new string[2];

    public String[] dialogue;
    
    private GameObject panel;
    
    private int Index = 0;

    void Start()
    {
        panel = gameObject.transform.GetChild(0).gameObject;
        
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.active)
        {
            if (Index >= fullDialogue.Length)
            {
                DEactivateDialoguePanel();
            }
            else
            {
                var texti = panel.transform.GetChild(0).gameObject;
                texti.GetComponent<Text>().text = fullDialogue[Index];

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Index++;
                }
            }
        }
    }

    public void activateDialoguePanel(String[] newDialogue)
    {
        Index = 0;
            
        fullDialogue = new string[newDialogue.Length];

        dialogue = new string[fullDialogue.Length];
        
        for (int x = 0; x < fullDialogue.Length; x++)
        {
            fullDialogue[x] = newDialogue[x];
            
            fullDialogue[x] = replaceUserNameWithPlayerName(fullDialogue[x]);

            dialogue[x] = fullDialogue[x];
        }
        
        panel.SetActive(true);
    }
    
    public void DEactivateDialoguePanel()
    {
        panel.SetActive(false);
        var player = GameObject.Find("Player");
        player.GetComponent<playerController>().ChangeMoveBool_True();
    }

    public string replaceUserNameWithPlayerName(String stringzona)
    {
        var nomes = new int[99];

        var nomesIndex = 0;
        
        
        var quatro = new int[4];

        var quatroIndex = 0;
        
        
        var fullString = "";
        
        var polymerization = new string[9999];
        
        var allChars = stringzona.ToCharArray();

        var index = 0;
        
        for (int x = 0; x < allChars.Length; x++)
        {
          if (allChars[x].ToString() != " ")
            {
                polymerization[index] += allChars[x];
                quatro[quatroIndex] = x;
                quatroIndex++;
            }
            else
            {
                polymerization[index] += allChars[x];
                index++;
                quatro = new int[4];
                quatroIndex = 0;
            }
          
          if (quatroIndex >= 3)
          {
              if (allChars[quatro[0]].ToString() == "P")
              {
                  if (allChars[quatro[1]].ToString() == "D")
                  {
                      if (allChars[quatro[2]].ToString() == "P")
                      {
                          if (allChars[quatro[3]].ToString() == "N")
                          {
                              nomes[nomesIndex] = index;
                              nomesIndex++;
                              
                              Debug.Log(nomesIndex);
                          }
                      }
                  }
              }
              else
              {
                  quatro = new int[4];
                  quatroIndex = 0;
              }
          }
        }
        
        changeForReal(nomes, polymerization);

        var cont = 0;
        
        for (int x = 0; x < polymerization.Length; x++)
        {
            fullString += polymerization[x];
            
            if (polymerization[x] == " " || polymerization[x] == null)
            {
                cont++;
            }

            if (cont >= 4)
            {
                break;
            }
        }
        
        return fullString;
    }

    private void changeForReal(int[] stringerson, string[] polymer)
    {
        for (int x = 0; x < stringerson.Length; x++)
        {
            if (stringerson[x] != 0)
            {
                polymer[stringerson[x]] = playerData.playerName;
            }
            else
            {
                break;
            }
        }
    }
}
