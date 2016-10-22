using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParameterLook : MonoBehaviour
{
    public Text titleText;
    public Text[] parameterTexts;

    public InfoBase shownInfo;

    public void Show(InfoBase info)
    {
        if (!info || info == shownInfo) return;

        shownInfo = info;

        titleText.text = info.title;

        PowderInfo pi = info as PowderInfo;
        if (pi)
        {
            parameterTexts[0].text = "Burning time: " + pi.timeOfBurning;
            parameterTexts[1].text = "Burning temperature: " + pi.temperatureOfBuring;
            parameterTexts[2].text = "Moles of gas produced from one kilogram: " + pi.molesOfGasFromKilogram;
            return;
        }

        CartridgeInfo ci = info as CartridgeInfo;
        if (ci)
        {
            parameterTexts[0].text = "Bullet diameter: " + ci.diameterOfBullet;
            parameterTexts[1].text = "Bullet mass: " + ci.massOfBullet;
            parameterTexts[2].text = "Casing length: " + ci.lengthOfCasing;
            return;
        }

        LockInfo li = info as LockInfo;
        if (li)
        {
            parameterTexts[0].text = "Barrel length: " + li.lengthOfBarrel;
            parameterTexts[1].text = "Lock maximum inclination: " + li.inclinationMax;
            parameterTexts[2].text = "Recoil spring elasticity: " + li.elasticityOfRecoilSpring;
            return;
        }
    }

    public void InitButton()
    {
        Button b = GetComponent<Button>();
        if (b)
        {
            if (shownInfo is PowderInfo)
                b.onClick.AddListener(() => Simulation.Me.Powder = shownInfo as PowderInfo);
            else if (shownInfo is CartridgeInfo)
                b.onClick.AddListener(() => Simulation.Me.Cartridge = shownInfo as CartridgeInfo);
            else if (shownInfo is LockInfo)
                b.onClick.AddListener(() => Simulation.Me.Lock = shownInfo as LockInfo);
        }
    }
}
