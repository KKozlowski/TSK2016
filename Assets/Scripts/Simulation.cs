using UnityEngine;
using System.Collections.Generic;

public class Simulation : MonoBehaviour
{
    public static Simulation Me { get; private set; }

    private PowderInfo _pow;
    public PowderInfo Powder
    {
        get { return _pow; }
        set
        {
            _pow = value;

            if (wasInit)
                Init();
        }
    }

    private CartridgeInfo _cart;
    public CartridgeInfo Cartridge {
        get { return _cart; }
        set
        {
            Pistol.Me.SetBarrelDiameter(value.diameterOfBullet * 1.05);
            Pistol.Me.Cartridge.SetLength(value.lengthOfCasing);
            Pistol.Me.Cartridge.SetDiameter(value.diameterOfBullet);
            _cart = value;

            if (wasInit)
                Init();
        }
    }

    private LockInfo _lock;
    public LockInfo Lock {
        get { return _lock; }
        set
        {
            Pistol.Me.SetBarrelLength(value.lengthOfBarrel);
            Pistol.Me.SetInclination(value.inclinationMax);
            _lock = value;

            if (wasInit)
                Init();
        }
    }

    public List<PowderInfo> possiblePowders;
    public List<CartridgeInfo> possibleCartridges;
    public List<LockInfo> possibleLocks;

    Calculation calculation;
    public Presentation Presentation { get; private set; }
    bool wasInit;

    void Awake()
    {
        Me = this;
    }

    void Start()
    {
        Powder = possiblePowders[0];
        Cartridge = possibleCartridges[0];
        Lock = possibleLocks[0];
        Init();
        wasInit = true;
    }

    void Init()
    {
        calculation = new Calculation();
        calculation.Init(Cartridge, Lock, Powder, 1000);
        calculation.Calculate();

        Presentation = GetComponent<Presentation>();
        Presentation.Init(calculation.GetResults(), 4f);
        Presentation.SetAnimating(true);
    }
}
