using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas QuitMenu;
    public Button LevelOneButton;
    public Button LevelTwoButton;
    public Button LevelThreeButton;
    public Button ExitButton;

    void Start ()
    {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        LevelOneButton = LevelOneButton.GetComponent<Button>();
        LevelTwoButton = LevelTwoButton.GetComponent<Button>();
        LevelThreeButton = LevelThreeButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
        QuitMenu.enabled = false;
	}

    public void ExitPress()
    {
        QuitMenu.enabled = true;
        LevelOneButton.enabled = false;
        LevelTwoButton.enabled = false;
        LevelThreeButton.enabled = false;
        ExitButton.enabled = false;
    }

    public void NoPress()
    {
        QuitMenu.enabled = false;
        LevelOneButton.enabled = true;
        LevelTwoButton.enabled = true;
        LevelThreeButton.enabled = true;
        ExitButton.enabled = true;
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevelThree()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
