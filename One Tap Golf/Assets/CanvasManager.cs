using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> canvasGroups;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var child in transform.GetComponentsInChildren<CanvasGroup>())
        {
            canvasGroups.Add(child);
        }

        canvasGroups[1].alpha = 0f;
        canvasGroups[1].interactable = false;
    }

    public void EnableLooseGameCanvas()
    {
        canvasGroups[0].interactable = false;
        canvasGroups[1].interactable = true;
        canvasGroups[0].alpha = 0f;
        canvasGroups[1].alpha = 1f;
        canvasGroups[1].gameObject.GetComponentInChildren<Score>().ShowScore();
        canvasGroups[1].gameObject.GetComponentInChildren<HighScore>().ShowBestScore();
    }
}
