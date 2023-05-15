using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public int pageIndex;
    public bool isFirstGameplay;
    [SerializeField] GameObject[] tutorialPages;
    [SerializeField] GameObject menuTutorial;
    void Awake()
    {
        isFirstGameplay = true;
        AlternateTutorial();
    }
    void Start()
    {
        pageIndex = 0;
        PageSwitcher(pageIndex);
    }
    void AlternateTutorial()
    {
        if (isFirstGameplay)
        {
            Time.timeScale = 0;
            menuTutorial.SetActive(true);
        }
        else
        {
            menuTutorial.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void goToNextPage()
    {
        int currentPage = pageIndex;
        pageIndex++;
        int nextPage = pageIndex;
        if (nextPage == tutorialPages.Length)
        {
            SkipTutorial();
        }
        else
        {
            PageSwitcher(pageIndex);
        }
    }
    private void PageSwitcher(int index)
    {
        if(index - 1 >= 0)
        {
            tutorialPages[index-1].SetActive(false);
        }
        tutorialPages[index].SetActive(true);
    }

    public void SkipTutorial()
    {
        isFirstGameplay = false;
        AlternateTutorial();
    }
}
