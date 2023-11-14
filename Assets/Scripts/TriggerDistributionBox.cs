using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDistributionBox : MonoBehaviour
{
    public GameObject disBox;
    public GameObject maincamera;
    public GameObject doubleDoorTriggerObject;
    public bool isLink = false;

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.E) && disBox.GetComponent<Puzzle>().canPuzzle)
            {
                SceneManager.LoadScene("LevelLink", LoadSceneMode.Additive);
                maincamera.SetActive(false);
                Time.timeScale = 0;
                isLink = true;
            }
    }

    public void DeactivateOverlay()
    {
        SceneManager.UnloadSceneAsync("LevelLink");
        maincamera.SetActive(true);
        Time.timeScale = 1;
        if (doubleDoorTriggerObject != null)
        {
            DoubleDoorTrigger ddt = doubleDoorTriggerObject.GetComponent<DoubleDoorTrigger>();
            if (ddt != null)
            {
                ddt.isEnergy = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!disBox.GetComponent<Puzzle>().isDone)
        {
            disBox.GetComponent<Puzzle>().canPuzzle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        disBox.GetComponent<Puzzle>().canPuzzle = false;
    }
}
