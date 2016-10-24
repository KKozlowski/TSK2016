using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Simulation : MonoBehaviour {

    public static Simulation Me { get; private set; }

    private PowderInfo _pow;

    public PowderInfo Powder
    {
        get { return _pow; }
        set { _pow = value; }
    }

    private CartridgeInfo _cart;
    public CartridgeInfo Cartridge {
        get { return _cart; }
        set { _cart = value; }
    }

    private LockInfo _lock;
    public LockInfo Lock {
        get { return _lock; }
        set
        {
            Pistol.Me.SetBarrelLength(value.lengthOfBarrel);
            _lock = value; 
        }
    }

    public List<PowderInfo> possiblePowders;
    public List<CartridgeInfo> possibleCartridges;
    public List<LockInfo> possibleLocks;

    void Awake()
    {
        Me = this;

        
    }

    void Start()
    {
        Powder = possiblePowders[0];
        Cartridge = possibleCartridges[0];
        Lock = possibleLocks[0];
    }
}
