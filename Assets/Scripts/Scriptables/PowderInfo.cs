using UnityEngine;

[CreateAssetMenu(fileName = "PowderType", menuName = "Simulation Element/Powder", order = 1)]
public class PowderInfo : InfoBase
{
    public double timeOfBurning;
    public double temperatureOfBuring;
    public double molesPerKilo;
    public double mass;
}