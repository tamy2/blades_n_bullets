using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceManager : MonoBehaviour
{
    public static BalanceManager instance;

    public Transform slider;
    public float sliderMaxPos;
    public Image gunIcon, swordIcon;
    public Image backing;
    public int unitsPerSword = -2;
    public int unitsPerGun = 1;
    public float totalUnits;

    public Color safeColor;
    public Color dangerColor;

    public bool gunDisabled;
    public bool swordDisabled;
    public float disableTime;

    private float currentUnits;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentUnits = totalUnits / 2;
    }

    void Update()
    {
        float ratio = (float)currentUnits / totalUnits;
        float pos = (ratio * 2 - 1) * sliderMaxPos;
        slider.localPosition = new Vector3(pos, 0, 0);

        float colorRatio = Mathf.Abs(ratio * 2 - 1);
        backing.color = Color.Lerp(safeColor, dangerColor, colorRatio);
    }

    public void AddToGun()
    {
        currentUnits += unitsPerGun;
        if (currentUnits > totalUnits)
        {
            StartCoroutine(DisableWeapon(false));
            currentUnits = totalUnits;

        }
    }

    public void AddToSword()
    {
        currentUnits += unitsPerSword;
        if (currentUnits < 0)
        {
            StartCoroutine(DisableWeapon(true));
            currentUnits = 0;
        }
    }

    IEnumerator DisableWeapon(bool sword)
    {
        Image image = sword ? swordIcon : gunIcon;
        image.color = Color.red;
        if (sword)
        {
            swordDisabled = true;
        }
        else
        {
            gunDisabled = true;
        }

        yield return new WaitForSeconds(disableTime);

        image.color = Color.white;
        if (sword)
        {
            swordDisabled = false;
        }
        else
        {
            gunDisabled = false;
        }
    }
}
