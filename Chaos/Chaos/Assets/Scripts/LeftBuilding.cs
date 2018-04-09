using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBuilding : MonoBehaviour
{
    public float fHP = 1500.0f;
    public float fATK = 100.0f;
    public float fAttackSpd = 1.0f;
    public PlayerControl player;
    public GameObject gPlayer;
    public float AtkCoolTime = 3.0f;


    private void Awake()
    {
        player = gPlayer.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        if(dist <= 100.0f)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        player.HP -= 1.0f * Time.deltaTime;
    }
}
