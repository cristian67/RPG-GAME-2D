using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attributes attributes;
    public string alias;
    public int expEnemy;
    public GameObject puff;


    public void GiveExp()
    {
        GameManager.Instance.player.GetComponent<ExperienceLevel>().exp += expEnemy;
    }
}
