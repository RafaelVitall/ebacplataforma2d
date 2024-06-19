using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonManager : MonoBehaviour
{
    [Header("Button List")]
    public List<GameObject> buttons;
    [Space(5)]

    [Header("Animation Settings")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }
    void ShowButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            var button = buttons[i];
            button.SetActive(true);
            button.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);
        }

    }

    void HideAllButtons()
    {
        foreach(var button in buttons)
        {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }
}
