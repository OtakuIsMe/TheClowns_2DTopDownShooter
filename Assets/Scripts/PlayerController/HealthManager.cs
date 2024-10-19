using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator myAnimator;

    void Awake()
    {
        health = 3; 
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        foreach (Image img in hearts)
        {
            if (img != null)
            {
                img.sprite = emptyHeart;
            }
        }

        for (int i = 0; i < health; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].sprite = fullHeart;
            }
        }
    }
}
