using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PowderType", menuName = "Simulation Element/Lock", order = 1)]
public class LockInfo : InfoBase
{
    public double lengthOfBarrel;
    public double inclinationMax;
    public double elasticityOfRecoilSpring;
}