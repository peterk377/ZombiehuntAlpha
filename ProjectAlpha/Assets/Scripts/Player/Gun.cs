
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;

    public Camera camfps;

    public GameObject impact;

    private float nextTimeToFire = 0f;
 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        void Shoot()
        {

            RaycastHit hit;
            if (Physics.Raycast(camfps.transform.position,camfps.transform.forward, out hit, range))
            {
               Enemy target = hit.transform.GetComponent<Enemy>();
               if (target != null)
                {
                    target.takeDmg(damage);
                }
                Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }
        
    }
}
