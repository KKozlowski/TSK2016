using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour {

    public static Simulation Me { get; private set; }

	public PowderInfo Powder { get; set; }
    public CartridgeInfo Cartridge { get; set; }
    public LockInfo Lock { get; set; }

    public List<PowderInfo> possiblePowders;
    public List<CartridgeInfo> possibleCartridges;
    public List<LockInfo> possibleLocks;

    void Awake()
    {
        Me = this;

        Powder = possiblePowders[0];
        Cartridge = possibleCartridges[0];
        Lock = possibleLocks[0];
    }
}
