using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public GameObject player;
    public float dmg = 10f;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerHealth>().TakeDMG(dmg);
    }
}
