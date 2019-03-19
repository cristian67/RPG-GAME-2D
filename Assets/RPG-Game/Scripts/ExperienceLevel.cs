using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GeneratorText))]
public class ExperienceLevel : MonoBehaviour
{
    public ButtonAttribute[] buttonAttribute;
    public Image barExp;

    private GeneratorText generatorText;
    private Range rangoTextLevelUP = new Range() { min = 0 , max = 0 };

    private int expActual;
    private int expNextLevel;
    public int pointAttributes;

    private PlayerController player;
    private Salud salud;

    private float expPercentageActual; // % de exp para subir de nivel

    public int nivel { get; set; }

    //Propiedad EXP
    public int exp
    {
        get
        {
            return expActual;
        }
    
        set
        {
            expActual = value;
            if (nivel > 1)
            {
                expPercentageActual = (float)(exp - ExperienceCumulativeCurve(nivel)) / expNextLevel;
                CheckLevelUP();
            }
            else
            {
                expPercentageActual = (float)(expActual) / expNextLevel;

                while (expPercentageActual >= 1)
                {
                    LevelUp();
                }
            }

            UpdateExpBar();
            UpdatePanelAttribute();
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        nivel = 1;

        player = GetComponent<PlayerController>();
        salud  = GetComponent<Salud>();
     
        generatorText = GetComponent<GeneratorText>();
        expNextLevel  = ExperienceCurve(nivel);

        UpdateExpBar();
        CallButtonSwitch();
    }

    private void CheckLevelUP()
    {
        while (expPercentageActual >= 1)
        {
            LevelUp();
        }
    }

    private int ExperienceCurve(int nivel)
    {
        float functionExp = Mathf.Log(nivel, 3f) + 10;
        int   experience  = Mathf.CeilToInt(functionExp);

        return nivel; 
    }

    private int ExperienceCumulativeCurve(int nivel)
    {
        int experience = 0;
        for (int i = 1; i < nivel; i++)
        {
            experience += ExperienceCurve(i);
        }

        return experience;
    }


    private void LevelUp()
    {
        nivel++;
        ConfigNextLevel();
        generatorText.CreateTextHit(generatorText.textHit,
                                    "Nuevo Nivel ", 
                                    transform, 
                                    0.4f, 
                                    Color.cyan,
                                    rangoTextLevelUP,
                                    rangoTextLevelUP,
                                    2f);
        expPercentageActual = (float)(exp - ExperienceCumulativeCurve(nivel)) / expNextLevel;
    }


    private void ConfigNextLevel()
    {
        pointAttributes++;
        expNextLevel = ExperienceCurve(nivel);
        CallButtonSwitch();
    }

    void UpdateExpBar()
    {
        barExp.fillAmount = expPercentageActual;
    }


    public void SubtractPointAttribute()
    {
        pointAttributes--;
        CallButtonSwitch();
        UpdatePanelAttribute();

    }


    private void CallButtonSwitch()
    {
        for (int i = 0; i < buttonAttribute.Length; i++)
        {
            buttonAttribute[i].SwitchButton(pointAttributes);
        }
    }


    //Actualizar los paneles
    private void UpdatePanelAttribute()
    {
        PanelAttribute.Instance.UpdateTextAtributte(player.attributePlayer, salud, this);
    }
}
