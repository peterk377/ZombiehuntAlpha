using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombie;
    public GameObject testEnemy;
    public GameObject barricade;
    public void SpawnZombie()
    {
        Instantiate(zombie, new Vector3(48, -1, -8), Quaternion.identity);
    }

    public void SpawnTestEnemy()
    {
        Instantiate(testEnemy, new Vector3(-48, 2, -19), Quaternion.identity);
        Instantiate(testEnemy, new Vector3(-69, 2, -12), Quaternion.identity);
        Instantiate(testEnemy, new Vector3(-87, 2, -4), Quaternion.identity);
        Instantiate(testEnemy, new Vector3(-103, 2, 5), Quaternion.identity);
        Instantiate(testEnemy, new Vector3(-115, 2, 13), Quaternion.identity);
    }

    public void SpawnBarricade()
    {
        Instantiate(barricade, new Vector3(13, 1, -17), Quaternion.Euler(0, 0, 90)); 
    }
}
