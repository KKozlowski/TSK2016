using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParametersChoice : MonoBehaviour
{
    public ParameterLook[] chosenParameters;
    public ParameterUnwindButton[] unwindButtons;

    public ParameterLook parameterTemplate;

    void Start()
    {
        foreach (PowderInfo p in Simulation.Me.possiblePowders) {
            spawnParameterAsButton(p, unwindButtons[0]);
        }

        foreach (CartridgeInfo p in Simulation.Me.possibleCartridges) {
            spawnParameterAsButton(p, unwindButtons[1]);
        }

        foreach (LockInfo p in Simulation.Me.possibleLocks) {
            spawnParameterAsButton(p, unwindButtons[2]);
        }

        foreach (var parameterUnwindButton in unwindButtons)
        {
            parameterUnwindButton.Close();
        }
    }

    void Update()
    {
        chosenParameters[0].Show(Simulation.Me.Powder);
        chosenParameters[1].Show(Simulation.Me.Cartridge);
        chosenParameters[2].Show(Simulation.Me.Lock);
    }

    void spawnParameterAsButton(InfoBase info, ParameterUnwindButton parent)
    {
        ParameterLook sp = Instantiate(parameterTemplate).GetComponent<ParameterLook>();
        sp.gameObject.AddComponent<Button>();
        sp.Show(info);
        sp.InitButton();
        parent.Adopt(sp);
    }
}
