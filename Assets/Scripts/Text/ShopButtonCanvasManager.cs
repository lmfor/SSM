using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonCanvasManager : MonoBehaviour
{

    public GameObject SkillButtonTree;

        public void SwitchSceneBackToGame()
    {
        SceneManager.LoadScene(2);
    }


    public void ShowSkillButtonTree()
    {
        if(SkillButtonTree != null)
        {
            if(!SkillButtonTree.activeSelf)
            {
                SkillButtonTree.SetActive(true);
            } else
            {
                SkillButtonTree.SetActive(false);
            }
        }

    }
}
