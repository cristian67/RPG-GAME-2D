using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelAttribute : MonoBehaviour
{
    public static PanelAttribute Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public TextMeshProUGUI txtNivel;
    public TextMeshProUGUI txtExp;
    public TextMeshProUGUI txtSalud;
    public TextMeshProUGUI txtAttack;
    public TextMeshProUGUI txtVelocity;
    public TextMeshProUGUI txtPtos;

    public void UpdateTextAtributte(Attributes attributes, Salud salud, ExperienceLevel experienceLevel)
    {
        txtNivel.text = experienceLevel.nivel.ToString();
        txtExp.text = experienceLevel.exp.ToString();
        txtSalud.text = salud.salud.ToString();
        txtAttack.text = attributes.attack.ToString();
        txtVelocity.text = attributes.velocity.ToString();
        txtPtos.text = experienceLevel.pointAttributes.ToString();
    }
}
