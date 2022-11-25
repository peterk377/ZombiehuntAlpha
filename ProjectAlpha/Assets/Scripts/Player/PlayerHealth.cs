using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float hp;
    private float lerpTimer;
    [Header("Health Bar")]
    public float maxhp = 100.0f;
    public float chipSpeed = 2.0f;
    public Image fhp;
    public Image bhp;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fade;

    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxhp);
        UpdateHP();
        if(overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fade;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHP() 
    {
        
        float fillf = fhp.fillAmount;
        float fillb = bhp.fillAmount;
        float hfrac = hp / maxhp;

        if(fillb > hfrac)
        {
            fhp.fillAmount = hfrac;
            bhp.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComp = lerpTimer / chipSpeed;
            percentComp = percentComp * percentComp;
            bhp.fillAmount = Mathf.Lerp(fillb, hfrac, percentComp);
        }

        if (fillf < hfrac)
        {
            bhp.fillAmount = hfrac;
            bhp.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComp = lerpTimer / chipSpeed;
            percentComp = percentComp * percentComp;
            fhp.fillAmount = Mathf.Lerp(fillf, hfrac, percentComp);
        }
    }

    public void TakeDMG(float dmg)
    {
        hp = hp - dmg;
        lerpTimer = 0.0f;
        durationTimer = 0.0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    public void Heal(float heal)
    {
        hp = hp + heal;
        lerpTimer = 0.0f;
    }
}
