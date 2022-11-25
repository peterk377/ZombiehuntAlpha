using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100f;

    public void takeDmg(float dmg)
    {
        hp -= dmg;

        if (hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
