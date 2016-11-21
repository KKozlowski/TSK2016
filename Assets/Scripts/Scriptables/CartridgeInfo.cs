using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PowderType", menuName = "Simulation Element/Cartridge", order = 2)]
public class CartridgeInfo : InfoBase
{
    public double diameterOfBullet;
    public double massOfBullet;
    public double lengthOfCasing;
    public double massOfPowder;
}